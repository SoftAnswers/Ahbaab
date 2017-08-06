using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;
using Android.Support.V7.App;
using Android.Support.V4.App;
using SharedCode;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Ahbab.Entities;

namespace Ahbab.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/logo", Theme = "@style/Theme.Ahbab")]
    public class MainActivity : AppCompatActivity
    {
        private Button mButtonSignUp;
        private Button mButtonSignIn;
        private ProgressBar mProgressBar;
        private NavigationView mNavigationView;
        private DrawerLayout mDrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            try
            {
                GetSpinnersItems();
            }
            catch (Exception ex)
            {
                var email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, new string[] { "jad.abinader18@gmail.com" });
                email.PutExtra(Intent.ExtraText, new string[] { ex.ToString() });
                email.SetType("message/rfc822");
                StartActivity(email);
            }

            SetContentView(Resource.Layout.Main);

            var toolbar = this.FindViewById<SupportToolbar>(Resource.Id.toolBar);

            this.SetSupportActionBar(toolbar);

            var actionBar = this.SupportActionBar;

            actionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            mNavigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            if (mNavigationView != null)
            {
                SetUpDrawerContent(mNavigationView);
            }


            mButtonSignUp = FindViewById<Button>(Resource.Id.btnRegister);

            mButtonSignIn = this.FindViewById<Button>(Resource.Id.btnLogin);

            mProgressBar = this.FindViewById<ProgressBar>(Resource.Id.progressBar);

            mButtonSignUp.Click += (object sender, EventArgs args) =>
            {
                Intent registerIntent = new Intent(this, typeof(RegisterActivity));
                this.StartActivity(registerIntent);
                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                    Android.Resource.Animation.SlideOutRight);

            };

            mButtonSignIn.Click += (object sender, EventArgs args) =>
            {
                var transaction = SupportFragmentManager.BeginTransaction();

                SignInDialog singInDialog = new SignInDialog(this);

                singInDialog.Show(transaction, "dialog_fragment");

                singInDialog.mOnSignInComplete += signInDialog_mOnSignInComplete;
            };
        }

        void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                if (e.MenuItem.ItemId != Resource.Id.contactUs)
                {
                    OpenLegalNotesFragment(e.MenuItem);
                    mDrawerLayout.CloseDrawers();
                }
                else
                {
                    var email = new Intent(Intent.ActionSend);

                    email.PutExtra(Intent.ExtraEmail,
                                   new string[] { "info@ahbaab.com" });

                    email.SetType("message/rfc822");
                    StartActivity(email);
                }
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            item.SetChecked(false);
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Right);
                    return true;

                default:
                    return true;//base.OnOptionsItemSelected(item);
            }
        }

        public void OpenLegalNotesFragment(IMenuItem item)
        {
            Bundle mybundle = new Bundle();

            mybundle.PutInt("ItemId", item.ItemId);

            var transaction = SupportFragmentManager.BeginTransaction();

            LegalNotesFragment legalNotesFragment = new LegalNotesFragment();

            legalNotesFragment.Arguments = mybundle;

            legalNotesFragment.Show(transaction, "dialog_fragment");

            item.SetChecked(false);
        }
        
        private void signInDialog_mOnSignInComplete(object sender, OnSignInEventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;

            new Thread(new ThreadStart(() =>
            {
                try
                {
                    var result = AhbabDatabase.Login(e.UserName, e.Password);

                    if (result != null)
                    {
                        Ahbab.CurrentUser = result;

                        Intent mainPageIntent = new Intent(this, typeof(MainPageActivity));

                        this.StartActivity(mainPageIntent);

                        this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                                       Android.Resource.Animation.SlideOutRight);
                    }
                    RunOnUiThread(() =>
                    {
                        //HIDE PROGRESS DIALOG
                        mProgressBar.Visibility = ViewStates.Invisible;

                        if (result != null)
                        {
                            Toast.MakeText(this, "Login Successfull.", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, "Login Failed.", ToastLength.Short).Show();
                        }
                    });
                }
                catch (Exception ex)
                {
                    var email = new Intent(Intent.ActionSend);

                    email.PutExtra(Intent.ExtraEmail,
                                   new string[] { "info@ahbaab.com" });

                    email.PutExtra(Intent.ExtraText, new string[] { ex.ToString() });

                    email.SetType("message/rfc822");
                    StartActivity(email);
                }
            })).Start();
        }

        static void GetSpinnersItems()
        {
            Ahbab.statusItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                        Constants.Tables.Status);

            Ahbab.statusItems.Insert(0, new SpinnerItem(-1, "Choose", Constants.DefaultValues.FamilyStatus));

            Ahbab.mAgeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                                      Constants.Tables.Age);
            Ahbab.mAgeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Age));

            Ahbab.mContactTimeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                                                 Constants.Tables.ContactTime);
            Ahbab.mContactTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ContactTime));

            Ahbab.mEducationItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                            Constants.Tables.Education);
            Ahbab.mEducationItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EducationLevel));

            Ahbab.mEyesColorItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                            Constants.Tables.EyesColor);
            Ahbab.mEyesColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EyesColor));

            Ahbab.mGoalFromSiteItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                               Constants.Tables.GoalFromSite);
            Ahbab.mGoalFromSiteItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.GoalFromSite));

            Ahbab.mHairColorItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                            Constants.Tables.HairColor);
            Ahbab.mHairColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.HairColor));

            Ahbab.mHeightItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                         Constants.Tables.Height);
            Ahbab.mHeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Height));

            Ahbab.mJobItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                      Constants.Tables.Job);
            Ahbab.mJobItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Job));

            Ahbab.mCountries = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                       Constants.Tables.Countries);
            Ahbab.mCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.OriginCountry));

            Ahbab.mResidenceCountries = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                       Constants.Tables.Countries);
            Ahbab.mResidenceCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ResidenceCountry));

            Ahbab.mContactWays = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                  Constants.Tables.ContactWays);

            Ahbab.mTimeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                                       Constants.Tables.Time);
            Ahbab.mTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.TimeZone));

            Ahbab.mWeightItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                        Constants.Tables.Weight);
            Ahbab.mWeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Weight));
        }
    }
}


