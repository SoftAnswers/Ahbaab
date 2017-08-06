
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Ahbab.Entities;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SharedCode;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Ahbab.Droid
{
	public class SearchFragment : SupportFragment
	{
		private TextInputLayout mUserNameInputLayout;
		private Spinner mStatusSpinner;
		private Spinner mAgeSpinner;
		private Spinner mGoalFromSiteSpinner;
		private Spinner mOriginCountrySpinner;
		private Spinner mResidentCountrySpinner;
		private RadioGroup mSexRadioGroup;
		private Button mSearchButton;
		private CustomSpinnerAdapter mAgeAdapter;
		private CustomSpinnerAdapter mStatusAdapter;
		private CustomSpinnerAdapter mGoalFromSiteAdapter;
		private CustomSpinnerAdapter mCountriesAdapter; 

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //base.OnCreateView(inflater, container, savedInstanceState);

            var mView = inflater.Inflate(Resource.Layout.SearchFragment, container, false);

            Initiate(mView);

            BindValues();

            return mView;
        }

        void BindValues()
		{
			mStatusAdapter = new CustomSpinnerAdapter(this.Activity, Resource.Drawable.spinnerItem,
												   Resource.Id.item_value, Ahbab.statusItems);
			mStatusSpinner.Adapter =  mStatusAdapter;

			mAgeAdapter = new CustomSpinnerAdapter(this.Activity, Resource.Drawable.spinnerItem,
													  Resource.Id.item_value, Ahbab.mAgeItems);
			mAgeSpinner.Adapter = mAgeAdapter;

			mGoalFromSiteAdapter =new CustomSpinnerAdapter(this.Activity, Resource.Drawable.spinnerItem,
															   Resource.Id.item_value, Ahbab.mGoalFromSiteItems);
			mGoalFromSiteSpinner.Adapter = mGoalFromSiteAdapter;

			mCountriesAdapter = new CustomSpinnerAdapter(this.Activity, Resource.Drawable.spinnerItem,
																	 Resource.Id.item_value, Ahbab.mCountries);

			mOriginCountrySpinner.Adapter = mCountriesAdapter;

			mResidentCountrySpinner.Adapter = mCountriesAdapter;
		}

		void Initiate(View view)
		{
			this.mUserNameInputLayout = view.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutUser);
			this.mStatusSpinner = view.FindViewById<Spinner>(Resource.Id.searchStatusSpinner);
			this.mAgeSpinner = view.FindViewById<Spinner>(Resource.Id.searchAgeSpinner);
			this.mGoalFromSiteSpinner = view.FindViewById<Spinner>(Resource.Id.goalFromSiteSpinner);
			this.mOriginCountrySpinner = view.FindViewById<Spinner>(Resource.Id.searchOriginCountrySpinner);
			this.mResidentCountrySpinner = view.FindViewById<Spinner>(Resource.Id.searchResidentCountrySpinner);
			this.mSexRadioGroup = view.FindViewById<RadioGroup>(Resource.Id.rdgSearchSex);
			this.mSearchButton = view.FindViewById<Button>(Resource.Id.btnSearch);

			mSearchButton.Click += MSearchButton_Click;
		}

		void MSearchButton_Click(object sender, EventArgs e)
		{
			var userName = mUserNameInputLayout.EditText.Text;

			var gender = string.Empty;

			if (mSexRadioGroup.CheckedRadioButtonId == Resource.Id.rdbSearchMale)
			{
				gender = "M";
			}
			else 
			{
				gender = "F";
			}

			var age = mAgeAdapter.GetItemAtPosition(mAgeSpinner.SelectedItemPosition).ID;

			var status = mStatusAdapter.GetItemAtPosition(mStatusSpinner.SelectedItemPosition).ID;

			var usagePurpose = mGoalFromSiteAdapter.GetItemAtPosition(mGoalFromSiteSpinner.SelectedItemPosition).ID;

			var origin = mCountriesAdapter.GetItemAtPosition(mOriginCountrySpinner.SelectedItemPosition).ID;

			var current = mCountriesAdapter.GetItemAtPosition(mResidentCountrySpinner.SelectedItemPosition).ID;

			var parameters = new NameValueCollection();

			if (!string.IsNullOrEmpty(userName))
			{
				parameters.Add("user", userName);
			}
			if (!string.IsNullOrEmpty(gender))
			{
				parameters.Add("gender", gender);
			}
			if (age != 0)
			{
				parameters.Add("age", age.ToString());
			}
			if (status != 0)
			{
				parameters.Add("status", status.ToString());
			}
			if (usagePurpose != 0)
			{
				parameters.Add("usagepurpose", usagePurpose.ToString());
			}
			if (origin != 0)
			{
				parameters.Add("origin", origin.ToString());
			}
			if (current != 0)
			{
				parameters.Add("current", current.ToString());
			}

			var results = AhbabDatabase.Search(parameters);

			if (results!=null && results.Count > 0)
			{
				Ahbab.SearchResults = results;

				Intent searchResultIntent = new Intent(this.Activity, typeof(SearchResultsActivity));

				this.Activity.StartActivity(searchResultIntent);

				this.Activity.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
											   Android.Resource.Animation.SlideOutRight);

				//Toast.MakeText(this.Activity, "Login Successfull.", ToastLength.Short).Show();
			}
			else
			{
				Toast.MakeText(this.Activity, "No Results Found", ToastLength.Long).Show();
			}
		}
	}
}

