using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Ahbab.Entities;
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
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Widget;
using Android.Content;
using Android.Graphics;

namespace Ahbab.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.Ahbab")]
    public class MainPageActivity : AppCompatActivity
    {
        public List<SpinnerItem> StatusItems { get; set; }
        private DrawerLayout mDrawerLayout;
        private NavigationView mNavigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainPage);

            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolBar);

            SetSupportActionBar(toolbar);

            SupportActionBar ab = SupportActionBar;

            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            ab.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            mNavigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            if (mNavigationView != null)
            {
                SetUpDrawerContent(mNavigationView);
            }

            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);

            tabs.SetupWithViewPager(viewPager);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            fab.Visibility = ViewStates.Invisible;

            var hView = mNavigationView.GetHeaderView(0);

            var editAccount = hView.FindViewById<ImageView>(Resource.Id.imgViewHeader);

            if (Ahbab.CurrentUser.ImageBytes != null && Ahbab.CurrentUser.ImageBytes.Length > 0)
            {
                var bitmap = BitmapFactory.DecodeByteArray(Ahbab.CurrentUser.ImageBytes, 0, Ahbab.CurrentUser.ImageBytes.Length);

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

        void EditAccount_Click(object sender, EventArgs e)
        {
            //TODO: open edit account activity
            Intent registerPageIntent = new Intent(this, typeof(RegisterActivity));

            this.StartActivity(registerPageIntent);

            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                           Android.Resource.Animation.SlideOutRight);
        }

        public List<SpinnerItem> GetSpinnerItems(Uri functionUri, string tableName)
        {
            var retVal = new List<SpinnerItem>();

            var mClient = new WebClient();

            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("TableName", tableName);

            var values = mClient.UploadValues(functionUri, parameters);

            var items = Encoding.UTF8.GetString(values);

            retVal = JsonConvert.DeserializeObject<List<SpinnerItem>>(items);

            return retVal;
        }

        public override void OnBackPressed()
        {
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle(Constants.UI.LogoutHeader);
            alert.SetMessage(Constants.UI.LogoutMessage);
            alert.SetPositiveButton(Constants.UI.Logout, (senderAlert, args) =>
            {
                //TODO: Set up payment

                Ahbab.CurrentUser = null;
                base.OnBackPressed();
            });

            alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) =>
            {

            });

            Android.Support.V7.App.AlertDialog dialog = alert.Create();
            dialog.SetCanceledOnTouchOutside(false);
            dialog.SetCancelable(false);
            dialog.Show();
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

