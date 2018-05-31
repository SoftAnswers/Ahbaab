
using System;
using System.Collections.Generic;
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
        private List<Message> messages = new List<Message>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var recyclerView = inflater.Inflate(Resource.Layout.InboxFragment, container, false) as RecyclerView;

            this.messages = AhbabDatabase.GetMessages(Constants.Database.ApiFiles.InboxFileName, Ahbab.CurrentUser.ID);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this.Activity;

            SetUpRecyclerView(recyclerView);

            return recyclerView;
        }

        private void SetUpRecyclerView(RecyclerView recyclerView)
        {
            recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));

            recyclerView.SetAdapter(new MessageRecycleViewAdapter(recyclerView.Context, this.messages, Activity.Resources));

            recyclerView.SetItemClickListener(this.OnItemClickListener);
        }

        private void OnItemClickListener(RecyclerView recyclerView, int position, View view)
        {
            var selectedMessage = messages[position];

            if (Ahbab.CurrentUser.Gender.Equals("M") && Ahbab.CurrentUser.Paid == "N")
            {
                if (selectedMessage.MessageType == "voice")
                {
                    var context = view.Context;
                    var intent = new Intent(context, typeof(MessageDetailsActivity));
                    intent.PutExtra(MessageDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(selectedMessage));
                    intent.PutExtra(MessageDetailsActivity.EXTRA_HIDE_TEXT, true);
                    context.StartActivity(intent);
                }
                else
                {
                    var alert = new Android.Support.V7.App.AlertDialog.Builder(recyclerView.Context);
                    alert.SetTitle(Constants.UI.Subscription);
                    alert.SetMessage(Constants.UI.Upgrade);
                    alert.SetPositiveButton(Constants.UI.Subscribe, this.ShowPurchaseDialog);
                    alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });
                    Android.Support.V7.App.AlertDialog dialog = alert.Create();
                    dialog.SetCanceledOnTouchOutside(false);
                    dialog.SetCancelable(false);
                    dialog.Show();
                }
            }
            else
            {
                //An item has been clicked
                var context = view.Context;
                var intent = new Intent(context, typeof(MessageDetailsActivity));
                intent.PutExtra(MessageDetailsActivity.EXTRA_MESSAGE, JsonConvert.SerializeObject(selectedMessage));
                //intent.PutExtra(MessageDetailsActivity.EXTRA_HIDE_TEXT, false);
                context.StartActivity(intent);
            }
        }

        private void ShowPurchaseDialog(object sender,DialogClickEventArgs args)
        {
            //Context context = view.Context;
            //Intent subscribeActivity = new Intent(context, typeof(SubscriptionActivity));
            //subscribeActivity.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
            //context.StartActivity(subscribeActivity);

            var parent = this.Activity as MainPageActivity;

            parent.PerformPurchase();
        }
    }
}

