﻿using System;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Newtonsoft.Json;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Asawer.Entities;
using SharedCode;
using System.Net;
using System.Collections.Specialized;
using Asawer.Droid.Adapters;
using Android.Support.V7.Widget;
using Asawer.Droid.Fragments;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;
using Android.Support.V4.App;

namespace Asawer.Droid
{
    [Activity(Label = "UserDetailsActivity", Theme = "@style/Theme.Ahbab")]
    public class UserDetailsActivity : AppCompatActivity, View.IOnTouchListener
    {
        public const string EXTRA_MESSAGE = "message";
        private User user;
        private FloatingActionButton mSendMessageButton;
        private bool BlockSent = false;
        private bool InterestSent = false;
        private ProgressBar mProgressBar;
        private AppBarLayout appBarLayout;
        private CollapsingToolbarLayout collapsingToolbar;
        private FrameLayout visitorsFragmentLayout;
        private Boolean isFragmentOpen = false;
        private float mLastPosY;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserDetailsActivity);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;

            this.InitializeView();
        }

        private void InitializeView()
        {
            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra(EXTRA_MESSAGE));

            this.collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            this.collapsingToolbar.Title = !string.IsNullOrEmpty(user.Name) ? user.Name : user.UserName;
            mSendMessageButton = this.FindViewById<FloatingActionButton>(Resource.Id.btnSendMessage);

            appBarLayout = FindViewById<AppBarLayout>(Resource.Id.appbar);
            var sender = FindViewById<TextView>(Resource.Id.txtUserName);
            var eyesColor = FindViewById<TextView>(Resource.Id.txtEyesColor);
            var hairColor = FindViewById<TextView>(Resource.Id.txtHairColor);
            var lastOnline = FindViewById<TextView>(Resource.Id.txtLastOnline);
            var height = FindViewById<TextView>(Resource.Id.txtHeight);
            var goalFromSite = FindViewById<TextView>(Resource.Id.txtGoalFromSite);
            var weight = FindViewById<TextView>(Resource.Id.txtWeight);
            var age = FindViewById<TextView>(Resource.Id.txtAge);
            var sex = FindViewById<TextView>(Resource.Id.txtSex);
            var familyStatus = FindViewById<TextView>(Resource.Id.txtFamilyStatus);
            var educationLevel = FindViewById<TextView>(Resource.Id.txtEducationLevel);
            var originCountry = FindViewById<TextView>(Resource.Id.txtOriginCountry);
            var residenceCountry = FindViewById<TextView>(Resource.Id.txtResidenceCountry);
            var job = FindViewById<TextView>(Resource.Id.txtJob);
            var selfDescription = FindViewById<TextView>(Resource.Id.txtSelfDescription);
            var partnerDescription = FindViewById<TextView>(Resource.Id.txtPartnerDescription);
            var updateBtn = FindViewById<Button>(Resource.Id.btnUpdate);
            var contactWays = FindViewById<LinearLayout>(Resource.Id.contactWays);
            var visitCountTo = FindViewById<TextView>(Resource.Id.visitCountTo);
            var visitCountToCardView = FindViewById<CardView>(Resource.Id.visitCountToCardView);
            var blocksFrom = FindViewById<TextView>(Resource.Id.blocksFrom);
            var blocksFromCardView = FindViewById<CardView>(Resource.Id.blocksFromCardView);
            var blocksTo = FindViewById<TextView>(Resource.Id.blocksTo);
            var blocksToCardView = FindViewById<CardView>(Resource.Id.blocksToCardView);
            var interestsTo = FindViewById<TextView>(Resource.Id.interestsTo);
            var interestsToCardView = FindViewById<CardView>(Resource.Id.interestsToCardView);
            var interestsFrom = FindViewById<TextView>(Resource.Id.interestsFrom);
            var interestsFromCardView = FindViewById<CardView>(Resource.Id.interestsFromCardView);
            var blocksLayout = FindViewById<LinearLayout>(Resource.Id.blocksLayout);

            mProgressBar = this.FindViewById<ProgressBar>(Resource.Id.progressBar);

            lastOnline.Text = user.LastActiveDate != null ? user.LastActiveDate.ToString("dd-MM-yyyy") : string.Empty;

            sex.Text = user.Gender.Equals("M") ? Constants.UI.Male : Constants.UI.Female;

            selfDescription.Text = user.SelfDescription;

            partnerDescription.Text = user.OthersDescription;

            job.Text = user.JobId > 0 ?
                Ahbab.mJobItems.FirstOrDefault(i => i.ID == user.JobId).DescriptionAR :
                Constants.DefaultValues.NA;


            originCountry.Text = user.OriginCountryId > 0 ?
                Ahbab.mCountries.FirstOrDefault(i => i.ID == user.OriginCountryId).DescriptionAR
                : Constants.DefaultValues.NA;

            residenceCountry.Text = user.CurrentCountryId > 0
                ? Ahbab.mCountries.FirstOrDefault(i => i.ID == user.CurrentCountryId).DescriptionAR
                : Constants.DefaultValues.NA;

            educationLevel.Text = user.EducationLevelID > 0
                ? Ahbab.mEducationItems.FirstOrDefault(i => i.ID == user.EducationLevelID).DescriptionAR
                : Constants.DefaultValues.NA;


            familyStatus.Text = user.Status > 0
                ? Ahbab.statusItems.FirstOrDefault(i => i.ID == user.Status).DescriptionAR
                : Constants.DefaultValues.NA;

            age.Text = user.Age > 0
                ? Ahbab.mAgeItems.FirstOrDefault(i => i.ID == user.Age).DescriptionEN
                : Constants.DefaultValues.NA;


            height.Text = user.HeightId > 0
                ? Ahbab.mHeightItems.FirstOrDefault(i => i.ID == user.HeightId).DescriptionAR
                : Constants.DefaultValues.NA;

            weight.Text = user.WeightId != 0
                ? Ahbab.mWeightItems.FirstOrDefault(i => i.ID == user.WeightId)?.DescriptionAR
                : Constants.DefaultValues.NA;

            goalFromSite.Text = user.UsagePurposeId != 0
                ? Ahbab.mGoalFromSiteItems.FirstOrDefault(i => i.ID == user.UsagePurposeId).DescriptionAR
                : Constants.DefaultValues.NA;

            sender.Text = user.UserName;

            eyesColor.Text = user.EyesColorId != 0
                ? Ahbab.mEyesColorItems.FirstOrDefault(i => i.ID == user.EyesColorId).DescriptionAR
                : Constants.DefaultValues.NA;

            hairColor.Text = user.HairColorId != 0
                ? Ahbab.mHairColorItems.FirstOrDefault(i => i.ID == user.HairColorId).DescriptionAR
                : Constants.DefaultValues.NA;

            visitCountTo.Text = Ahbab.CurrentUser.VisitCountTo.ToString();
            blocksFrom.Text = Ahbab.CurrentUser.BlocksFrom.ToString();
            blocksTo.Text = Ahbab.CurrentUser.BlocksTo.ToString();
            interestsTo.Text = Ahbab.CurrentUser.InterestsTo.ToString();
            interestsFrom.Text = Ahbab.CurrentUser.InterestsFrom.ToString();

            if (user.UserName.Equals(Ahbab.CurrentUser.UserName))
            {
                updateBtn.Visibility = ViewStates.Visible;
                mSendMessageButton.Visibility = ViewStates.Gone;
                updateBtn.Click += UpdateBtn_Click;
                visitCountToCardView.Click += VisitCountToCardView_Click;
                interestsFromCardView.Click += InterestsFromCardView_Click;
                interestsToCardView.Click += InterestsToCardView_Click;
                blocksFromCardView.Click += BlocksFromCardView_Click;
                blocksToCardView.Click += BlocksToCardView_Click;
            }
            else
            {
                blocksLayout.Visibility = ViewStates.Gone;
                interestsToCardView.Visibility = ViewStates.Gone;
            }

            if (user.ContactWays != null && user.ContactWays.Count > 0)
            {
                for (int i = 0; i < user.ContactWays.Count; i++)
                {
                    TextView contactWayValue = new TextView(this)
                    {
                        Text = Ahbab.mContactWays.FirstOrDefault(j => j.ID == user.ContactWays[i].ID).DescriptionAR
                    };
                    contactWays.AddView(contactWayValue);
                }
            }
            else
            {
                TextView contactWayValue = new TextView(this)
                {
                    Text = Constants.DefaultValues.NA
                };
                contactWays.AddView(contactWayValue);
            }

            LoadUserImages();
            mSendMessageButton.Click += MSendMessageButton_Click;
        }

        void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (Ahbab.CurrentUser.Gender.Equals("M") && Ahbab.CurrentUser.Paid == "N")
            {
                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                alert.SetTitle(Constants.UI.Subscription);
                alert.SetMessage(Constants.UI.Upgrade);
                alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
                {
                    this.PerformPurchase();
                });
                alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });
                Android.Support.V7.App.AlertDialog dialog = alert.Create();
                dialog.SetCanceledOnTouchOutside(false);
                dialog.SetCancelable(false);
                dialog.Show();
            }
            else
            {
                Intent registerPageIntent = new Intent(this, typeof(RegisterActivity));
                this.StartActivity(registerPageIntent);
                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
            }
        }

        /**
         * Function used to display the list of users that visited
         * the logged in user
         **/
        void VisitCountToCardView_Click(object sender, EventArgs e)
        {
            try
            {
                var card = sender as CardView;

                if (card.Id == Resource.Id.visitCountToCardView)
                {

                }

                var result = AhbabDatabase.GetActions(user.ID, "visits", "to");

                if (result != null)
                {
                    this.OpenVisitorsFragment(result, Constants.UI.VisitCountTo);
                }
            }
            catch (Exception ex)
            {
                var result = AhbabDatabase.LogMessage("Get user visits error: " + ex.Message, "error");
            }

        }

        /**
         * Function used to display the list of users liked by the logged in user
         **/
        void InterestsFromCardView_Click(object sender, EventArgs e)
        {
            try
            {
                var result = AhbabDatabase.GetActions(user.ID, "interests", "from");
                if (result != null)
                {
                    this.OpenVisitorsFragment(result, Constants.UI.InterestsFrom);
                }
            }
            catch (Exception ex)
            {
                var result = AhbabDatabase.LogMessage("Get user interests error: " + ex.Message, "error");
            }
        }

        /**
         * Function used to display the list of users that are interested by the logged in user
         **/
        void InterestsToCardView_Click(object sender, EventArgs e)
        {
            try
            {
                var result = AhbabDatabase.GetActions(user.ID, "interests", "to");
                if (result != null)
                {
                    this.OpenVisitorsFragment(result, Constants.UI.InterestsTo);
                }
            }
            catch (Exception ex)
            {
                var result = AhbabDatabase.LogMessage("Get user interests error: " + ex.Message, "error");
            }
        }

        /**
         * Function used to display the list of users blocked by the logged in user
         **/
        void BlocksFromCardView_Click(object sender, EventArgs e)
        {
            try
            {
                var result = AhbabDatabase.GetActions(user.ID, "blocks", "from");

                if (result != null)
                {
                    this.OpenVisitorsFragment(result, Constants.UI.BlocksFrom);
                }
            }
            catch (Exception ex)
            {
                var result = AhbabDatabase.LogMessage("Get user blocks error: " + ex.Message, "error");
            }
        }

        /**
         * Function used to display the list of users that blovked the logged in user
         **/
        void BlocksToCardView_Click(object sender, EventArgs e)
        {
            try
            {
                var result = AhbabDatabase.GetActions(user.ID, "blocks", "to");
                if (result != null)
                {
                    this.OpenVisitorsFragment(result, Constants.UI.BlocksTo);
                }
            }
            catch (Exception ex)
            {
                var result = AhbabDatabase.LogMessage("Get user blocks error: " + ex.Message, "error");
            }
        }

        private void OpenVisitorsFragment(List<User> result, string frameTitle)
        {
            this.visitorsFragmentLayout = this.FindViewById<FrameLayout>(Resource.Id.fragment_container);

            var height = Resources.DisplayMetrics.HeightPixels - this.collapsingToolbar.Height;

            var fragLayoutParams = this.visitorsFragmentLayout.LayoutParameters;

            fragLayoutParams.Height = height;

            this.visitorsFragmentLayout.LayoutParameters = fragLayoutParams;

            var visitors = new VisitorsFragment(result, frameTitle);

            var fragmentTransaction = FragmentManager.BeginTransaction();

            fragmentTransaction.Add(this.visitorsFragmentLayout.Id, visitors, "Fragment Pull Up");

            //fragmentTransaction.AddToBackStack(null);

            fragmentTransaction.Commit();

            if (this.visitorsFragmentLayout.TranslationY + 2 >= this.visitorsFragmentLayout.Height)
            {
                var interpolator = new Android.Views.Animations.OvershootInterpolator(5);
                this.visitorsFragmentLayout.Animate().SetInterpolator(interpolator)
                    .TranslationYBy(-200)
                    .SetDuration(500);
            }

            this.visitorsFragmentLayout.SetOnTouchListener(this);

            this.isFragmentOpen = true;
        }

        void MSendMessageButton_Click(object sender, EventArgs e)
        {
#if DEBUG

            this.PresentMessageActivity(mSendMessageButton);
#else
            if (Ahbab.CurrentUser.Gender.Equals("M") && Ahbab.CurrentUser.Paid == "N")
            {
                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                alert.SetTitle(Constants.UI.Subscription);
                alert.SetMessage(Constants.UI.Upgrade);
                alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
                {
                    this.PerformPurchase();
                });

                alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });

                Android.Support.V7.App.AlertDialog dialog = alert.Create();
                dialog.SetCanceledOnTouchOutside(false);
                dialog.SetCancelable(false);
                dialog.Show();
            }
            else
            {
                this.PresentMessageActivity(mSendMessageButton);
            }
