
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Asawer.Droid
{
	[Activity(Label = "MessageDetailsActivity", Theme = "@style/Theme.Ahbab")]
	public class MessageDetailsActivity : AppCompatActivity
	{
		public const string EXTRA_MESSAGE = "message";

		private Message message;

		private bool MessageDeleted;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.MessageDetailsActivity);

			SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolBar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			message = JsonConvert.DeserializeObject<Message>(Intent.GetStringExtra(EXTRA_MESSAGE));

			CollapsingToolbarLayout collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
			collapsingToolBar.Title = message.Subject;

			var sender = FindViewById<TextView>(Resource.Id.txtSender);
			var subject = FindViewById<TextView>(Resource.Id.txtSubject);
			var body = FindViewById<TextView>(Resource.Id.txtBody);

			sender.Text = message.Username;
			subject.Text = message.Subject;
			body.Text = message.Body;

			LoadBackDrop();
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			var mClient = new WebClient();
			NameValueCollection parameters = new NameValueCollection(); 
			switch (item.ItemId) {
				case Resource.Id.deleteMessage:
					parameters.Add("messageId", message.ID.ToString()); 
					mClient.UploadValuesCompleted += MClient_UploadValuesCompleted;
					mClient.UploadValuesAsync(new Uri(Constants.FunctionsUri.DeleteMessageUri), parameters);
					return true;
                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }

			return base.OnOptionsItemSelected(item);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.MessageDetailsMenu, menu);
			return true;
		}

		void MClient_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
		{
			var result = Encoding.UTF8.GetString(e.Result);

			if (result.Contains("Successfully"))
			{
				this.MessageDeleted = true;

				Toast.MakeText(this, Constants.UI.MessageDeleted, ToastLength.Short).Show();
			}
		}

		private void LoadBackDrop()
		{
			ImageView imageView = FindViewById<ImageView>(Resource.Id.backdrop);
			imageView.SetImageResource(Messages.RandomMessagesDrawable);
		}
	}
}

