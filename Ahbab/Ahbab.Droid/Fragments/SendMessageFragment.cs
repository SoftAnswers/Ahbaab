
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Ahbab.Droid
{
	public class SendMessageFragment : DialogFragment
	{
		private SupportToolbar mToolbar;
		private TextInputLayout mSubjectInputLayout;
		private TextInputLayout mBodyInputLayout;
		private Button mSendMessage;
		private string mUserName;
		public EventHandler<OnSendMessageEventArgs> mOnSendMessageComplete;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation;

			Dialog.Window.RequestFeature(WindowFeatures.ActionBar);

			var view = inflater.Inflate(Resource.Layout.SendMessageFragment, container, false);

			mToolbar = view.FindViewById<SupportToolbar>(Resource.Id.dialogActionBar);

			mSubjectInputLayout = view.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutSubject);

			mBodyInputLayout = view.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutBody);

			mSendMessage = view.FindViewById<Button>(Resource.Id.btnDialogSend);

			mSendMessage.Click += MSendMessage_Click;

			mUserName = Arguments.GetString("User");

			mToolbar.SetTitle(Resource.String.message);
			mToolbar.Title += string.Format(" {0}", mUserName);
			mToolbar.SetTitleTextColor(Android.Graphics.Color.White);

			return view;
		}

		void MSendMessage_Click(object sender, EventArgs e)
		{
			mOnSendMessageComplete.Invoke(this, new OnSendMessageEventArgs(mSubjectInputLayout.EditText.Text, mBodyInputLayout.EditText.Text));
			this.Dismiss();
		}
	}
}
