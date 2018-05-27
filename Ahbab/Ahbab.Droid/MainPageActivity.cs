using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Android.App;
using Android.OS;
using Android.Views;
using System.Net;
using Newtonsoft.Json;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using AlerDialog = Android.Support.V7.App.AlertDialog;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Asawer.Entities;

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

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            fab.Visibility = ViewStates.Invisible;
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

        void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);

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

        void EditAccount_Click(object sender, EventArgs e)
        {
            Intent userDetailsActivity = new Intent(this, typeof(UserDetailsActivity));
            userDetailsActivity.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(Ahbab.CurrentUser));
            this.StartActivity(userDetailsActivity);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        public List<SpinnerItem> GetSpinnerItems(Uri functionUri, string tableName)
        {
            var retVal = new List<SpinnerItem>();

            var mClient = new WebClient();

            NameValueCollection parameters = new NameValueCollection
            {
                { "TableName", tableName }
            };

            var values = mClient.UploadValues(functionUri, parameters);

            var items = Encoding.UTF8.GetString(values);

            retVal = JsonConvert.DeserializeObject<List<SpinnerItem>>(items);

            return retVal;
        }

        public override void OnBackPressed()
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

        public class TabAdapter : FragmentPagerAdapter
        {
            public List<SupportFragment> Fragments { get; set; }
            public List<string> FragmentsNames { get; set; }

            public TabAdapter(SupportFragmentManager sfm)
                : base(sfm)
            {
                Fragments = new List<SupportFragment>();
                FragmentsNames = new List<string>();
            }

            public void AddFragment(SupportFragment fragment, string name)
            {
                Fragments.Add(fragment);
                FragmentsNames.Add(name);
            }

            public override int Count
            {
                get
                {
                    return Fragments.Count;
                }
            }

            public override SupportFragment GetItem(int position)
            {
                return Fragments[position];
            }

            public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(FragmentsNames[position]);
            }
        }
    }
}