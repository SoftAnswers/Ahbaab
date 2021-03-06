using System;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using Android.Media;
using Java.IO;
using Android.Content.PM;
using Android.Runtime;
using Android;
using Android.Support.V7.Widget;

namespace Asawer.Droid
{
    class SignInDialog : AppCompatDialogFragment
    {
        private EditText mUserName;
        private EditText mPassword;
        private AppCompatCheckBox rememberMeCheckBox;
        private Button mSignIn;
        public EventHandler<OnSignInEventArgs> mOnSignInComplete;
        private Context context;

        public SignInDialog(Context context) {
            this.context = context;
        }

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

            this.rememberMeCheckBox = view.FindViewById<AppCompatCheckBox>(Resource.Id.rememberMeCheckBox);

            mSignIn.Click += MSignIn_Click;
            
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();

            ShowKeyboard(this.View);
        }

        // Function used to display the keyboard when the sign in popup is displayed
        void ShowKeyboard(View view) {

            view.RequestFocus();

            var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;

            inputMethodManager.ShowSoftInput(view, ShowFlags.Forced);

            inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
        }

        private void MSignIn_Click(object sender, EventArgs e)
        {
            mOnSignInComplete.Invoke(this, new OnSignInEventArgs(mUserName.Text, mPassword.Text, this.rememberMeCheckBox.Checked));

            this.Dismiss();
        }
    }
}