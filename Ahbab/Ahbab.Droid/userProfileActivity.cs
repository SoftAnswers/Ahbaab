using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Asawer.Droid.Adapters;
using Asawer.Droid.Fragments;
using Asawer.Entities;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;
using SharedCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlerDialog = Android.Support.V7.App.AlertDialog;

namespace Asawer.Droid
{
    [Activity(Label = "userProfileActivity", Theme = "@style/Theme.Ahbab")]
    public class userProfileActivity : AsawerAppCompatActivity, View.IOnTouchListener
    {
        private CollapsingToolbarLayout collapsingToolbar;
        private FrameLayout visitorsFragmentLayout;
        private Boolean isFragmentOpen = false;
        private float mLastPosY;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.user_profile_activity);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;

            this.InitializeView();
        }

        protected override void OnStart()
        {
            base.OnStart();

            this.SupportActionBar.SetDisplayUseLogoEnabled(false);
        }

        private void InitializeView()
        {
            this.collapsingToolbar = this.FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            this.collapsingToolbar.Title = !string.IsNullOrEmpty(Ahbab.CurrentUser.Name)
                                            ? Ahbab.CurrentUser.Name
                                            : Ahbab.CurrentUser.UserName;

            var searchButton = this.FindViewById<FloatingActionButton>(Resource.Id.fab);

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

            visitCountTo.Text = Ahbab.CurrentUser.VisitCountTo.ToString();
            blocksFrom.Text = Ahbab.CurrentUser.BlocksFrom.ToString();
            blocksTo.Text = Ahbab.CurrentUser.BlocksTo.ToString();
            interestsTo.Text = Ahbab.CurrentUser.InterestsTo.ToString();
            interestsFrom.Text = Ahbab.CurrentUser.InterestsFrom.ToString();

            //updateBtn.Visibility = ViewStates.Visible;

            //updateBtn.Click += UpdateBtn_Click;

            searchButton.Click += this.OnSearchButtonClick;
            visitCountToCardView.Click += this.OnCardViewClick;
            interestsFromCardView.Click += this.OnCardViewClick;
            interestsToCardView.Click += this.OnCardViewClick;
            blocksFromCardView.Click += this.OnCardViewClick;
            blocksToCardView.Click += this.OnCardViewClick;

            LoadUserImages();
        }

        private void OnSearchButtonClick(object sender, EventArgs args)
        {
            var mainPageIntent = new Intent(this, typeof(MainPageActivity));

            this.StartActivity(mainPageIntent);

            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                               Android.Resource.Animation.SlideOutRight);
        }

        private void OnCardViewClick(object sender, EventArgs args)
        {
            var senderCardView = sender as CardView;

            if (senderCardView.Id == Resource.Id.visitCountToCardView)
            {
                this.TryOpenSlideUpFragment(Constants.Database.Tables.Visits,
                                            Constants.Database.ActionOrigin.To,
                                            Constants.UI.VisitCountTo);
            }

            if (senderCardView.Id == Resource.Id.interestsFromCardView)
            {
                this.TryOpenSlideUpFragment(Constants.Database.Tables.Interests,
                                            Constants.Database.ActionOrigin.From,
                                            Constants.UI.InterestsFrom);
            }

            if (senderCardView.Id == Resource.Id.interestsToCardView)
            {
                this.TryOpenSlideUpFragment(Constants.Database.Tables.Interests,
                                            Constants.Database.ActionOrigin.To,
                                            Constants.UI.InterestsTo);
            }

            if (senderCardView.Id == Resource.Id.blocksFromCardView)
            {
                this.TryOpenSlideUpFragment(Constants.Database.Tables.Blocks,
                                            Constants.Database.ActionOrigin.From,
                                            Constants.UI.BlocksFrom);
            }

            if (senderCardView.Id == Resource.Id.blocksToCardView)
            {
                this.TryOpenSlideUpFragment(Constants.Database.Tables.Blocks,
                                            Constants.Database.ActionOrigin.To,
                                            Constants.UI.BlocksTo);
            }
        }

        private void TryOpenSlideUpFragment(string tableName, string destination, string fragmentTitle)
        {
            var result = AhbabDatabase.GetActions(Ahbab.CurrentUser.ID, tableName, destination);

            if (result != null)
            {
                this.OpenSlideUpFragment(result, fragmentTitle);
            }
        }

        private void OpenSlideUpFragment(List<User> result, string frameTitle)
        {
            this.visitorsFragmentLayout = this.FindViewById<FrameLayout>(Resource.Id.fragment_container);

            var height = Resources.DisplayMetrics.HeightPixels - this.collapsingToolbar.Height;

            var fragLayoutParams = this.visitorsFragmentLayout.LayoutParameters;

            fragLayoutParams.Height = Resources.DisplayMetrics.HeightPixels;

            this.visitorsFragmentLayout.LayoutParameters = fragLayoutParams;

            var visitors = new VisitorsFragment(result, frameTitle);

            var fragmentTransaction = FragmentManager.BeginTransaction();

            fragmentTransaction.Add(this.visitorsFragmentLayout.Id, visitors, "Fragment Pull Up");

            fragmentTransaction.Commit();

            if (this.visitorsFragmentLayout.TranslationY + 2 >= this.visitorsFragmentLayout.Height)
            {
                var interpolator = new Android.Views.Animations.OvershootInterpolator(5);
                this.visitorsFragmentLayout.Animate().SetInterpolator(interpolator)
                    .TranslationYBy(-300)
                    .SetDuration(500);
            }

            this.visitorsFragmentLayout.SetOnTouchListener(this);

            this.isFragmentOpen = true;
        }

        private void LoadUserImages()
        {
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            if (Ahbab.CurrentUser.ImageBase64 != null && Ahbab.CurrentUser.ImageBase64.Length > 0)
            {
                viewPager.Adapter = new UserImagesPageViewerAdapter(this, Ahbab.CurrentUser.ImageBytes);
            }
            else
            {
                viewPager.Visibility = ViewStates.Gone;
                ImageView imageView = FindViewById<ImageView>(Resource.Id.backdrop);
                imageView.SetImageResource(Messages.RandomMessagesDrawable);
            }

        }

        private async void PerformPurchase()
        {
            var succeeded = await this.PurchaseItem("asawer_yearly_subscription", "AsawerPayload");
        }

        private void OnUpdateButtonClick()
        {
            if (Ahbab.CurrentUser.Gender.Equals("M") && Ahbab.CurrentUser.Paid == "N")
            {
                var alert = new AlerDialog.Builder(this);
                alert.SetTitle(Constants.UI.Subscription);
                alert.SetMessage(Constants.UI.Upgrade);
                alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
                {
                    this.PerformPurchase();
                });
                alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });
                var dialog = alert.Create();
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {

            MenuInflater.Inflate(Resource.Menu.user_profile_menu, menu);

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.ItemId == Resource.Id.update)
            {
                this.OnUpdateButtonClick();

                return true;
            }

            if (item.ItemId == Resource.Id.logout)
            {
                this.Logout();

                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (this.isFragmentOpen)
            {
                var interpolator = new Android.Views.Animations.OvershootInterpolator(5);
                this.visitorsFragmentLayout.Animate().SetInterpolator(interpolator)
                    .TranslationY(this.visitorsFragmentLayout.Height + 200)
                    .SetDuration(500);
                this.isFragmentOpen = false;
            }
            else
            {
                if (Ahbab.CurrentUser.UserName == Settings.Username)
                {
                    this.Finish();
                }
                else
                {
                    var alert = new AlerDialog.Builder(this);
                    alert.SetTitle(Constants.UI.LogoutHeader);
                    alert.SetMessage(Constants.UI.LogoutMessage);
                    alert.SetPositiveButton(Constants.UI.Logout, (senderAlert, args) =>
                    {
                        var loginPageIntent = new Intent(this, typeof(MainActivity));

                        loginPageIntent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

                        this.StartActivity(loginPageIntent);

                        this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);

                        Ahbab.CurrentUser = null;

                        base.OnBackPressed();
                    });
                    alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });

                    var dialog = alert.Create();
                    dialog.SetCanceledOnTouchOutside(false);
                    dialog.SetCancelable(false);
                    dialog.Show();
                }
            }

        }

        protected override void Logout()
        {
            var alert = new AlerDialog.Builder(this);

            alert.SetTitle(Constants.UI.LogoutHeader);

            alert.SetMessage(Constants.UI.LogoutMessage);

            alert.SetPositiveButton(Constants.UI.Logout, (senderAlert, args) =>
            {

                Settings.RemoveKey(Constants.Settings.UsernamePreferenceName);
                Settings.RemoveKey(Constants.Settings.PasswordPreferenceName);

                var loginPageIntent = new Intent(this, typeof(MainActivity));

                loginPageIntent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

                this.StartActivity(loginPageIntent);

                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);

                this.Finish();

                Ahbab.CurrentUser = null;
            });

            alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });

            var dialog = alert.Create();

            dialog.SetCanceledOnTouchOutside(false);

            dialog.SetCancelable(false);

            dialog.Show();
        }
    }
}