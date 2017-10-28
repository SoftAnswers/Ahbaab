using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Ahbab.Droid.Helpers;
using Ahbab.Entities;
using Android.Graphics;
using SharedCode;

namespace Ahbab.Droid
{
	[Activity(Label = "@string/searchResult",Theme="@style/Theme.Ahbab")]
	public class SearchResultsActivity : AppCompatActivity
	{
        private List<User> results;
        private RecyclerView mRecyclerView;
		private DrawerLayout mDrawerLayout;
        Button nextBtn, prevBtn;
        Paginator paginator;
        private int totalPages;
        private int currentPage = 0;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

            results = Ahbab.SearchResults;

            paginator = new Paginator(results);
            totalPages = Paginator.LAST_PAGE;

            SetContentView(Resource.Layout.SearchResultsActivity);

			SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
			SetSupportActionBar(toolbar);
			SupportActionBar ab = SupportActionBar;

			ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
			ab.SetDisplayHomeAsUpEnabled(true);

			mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

			NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

			if (navigationView != null)
			{
				SetUpDrawerContent(navigationView);
			}

            var hView = navigationView.GetHeaderView(0);

            var editAccount = hView.FindViewById<ImageView>(Resource.Id.imgViewHeader);

            if (Ahbab.CurrentUser.ImageBase64 != null && Ahbab.CurrentUser.ImageBytes != null && Ahbab.CurrentUser.ImageBytes[0].Length > 0) {
                var bitmap = BitmapFactory.DecodeByteArray(Ahbab.CurrentUser.ImageBytes[0], 0, Ahbab.CurrentUser.ImageBytes[0].Length);
                editAccount.SetImageBitmap(bitmap);
            }

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerview);
            nextBtn = FindViewById<Button>(Resource.Id.nextBtn);
            prevBtn = FindViewById<Button>(Resource.Id.prevBtn);
            toggleButtons();

            SetUpRecyclerView();
		}

		void SetUpDrawerContent(NavigationView navigationView) {
			navigationView.NavigationItemSelected += (sender, e) => {
                // If the user click on contact us we open directly the email screen
                if (e.MenuItem.ItemId != Resource.Id.contactUs) {
                    // If the user clicks on logout we display the logout popup
                    if (e.MenuItem.ItemId == Resource.Id.logout) {
                        this.logout();
                    } else {
                        OpenLegalNotesFragment(e.MenuItem);
                        mDrawerLayout.CloseDrawers();
                    }
                } else {
                    var email = new Intent(Intent.ActionSend);
                    email.PutExtra(Intent.ExtraEmail, new string[] { "info@ahbaab.com" });
                    email.SetType("message/rfc822");
                    StartActivity(email);
                }
            };
		}

        // Function used to redirect the user to the login activity after clicking in logout
        public void logout() {
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle(Constants.UI.LogoutHeader);
            alert.SetMessage(Constants.UI.LogoutMessage);
            alert.SetPositiveButton(Constants.UI.Logout, (senderAlert, args) => {
                Ahbab.CurrentUser = null;
                Intent loginPageIntent = new Intent(this, typeof(MainActivity));
                loginPageIntent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                this.StartActivity(loginPageIntent);
                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
            });
            alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });
            Android.Support.V7.App.AlertDialog dialog = alert.Create();
            dialog.SetCanceledOnTouchOutside(false);
            dialog.SetCancelable(false);
            dialog.Show();
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

        public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					mDrawerLayout.OpenDrawer((int)GravityFlags.Right);
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		void SetUpRecyclerView()
		{
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));
            mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.generatePage(currentPage), this.Resources));
            mRecyclerView.SetItemClickListener((rv, position, view) => {
                var userPosition = this.currentPage * Paginator.ITEMS_PER_PAGE + position;
                var result = AhbabDatabase.updateVisits(Ahbab.CurrentUser.ID, results[userPosition].ID);
                //An item has been clicked
                Context context = view.Context;
                Intent intent = new Intent(context, typeof(UserDetailsActivity));
                intent.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(results[userPosition]));
                context.StartActivity(intent);
            });
            nextBtn.Click += NextButton_Click;
            prevBtn.Click += PreviousButton_Click;
        }

		private List<Message> GetRandomSubList(List<Message> items, int amount)
		{
			List<Message> list = new List<Message>();

			Random random = new Random();

			while (list.Count < amount)
			{
				list.Add(items[random.Next(items.Count)]);
			}

			return list;
		}

        /**
         * Function used to handle the next button click 
         */
        private void NextButton_Click(object sender, System.EventArgs e) {
            currentPage++;
            mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.generatePage(currentPage), this.Resources));
            toggleButtons();
        }

        /**
         * Function used to handle the previous button click 
         */
        private void PreviousButton_Click(object sender, System.EventArgs e) {
            currentPage--;
            mRecyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(mRecyclerView.Context, paginator.generatePage(currentPage), this.Resources));
            toggleButtons();
        }

        /**
         * Function used to enable/disable the previous and next
         * buttons based on the page index
         */
        private void toggleButtons() {
            if (totalPages == 1) {
                nextBtn.Enabled = false;
                prevBtn.Enabled = false;
            } else if (currentPage == totalPages - 1) {
                nextBtn.Enabled = false;
                prevBtn.Enabled = true;
            } else if (currentPage == 0) {
                prevBtn.Enabled = false;
                nextBtn.Enabled = true;
            } else if (currentPage >= 1 && currentPage <= totalPages - 2) {
                nextBtn.Enabled = true;
                prevBtn.Enabled = true;
            }
        }
    }
}

