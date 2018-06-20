using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;
using SharedCode;
using System;
using System.Threading.Tasks;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Asawer.Droid {
    [Activity(Label = "@string/subscribe", Theme = "@style/Theme.Ahbab")]
    public class SubscriptionActivity : AppCompatActivity {
        private Button subscribeButton;
        private NavigationView mNavigationView;
        private DrawerLayout mDrawerLayout;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Subscription);
            var toolbar = this.FindViewById<SupportToolbar>(Resource.Id.toolBar);

            this.SetSupportActionBar(toolbar);

            var actionBar = this.SupportActionBar;

            actionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            mNavigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            if (mNavigationView != null) {
                SetUpDrawerContent(mNavigationView);
            }
            this.subscribeButton = FindViewById<Button>(Resource.Id.btnSubscribe);
            this.subscribeButton.Click += SubscribeButton_Click;

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
        }

        private async void SubscribeButton_Click(object sender, EventArgs e) {
            var succeeded = await this.PurchaseItem("asawer_yearly_subscription", "AsawerPayload");
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
            base.OnActivityResult(requestCode, resultCode, data);
            InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
        }

        void SetUpDrawerContent(NavigationView navigationView) {
            navigationView.NavigationItemSelected += (sender, e) => {
                if (e.MenuItem.ItemId != Resource.Id.contactUs) {
                    OpenLegalNotesFragment(e.MenuItem);
                    mDrawerLayout.CloseDrawers();
                } else {
                    var email = new Intent(Intent.ActionSend);
                    email.PutExtra(Intent.ExtraEmail, new string[] { "info@ahbaab.com" });
                    email.SetType("message/rfc822");
                    StartActivity(email);
                }
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            item.SetChecked(false);
            switch (item.ItemId) {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Right);
                    return true;
                default:
                    return true;//base.OnOptionsItemSelected(item);
            }
        }

        public void OpenLegalNotesFragment(IMenuItem item) {
            Bundle mybundle = new Bundle();
            mybundle.PutInt("ItemId", item.ItemId);
            var transaction = SupportFragmentManager.BeginTransaction();
            LegalNotesFragment legalNotesFragment = new LegalNotesFragment();
            legalNotesFragment.Arguments = mybundle;
            legalNotesFragment.Show(transaction, "dialog_fragment");
            item.SetChecked(false);
        }

        public async Task<bool> PurchaseItem(string productId, string payload) {
            var billing = CrossInAppBilling.Current;
            try {
                var connected = await billing.ConnectAsync();
                if (!connected) {
                    //we are offline or can't connect, don't try to purchase
                    return false;
                }

                //check purchases
                var purchase = await billing.PurchaseAsync(productId, ItemType.Subscription, payload);

                //possibility that a null came through.
                if (purchase == null) {
                    //did not purchase
                    return false;
                } else {
                    try {
                        var result = AhbabDatabase.Subscribe(Ahbab.CurrentUser.ID);
                        if (result != null) {
                            Ahbab.CurrentUser = result;
                        }
                    } catch (Exception ex) {
                        var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                    }
                    return false;
                }
            } catch (InAppBillingPurchaseException purchaseEx) {
                //Billing Exception handle this based on the type
                return false;
            } catch (Exception ex) {
                //Something else has gone wrong, log it
                return false;
            } finally {
                await billing.DisconnectAsync();
            }
        }
    }
}