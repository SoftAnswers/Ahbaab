
using System;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Newtonsoft.Json;
using SharedCode;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Asawer.Droid
{
	public class OutboxFragment : SupportFragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var recyclerView = inflater.Inflate(Resource.Layout.OutboxFragment,container, false) as RecyclerView;

			SetupRecyclerView(recyclerView);

			return recyclerView;
		}

		void SetupRecyclerView(RecyclerView recyclerView)
		{
			var values = AhbabDatabase.GetMessages(new Uri(Constants.FunctionsUri.OutboxUri),
												   Ahbab.CurrentUser.ID);

			recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));

			recyclerView.SetAdapter(new MessageRecycleViewAdapter(recyclerView.Context,
																  values, Activity.Resources));

			recyclerView.SetItemClickListener((rv, position, view) =>
			{
				//An item has been clicked
				Context context = view.Context;
				Intent intent = new Intent(context, typeof(MessageDetailsActivity));
				intent.PutExtra(MessageDetailsActivity.EXTRA_MESSAGE,
								JsonConvert.SerializeObject(values[position]));

				context.StartActivity(intent);
			});
		}
	}
}