#endif
        }

        void SendMessageFragment_MOnSendMessageComplete(object sender, OnSendMessageEventArgs e)
        {
            var message = new Message
            {
                Body = e.Body,
                Subject = e.Subject,
                Sender = Ahbab.CurrentUser.ID,
                Receiver = user.ID
            };

            var result = AhbabDatabase.SendMessage(message, user.Gender);

            if (result.ToLower().Contains("success"))
            {
                Toast.MakeText(this, "Message sent successfully.", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Failed to send message.", ToastLength.Short).Show();
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.ItemId == Resource.Id.block)
            {
                this.CheckForUserValidity(Constants.Database.ApiFiles.BlockFileName);

                return this.BlockSent;
            }
            else if (item.ItemId == Resource.Id.interest)
            {
                this.CheckForUserValidity(Constants.Database.ApiFiles.InterestFileName);

                return this.InterestSent;
            }
            else if (item.ItemId == Android.Resource.Id.Home)
            {
                this.Finish();

                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        void CheckForUserValidity(string uri)
        {

#if DEBUG

            AhbabDatabase.SendBlockOrInterest(uri, Ahbab.CurrentUser.ID, user.ID, this.OnSendBlockOrInterestCompleted);
#else

            if (Ahbab.CurrentUser.Gender.Equals("M") && Ahbab.CurrentUser.Paid == "N")
            {
                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                alert.SetTitle(Constants.UI.Subscription);
                alert.SetMessage(Constants.UI.Upgrade);
                alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
                {
                    this.PerformPurchase();
                });
                alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });
                Android.Support.V7.App.AlertDialog dialog = alert.Create();
                dialog.SetCanceledOnTouchOutside(false);
                dialog.SetCancelable(false);
                dialog.Show();
            }
            else
            {
                AhbabDatabase.SendBlockOrInterest(uri, Ahbab.CurrentUser.ID, user.ID, this.OnSendBlockOrInterestCompleted);
            }
#endif
        }

        void OnSendBlockOrInterestCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            var result = Encoding.UTF8.GetString(e.Result);

            if (result.Contains("block success"))
            {
                this.BlockSent = true;
                Toast.MakeText(this, "User Blocked.", ToastLength.Short).Show();
            }
            else if (result.Contains("interest success"))
            {
                this.InterestSent = true;
                Toast.MakeText(this, "Interest Sent.", ToastLength.Short).Show();
            }
        }

        private void PresentMessageActivity(View view)
        {
            var options = ActivityOptionsCompat.MakeSceneTransitionAnimation(this, view, "transition");

            var revealX = (int)(view.GetX() + view.Width / 2);

            var revealY = (int)(view.GetY() + view.Height / 2);

            var intent = new Intent(this, typeof(MessagingActivity));

            intent.PutExtra(MessagingActivity.EXTRA_CIRCULAR_REVEAL_X, revealX);

            intent.PutExtra(MessagingActivity.EXTRA_CIRCULAR_REVEAL_Y, revealY);

            intent.PutExtra(MessagingActivity.EXTRA_USER, JsonConvert.SerializeObject(user));

            intent.AddFlags(ActivityFlags.ClearTop);

            intent.AddFlags(ActivityFlags.SingleTop);

            ActivityCompat.StartActivity(this, intent, options.ToBundle());
            
            //this.FinishAfterTransition();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            if (!user.UserName.Equals(Ahbab.CurrentUser.UserName))
            {
                MenuInflater.Inflate(Resource.Menu.UserDetailsActivityMenu, menu);
            }
            return true;
        }

        private void LoadUserImages()
        {
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            if (user.ImageBase64 != null && user.ImageBase64.Length > 0)
            {
                viewPager.Adapter = new UserImagesPageViewerAdapter(this, user.ImageBytes);
            }
            else
            {
                viewPager.Visibility = ViewStates.Gone;
                ImageView imageView = FindViewById<ImageView>(Resource.Id.backdrop);
                imageView.SetImageResource(Messages.RandomMessagesDrawable);
            }

        }

        public override void OnBackPressed()
        {
            if (this.isFragmentOpen)
            {
                var interpolator = new Android.Views.Animations.OvershootInterpolator(5);
                this.visitorsFragmentLayout.Animate().SetInterpolator(interpolator)
                    .TranslationY(this.visitorsFragmentLayout.Height)
                    .SetDuration(500);
                this.isFragmentOpen = false;
            }
            base.OnBackPressed();
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:

                    mLastPosY = e.GetY();
                    return true;

                case MotionEventActions.Move:

                    var currentPosition = e.GetY();
                    var deltaY = mLastPosY - currentPosition;

                    var transY = v.TranslationY;

                    transY -= deltaY;

                    if (transY < 0)
                    {
                        transY = 0;
                    }

                    v.TranslationY = transY;

                    return true;

                default:
                    return v.OnTouchEvent(e);
            }
        }

        private async void PerformPurchase()
        {
            var succeeded = await this.PurchaseItem("asawer_yearly_subscription", "AsawerPayload");
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
        }

        public async Task<bool> PurchaseItem(string productId, string payload)
        {

            var supported = CrossInAppBilling.IsSupported;

            var billing = CrossInAppBilling.Current;

            try
            {
                var connected = await billing.ConnectAsync(ItemType.Subscription);

                if (!connected)
                {
                    //we are offline or can't connect, don't try to purchase
                    return false;
                }

                var product = await billing.GetProductInfoAsync(ItemType.Subscription, productId);

                //check purchases
                var purchase = await billing.PurchaseAsync(productId, ItemType.Subscription, payload);

                //possibility that a null came through.
                if (purchase == null)
                {
                    //did not purchase
                    return false;
                }
                else
                {
                    try
                    {
                        var result = AhbabDatabase.Subscribe(Ahbab.CurrentUser.ID);
                        if (result != null)
                        {
                            Ahbab.CurrentUser = result;
                        }
                    }
                    catch (Exception ex)
                    {
                        var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                    }
                    return false;
                }
            }
            catch (InAppBillingPurchaseException purchaseEx)
            {
                //Billing Exception handle this based on the type
                return false;
            }
            catch (Exception ex)
            {
                //Something else has gone wrong, log it
                return false;
            }
            finally
            {
                await billing.DisconnectAsync();
            }
        }
    }
}

