﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
            totalPages = Paginator.TOTAL_NUM_ITEMS / Paginator.ITEMS_PER_PAGE;

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

			mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerview);
            nextBtn = FindViewById<Button>(Resource.Id.nextBtn);
            prevBtn = FindViewById<Button>(Resource.Id.prevBtn);
            prevBtn.Enabled = false;

            SetUpRecyclerView();
		}

		void SetUpDrawerContent(NavigationView navigationView)
		{
			navigationView.NavigationItemSelected += (sender, e) =>
			{
				e.MenuItem.SetChecked(true);
				mDrawerLayout.CloseDrawers();
			};
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

            mRecyclerView.SetItemClickListener((rv, position, view) =>
			{
				//An item has been clicked
				Context context = view.Context;
				Intent intent = new Intent(context, typeof(UserDetailsActivity));
				intent.PutExtra(UserDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(results[position]));
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
            if (currentPage == totalPages) {
                nextBtn.Enabled = false;
                prevBtn.Enabled = true;
            }
            else if (currentPage == 0) {
                prevBtn.Enabled = false;
                nextBtn.Enabled = true;
            }
            else if (currentPage >= 1 && currentPage <= totalPages) {
                nextBtn.Enabled = true;
                prevBtn.Enabled = true;
            }
        }
    }
}

