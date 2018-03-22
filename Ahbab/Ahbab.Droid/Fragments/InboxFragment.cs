
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
	public class InboxFragment : SupportFragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var recyclerView = inflater.Inflate(Resource.Layout.InboxFragment, container, false) as RecyclerView;

			SetUpRecyclerView(recyclerView);

			return recyclerView;
		}

		void SetUpRecyclerView(RecyclerView recyclerView) {
			var values = AhbabDatabase.GetMessages(new Uri(Constants.FunctionsUri.InboxUri), Ahbab.CurrentUser.ID);
			recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
			recyclerView.SetAdapter(new MessageRecycleViewAdapter(recyclerView.Context, values, Activity.Resources));
			recyclerView.SetItemClickListener((rv, position, view) => {
				if (Ahbab.CurrentUser.Gender.Equals("M") && Ahbab.CurrentUser.Paid == "N") {
					Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(recyclerView.Context);
					alert.SetTitle(Constants.UI.Subscription);
					alert.SetMessage(Constants.UI.Upgrade);
					alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
					{
						//TODO: Set up payment
					});
					alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });
					Android.Support.V7.App.AlertDialog dialog = alert.Create();
					dialog.SetCanceledOnTouchOutside(false);
					dialog.SetCancelable(false);
					dialog.Show();
				} else {
					//An item has been clicked
					Context context = view.Context;
					Intent intent = new Intent(context, typeof(MessageDetailsActivity));
					intent.PutExtra(MessageDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(values[position]));
					context.StartActivity(intent);
				}
			});
		}
	}
}

