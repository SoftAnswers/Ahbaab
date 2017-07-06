using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Ahbab.Droid
{
    class SignInDialog : AppCompatDialogFragment
    {
        private EditText mUserName;
        private EditText mPassword;
        private Button mSignIn;
        //private SupportToolbar mActionBar;
        public EventHandler<OnSignInEventArgs> mOnSignInComplete;

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var currentDialog = new Dialog(this.Activity);

            currentDialog.Window.RequestFeature(WindowFeatures.NoTitle);

            currentDialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation;

            return currentDialog;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.SignInDialog, container, false);

            mUserName = view.FindViewById<EditText>(Resource.Id.txtDialogUserName);

            mPassword = view.FindViewById<EditText>(Resource.Id.txtDialogPassword);

            mSignIn = view.FindViewById<Button>(Resource.Id.btnDialogRegister);

            mSignIn.Click += MSignIn_Click;

            return view;
        }

        private void MSignIn_Click(object sender, EventArgs e)
        {
            mOnSignInComplete.Invoke(this, new OnSignInEventArgs(mUserName.Text, mPassword.Text));

            this.Dismiss();
        }
    }
}