using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Asawer.Entities;
using SharedCode;
using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android;
using Android.Content.PM;
using Android.Runtime;
using Firebase;

namespace Asawer.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/logo", Theme = "@style/Theme.Ahbab")]
    public class MainActivity : AsawerAppCompatActivity
    {
        private Button mButtonSignUp;
        private Button mButtonSignIn;
        private readonly string[] storagePermissions = new string[] 
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.SystemAlertWindow
        };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Main);

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug("Asawer", "Key: {0} Value: {1}", key, value);
                }
            }

            this.IsPlayServicesAvailable();

            mButtonSignUp = this.FindViewById<Button>(Resource.Id.btnRegister);

            mButtonSignIn = this.FindViewById<Button>(Resource.Id.btnLogin);

            mButtonSignUp.Click += OnSignUpButtonClick;

            mButtonSignIn.Click += OnSignInButtonClick;

            if (Settings.FirstVisit)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                var progress = new ProgressDialog(this)
#pragma warning restore CS0618 // Type or member is obsolete
                {
                    Indeterminate = true
                };
                progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                progress.SetMessage(Constants.UI.ConfiguringLoader);
                progress.SetCancelable(false);
                progress.Show();

                new Thread(new ThreadStart(() =>
                {
                    this.GetSpinnersItems(Settings.FirstVisit);

                    RunOnUiThread(() =>
                    {
                        try
                        {
                            this.InsertItemsToLocalDatabase();

                            Settings.FirstVisit = false;
                        }
                        catch (Exception ex)
                        {
                            var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                        }

                        progress.Hide();
                    });
                })).Start();
            }

            //EnsureStoragePermission();

            Log.Debug("Asawer", "InstanceID token: " + FirebaseInstanceId.Instance.Token);
        }

        private bool EnsureStoragePermission()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return true;
            }

            var retVal = false;

            foreach (string permission in storagePermissions)
            {
                if (CheckSelfPermission(permission) == (int)Permission.Granted)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }

            if (retVal)
            {
                return true;
            }

            RequestPermissions(storagePermissions, 0);

            return false;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case 0:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                            //Permission granted
                            
                        }
                        else
                        {
                            //Permission Denied :(
                            //Disabling location functionality
                            
                        }
                    }
                    break;
            }
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    Log.WriteLine(LogPriority.Info, "Asawer", GoogleApiAvailability.Instance.GetErrorString(resultCode));
                }
                else
                {
                    Log.WriteLine(LogPriority.Info, "Asawer", "This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                Log.WriteLine(LogPriority.Info, "Asawer", "Google Play Services is available.");
                return true;
            }
        }

        private void OnSignUpButtonClick(object sender, EventArgs args)
        {
            var registerIntent = new Intent(this, typeof(RegisterActivity));

            this.StartActivity(registerIntent);

            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                Android.Resource.Animation.SlideOutRight);
        }

        private void OnSignInButtonClick(object sender, EventArgs args)
        {
            var transaction = SupportFragmentManager.BeginTransaction();

            var singInDialog = new SignInDialog(this);

            singInDialog.Show(transaction, "dialog_fragment");

            singInDialog.mOnSignInComplete += OnSignInComplete;
        }

        private void OnSignInComplete(object sender, OnSignInEventArgs e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var progress = new ProgressDialog(this)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                Indeterminate = true
            };
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            progress.SetMessage(Constants.UI.LoginLoader);
            progress.SetCancelable(false);
            progress.Show();

            new Thread(new ThreadStart(() =>
            {
                RunOnUiThread(async () =>
                {
                    try
                    {
                        var result = await Task.Run(() => AhbabDatabase.Login(e.UserName, e.Password));

                        if (result != null)
                        {
                            Ahbab.CurrentUser = result;

                            if (e.RememberMe)
                            {
                                Settings.Username = e.UserName;
                                Settings.Password = e.Password.Base64Encode();
                            }

                            var userProfileIntent = new Intent(this, typeof(userProfileActivity));

                            this.StartActivity(userProfileIntent);

                            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                                               Android.Resource.Animation.SlideOutRight);

                            this.Finish();

                            Toast.MakeText(this, "Login Successfull.", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, "Login Failed.", ToastLength.Short).Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                    }

                    progress.Hide();
                });
            })).Start();
        }

        protected override void Logout()
        {
        }

        private void GetSpinnersItems(bool firstRun)
        {
            this.GetSpinnersItemsFromOnlineDatabase();
        }

        private void InsertItemsToLocalDatabase()
        {
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.statusItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mAgeItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mContactTimeItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mEducationItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mEyesColorItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mGoalFromSiteItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mHairColorItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mHeightItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mJobItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mCountries);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mTimeItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mWeightItems);
            LocalDatabaseAccess.InsertItemsToDatabase<SpinnerItem>(Ahbab.LocalDatabasePath, Ahbab.mContactWays);
        }

        private void GetSpinnersItemsFromOnlineDatabase()
        {
            Ahbab.statusItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                        Constants.Database.Tables.Status);

            Ahbab.statusItems.ForEach(i => i.Type = Constants.ItemTypes.StatusType);

            Ahbab.statusItems.Insert(0, new SpinnerItem(-1, Constants.DefaultValues.Choose, Constants.DefaultValues.FamilyStatus));

            Ahbab.mAgeItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetTwoColumnsSpinnersItemFileName,
                                                      Constants.Database.Tables.Age);

            Ahbab.mAgeItems.ForEach(i => i.Type = Constants.ItemTypes.AgeType);

            Ahbab.mAgeItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Age));

            Ahbab.mContactTimeItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetTwoColumnsSpinnersItemFileName,
                                                                 Constants.Database.Tables.ContactTime);

            Ahbab.mContactTimeItems.ForEach(i => i.Type = Constants.ItemTypes.ContactTimeType);

            Ahbab.mContactTimeItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.ContactTime));

            Ahbab.mEducationItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                            Constants.Database.Tables.Education);

            Ahbab.mEducationItems.ForEach(i => i.Type = Constants.ItemTypes.EducationType);

            Ahbab.mEducationItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.EducationLevel));

            Ahbab.mEyesColorItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                            Constants.Database.Tables.EyesColor);

            Ahbab.mEyesColorItems.ForEach(i => i.Type = Constants.ItemTypes.EyesColorType);

            Ahbab.mEyesColorItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.EyesColor));

            Ahbab.mGoalFromSiteItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                               Constants.Database.Tables.GoalFromSite);

            Ahbab.mGoalFromSiteItems.ForEach(i => i.Type = Constants.ItemTypes.GoalFromSiteType);

            Ahbab.mGoalFromSiteItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.GoalFromSite));

            Ahbab.mHairColorItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                            Constants.Database.Tables.HairColor);

            Ahbab.mHairColorItems.ForEach(i => i.Type = Constants.ItemTypes.HairColorType);

            Ahbab.mHairColorItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.HairColor));

            Ahbab.mHeightItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                         Constants.Database.Tables.Height);

            Ahbab.mHeightItems.ForEach(i => i.Type = Constants.ItemTypes.HeightType);

            Ahbab.mHeightItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Height));

            Ahbab.mJobItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                      Constants.Database.Tables.Job);

            Ahbab.mJobItems.ForEach(i => i.Type = Constants.ItemTypes.JobType);

            Ahbab.mJobItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Job));

            Ahbab.mCountries = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                       Constants.Database.Tables.Countries);

            Ahbab.mCountries.ForEach(i => i.Type = Constants.ItemTypes.CountryType);

            Ahbab.mCountries.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.OriginCountry));

            Ahbab.mResidenceCountries = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                       Constants.Database.Tables.Countries);

            Ahbab.mResidenceCountries.ForEach(i => i.Type = Constants.ItemTypes.CountryType);

            Ahbab.mResidenceCountries.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.ResidenceCountry));

            Ahbab.mContactWays = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                  Constants.Database.Tables.ContactWays);
            Ahbab.mContactWays.ForEach(i => i.Type = Constants.ItemTypes.ContactWaysType);

            Ahbab.mTimeItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetTwoColumnsSpinnersItemFileName,
                                                       Constants.Database.Tables.Time);

            Ahbab.mTimeItems.ForEach(i => i.Type = Constants.ItemTypes.TimeType);

            Ahbab.mTimeItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.TimeZone));

            Ahbab.mWeightItems = AhbabDatabase.GetSpinnerItems(Constants.Database.ApiFiles.GetSpinnerItemsFileName,
                                                        Constants.Database.Tables.Weight);

            Ahbab.mWeightItems.ForEach(i => i.Type = Constants.ItemTypes.WeightType);

            Ahbab.mWeightItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Weight));
        }
    }
}