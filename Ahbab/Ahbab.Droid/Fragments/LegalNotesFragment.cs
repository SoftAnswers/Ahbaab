
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Ahbab.Droid
{
	public class LegalNotesFragment : AppCompatDialogFragment
    {
		private TextView mLegalBody;
		private int mItemId;
		private SupportToolbar mToolbar;

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var currentDialog = new Dialog(this.Activity);

            currentDialog.Window.RequestFeature(WindowFeatures.NoTitle);

            currentDialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation;

            return currentDialog;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.LegalNotesFragment, container, false);

			mToolbar = view.FindViewById<SupportToolbar>(Resource.Id.dialogActionBar);

			mItemId = Arguments.GetInt("ItemId");

			mLegalBody = view.FindViewById<TextView>(Resource.Id.txtLegalBody);

			SetTextViewText();

			return view;
		}

		void SetTextViewText()
		{
			switch (mItemId)
			{
				case Resource.Id.whoAreWe:
					mToolbar.SetTitle(Resource.String.whoAreWeTitle);
					mToolbar.SetTitleTextColor(Android.Graphics.Color.White);
					mLegalBody.SetText(Resource.String.whoAreWeBody);
					return;
				case Resource.Id.privacyPolicy:
					mToolbar.SetTitle(Resource.String.privacyPolicyTitle);
					mToolbar.SetTitleTextColor(Android.Graphics.Color.White);
					mLegalBody.SetText(Resource.String.privacyPolicyBody);
					return;
				case Resource.Id.termsAndConditions:
					mToolbar.SetTitle(Resource.String.termsAndConditionTitle);
					mToolbar.SetTitleTextColor(Android.Graphics.Color.White);
					mLegalBody.SetText(Resource.String.termsAndConditionsBody);
					return;
                case Resource.Id.securityPolicy:
                    mToolbar.SetTitle(Resource.String.securityPolicyTitle);
                    mToolbar.SetTitleTextColor(Android.Graphics.Color.White);
                    mLegalBody.SetText(Resource.String.securityPolicyBody);
                    return;
                default:
					return;
			}
		}
	}
}

