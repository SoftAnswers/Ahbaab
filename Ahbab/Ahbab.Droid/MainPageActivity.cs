using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Asawer.Entities;
using Newtonsoft.Json;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;
using SharedCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlerDialog = Android.Support.V7.App.AlertDialog;

namespace Asawer.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.Ahbab")]
    public class MainPageActivity : AsawerAppCompatActivity
    {
        public List<SpinnerItem> StatusItems { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainPage);

            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);

            tabs.SetupWithViewPager(viewPager);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
        }

        protected override void OnStart()
        {
            base.OnStart();

            var hView = base.NavigationView.GetHeaderView(0);

            var editAccount = hView.FindViewById<ImageView>(Resource.Id.imgViewHeader);

            if (Ahbab.CurrentUser.ImageBase64 != null && Ahbab.CurrentUser.ImageBytes != null && Ahbab.CurrentUser.ImageBytes.Count > 0 && Ahbab.CurrentUser.ImageBytes[0].Length > 0)
            {
                var bitmap = BitmapFactory.DecodeByteArray(Ahbab.CurrentUser.ImageBytes[0], 0, Ahbab.CurrentUser.ImageBytes[0].Length);
                editAccount.SetImageBitmap(bitmap);
            }

            editAccount.Click += EditAccount_Click;
        }

        public async void PerformPurchase()
        {
            var succeeded = await this.PurchaseItem("asawer_yearly_subscription", "AsawerPayload");
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            var adapter = new TabAdapter(SupportFragmentManager);

            adapter.AddFragment(new SearchFragment(), Constants.TabsNames.Search);
            adapter.AddFragment(new InboxFragment(), Constants.TabsNames.Inbox);
            adapter.AddFragment(new OutboxFragment(), Constants.TabsNames.Outbox);

            viewPager.Adapter = adapter;
        }

        // Function used to redirect the user to the login activity after clicking in logout
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

        private void EditAccount_Click(object sender, EventArgs e)
        {
            Intent userDetailsActivity = new Intent(this, typeof(userProfileActivity));
            userDetailsActivity.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(Ahbab.CurrentUser));
            this.StartActivity(userDetailsActivity);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
        }

        private async Task<bool> PurchaseItem(string productId, string payload)
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