
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

namespace Ahbab.Droid
{
	[Activity(Label = "@string/searchResult",Theme="@style/Theme.Ahbab")]
	public class SearchResultsActivity : AppCompatActivity
	{
		private RecyclerView mRecyclerView;
		private DrawerLayout mDrawerLayout;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

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

			SetUpRecyclerView(mRecyclerView);
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

		void SetUpRecyclerView(RecyclerView recyclerView)
		{
			var values = Ahbab.SearchResults;

			recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));

			recyclerView.SetAdapter(new SearchResultsRecyclerViewAdapter(recyclerView.Context,
																  values, this.Resources));

			recyclerView.SetItemClickListener((rv, position, view) =>
			{
				//An item has been clicked
				Context context = view.Context;
				Intent intent = new Intent(context, typeof(UserDetailsActivity));
				intent.PutExtra(UserDetailsActivity.EXTRA_MESSAGE,
								JsonConvert.SerializeObject(values[position]));

				context.StartActivity(intent);
			});
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
	}
}

