using System;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Newtonsoft.Json;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Ahbab.Entities;
using SharedCode;
using System.Net;
using System.Collections.Specialized;
using Ahbab.Droid.Adapters;

namespace Ahbab.Droid
{
	[Activity(Label = "UserDetailsActivity", Theme = "@style/Theme.Ahbab")]
	public class UserDetailsActivity : AppCompatActivity
	{
		public const string EXTRA_MESSAGE = "message";
		private User user;
		private FloatingActionButton mSendMessageButton;
		private bool BlockSent = false;
		private bool InterestSent = false;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.UserDetailsActivity);

			SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolBar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra(EXTRA_MESSAGE));

			CollapsingToolbarLayout collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
			collapsingToolBar.Title = !string.IsNullOrEmpty(user.Name) ? user.Name : user.UserName;
			mSendMessageButton = this.FindViewById<FloatingActionButton>(Resource.Id.btnSendMessage);

			var sender = FindViewById<TextView>(Resource.Id.txtUserName);
			var eyesColor = FindViewById<TextView>(Resource.Id.txtEyesColor);
			var hairColor = FindViewById<TextView>(Resource.Id.txtHairColor);
			var lastOnline = FindViewById<TextView>(Resource.Id.txtLastOnline);
			var height = FindViewById<TextView>(Resource.Id.txtHeight);

			var goalFromSite = FindViewById<TextView>(Resource.Id.txtGoalFromSite);
			var weight = FindViewById<TextView>(Resource.Id.txtWeight);

			var age = FindViewById<TextView>(Resource.Id.txtAge);
			var sex = FindViewById<TextView>(Resource.Id.txtSex);
			var familyStatus = FindViewById<TextView>(Resource.Id.txtFamilyStatus);
			var educationLevel = FindViewById<TextView>(Resource.Id.txtEducationLevel);
			var originCountry = FindViewById<TextView>(Resource.Id.txtOriginCountry);
			var residenceCountry = FindViewById<TextView>(Resource.Id.txtResidenceCountry);
			var job = FindViewById<TextView>(Resource.Id.txtJob);
			var selfDescription = FindViewById<TextView>(Resource.Id.txtSelfDescription);
			var partnerDescription = FindViewById<TextView>(Resource.Id.txtPartnerDescription);
            var updateBtn = FindViewById<Button>(Resource.Id.btnUpdate);
            var contactWays = FindViewById<LinearLayout>(Resource.Id.contactWays);

            lastOnline.Text = user.LastActiveDate != null ? user.LastActiveDate.ToString("dd-MM-yyyy") : string.Empty;

			sex.Text = user.Gender;

			selfDescription.Text = user.SelfDescription;

			partnerDescription.Text = user.OthersDescription;

			if (user.JobId != 0)
			{
				job.Text = Ahbab.mJobItems.FirstOrDefault(i => i.ID == user.JobId).DescriptionAR;
			}
			else
			{
				job.Text = Constants.DefaultValues.NA;
			}

			if (user.OriginCountryId != 0)
			{
				originCountry.Text = Ahbab.mCountries.FirstOrDefault(i => i.ID == user.OriginCountryId).DescriptionAR;
			}
			else
			{
				originCountry.Text = Constants.DefaultValues.NA;
			}

			if (user.CurrentCountryId != 0)
			{
				residenceCountry.Text = Ahbab.mCountries.FirstOrDefault(i => i.ID == user.CurrentCountryId).DescriptionAR;
			}
			else
			{
				residenceCountry.Text = Constants.DefaultValues.NA;
			}

			if (user.EducationLevelID != 0)
			{
				educationLevel.Text = Ahbab.mEducationItems.FirstOrDefault(i => i.ID == user.EducationLevelID).DescriptionAR;
			}
			else
			{
				educationLevel.Text = Constants.DefaultValues.NA;
			}

			if (user.Status != 0)
			{
				familyStatus.Text = Ahbab.statusItems.FirstOrDefault(i => i.ID == user.Status).DescriptionAR;
			}
			else
			{
				familyStatus.Text = Constants.DefaultValues.NA;
			}

			if (user.Age != 0)
			{
				age.Text = Ahbab.mAgeItems.FirstOrDefault(i => i.ID == user.Age).DescriptionEN;
			}
			else
			{
				age.Text = Constants.DefaultValues.NA;
			}

			if (user.HeightId != 0)
			{
				height.Text = Ahbab.mHeightItems.FirstOrDefault(i => i.ID == user.HeightId).DescriptionAR;
			}
			else
			{
				height.Text = Constants.DefaultValues.NA;
			}

			if (user.WeightId != 0)
			{
				weight.Text = Ahbab.mWeightItems.FirstOrDefault(i => i.ID == user.WeightId).DescriptionAR;
			}
			else
			{
				weight.Text = Constants.DefaultValues.NA;
			}


			if (user.UsagePurposeId != 0)
			{
				goalFromSite.Text = Ahbab.mGoalFromSiteItems.FirstOrDefault(i => i.ID == user.UsagePurposeId).DescriptionAR;
			}
			else
			{
				goalFromSite.Text = Constants.DefaultValues.NA;
			}

			sender.Text = user.UserName;

			if (user.EyesColorId != 0)
			{
				eyesColor.Text = Ahbab.mEyesColorItems.FirstOrDefault(i => i.ID == user.EyesColorId).DescriptionAR;
			}
			else
			{
				eyesColor.Text = Constants.DefaultValues.NA;
			}

			if (user.HairColorId != 0)
			{
				hairColor.Text = Ahbab.mHairColorItems.FirstOrDefault(i => i.ID == user.HairColorId).DescriptionAR;
			}
			else
			{
				hairColor.Text = Constants.DefaultValues.NA;
			}

            if (user.UserName.Equals(Ahbab.CurrentUser.UserName)) {
                updateBtn.Visibility = ViewStates.Visible;
                updateBtn.Click += updateBtn_Click;
            }

            if (user.ContactWays != null && user.ContactWays.Count > 0) {
                for (int i = 0; i < user.ContactWays.Count; i++){
                    TextView contactWayValue = new TextView(this);
                    contactWayValue.Text = Ahbab.mContactWays.FirstOrDefault(j => j.ID == user.ContactWays[i].way_id).DescriptionAR;
                    contactWays.AddView(contactWayValue);
                }
            } else {
                TextView contactWayValue = new TextView(this);
                contactWayValue.Text = Constants.DefaultValues.NA;
                contactWays.AddView(contactWayValue);
            }

            LoadUserImages();
			mSendMessageButton.Click += MSendMessageButton_Click;
		}

        void updateBtn_Click(object sender, EventArgs e) {
            Intent registerPageIntent = new Intent(this, typeof(RegisterActivity));
            this.StartActivity(registerPageIntent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        void MSendMessageButton_Click(object sender, EventArgs e)
		{
			if (Ahbab.CurrentUser.Paid == "N")
			{
				Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
				alert.SetTitle(Constants.UI.Subscription);
				alert.SetMessage(Constants.UI.Upgrade);
				alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
				{
					//TODO: Set up payment
				});

				alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) =>
				{

				});

				Android.Support.V7.App.AlertDialog dialog = alert.Create();
				dialog.SetCanceledOnTouchOutside(false);
				dialog.SetCancelable(false);
				dialog.Show();
			}
			else
			{
				Bundle mybundle = new Bundle();

				mybundle.PutString("User", user.UserName);

				FragmentTransaction transaction = FragmentManager.BeginTransaction();

				SendMessageFragment sendMessageFragment = new SendMessageFragment();

				sendMessageFragment.Arguments = mybundle;

				sendMessageFragment.Show(transaction, "dialog_fragment");

				sendMessageFragment.mOnSendMessageComplete += SendMessageFragment_MOnSendMessageComplete;
			}
		}

		void SendMessageFragment_MOnSendMessageComplete(object sender, OnSendMessageEventArgs e)
		{
			var message = new Message();

			message.body = e.Body;
			message.subject = e.Subject;
			message.from_account = Ahbab.CurrentUser.ID;
			message.to_account = user.ID;

			var result = AhbabDatabase.SendMessage(message);

			if (result.ToLower().Contains("success"))
			{
				Toast.MakeText(this, "Message sent successfully.", ToastLength.Short).Show();
			}
			else
			{
				Toast.MakeText(this, "Failed to send message.", ToastLength.Short).Show();
			}
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			var mClient = new WebClient();
			NameValueCollection parameters = new NameValueCollection();
			switch (item.ItemId) {
				case Resource.Id.block:
					parameters.Add("from", Ahbab.CurrentUser.ID.ToString());
					parameters.Add("to", user.ID.ToString());
					mClient.UploadValuesCompleted += MClient_UploadValuesCompleted;
					mClient.UploadValuesAsync(new Uri(Constants.FunctionsUri.BlockUri), parameters);
					return this.BlockSent;
				case Resource.Id.interest:
					parameters.Add("from", Ahbab.CurrentUser.ID.ToString());
					parameters.Add("to", user.ID.ToString());
					mClient.UploadValuesCompleted += MClient_UploadValuesCompleted;
					mClient.UploadValuesAsync(new Uri(Constants.FunctionsUri.InterestUri), parameters);
					return this.InterestSent;
                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }
			return base.OnOptionsItemSelected(item);
		}

		void MClient_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e) {
			var result = Encoding.UTF8.GetString(e.Result);
			if (result.Contains("block success")) {
				this.BlockSent = true;
				Toast.MakeText(this, "User Blocked.", ToastLength.Short).Show();
			}
			else if (result.Contains("interest success")) {
				this.InterestSent = true;
				Toast.MakeText(this, "Interest Sent.", ToastLength.Short).Show();
			}
		}

		public override bool OnCreateOptionsMenu(IMenu menu) {
			MenuInflater.Inflate(Resource.Menu.UserDetailsActivityMenu, menu);
			return true;
		}

		private void LoadUserImages() {
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            if (user.ImageBase64 != null && user.ImageBase64.Length > 0) {
                viewPager.Adapter = new UserImagesPageViewerAdapter(this, user.ImageBytes);
            } else {
                viewPager.Visibility = ViewStates.Gone;
                ImageView imageView = FindViewById<ImageView>(Resource.Id.backdrop);
                imageView.SetImageResource(Messages.RandomMessagesDrawable);
            }

        }
	}
}

