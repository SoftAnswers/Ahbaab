using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using Asawer.Entities;
using SharedCode;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asawer.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/logo", Theme = "@style/Theme.Ahbab")]
    public class MainActivity : AsawerAppCompatActivity
    {
        private Button mButtonSignUp;
        private Button mButtonSignIn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Main);

            mButtonSignUp = FindViewById<Button>(Resource.Id.btnRegister);

            mButtonSignIn = this.FindViewById<Button>(Resource.Id.btnLogin);
            
            mButtonSignUp.Click += (object sender, EventArgs args) =>
            {
                Intent registerIntent = new Intent(this, typeof(RegisterActivity));
                this.StartActivity(registerIntent);
                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                    Android.Resource.Animation.SlideOutRight);

            };

            mButtonSignIn.Click += (object sender, EventArgs args) =>
            {
                var transaction = SupportFragmentManager.BeginTransaction();

                var singInDialog = new SignInDialog(this);

                singInDialog.Show(transaction, "dialog_fragment");

                singInDialog.mOnSignInComplete += SignInDialog_mOnSignInComplete;
            };


        }

        private void SignInDialog_mOnSignInComplete(object sender, OnSignInEventArgs e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var progress = new ProgressDialog(this)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                Indeterminate = true
            };
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            progress.SetMessage(Constants.UI.LoginLoader);
            progress.SetCancelable(false);
            progress.Show();

            new Thread(new ThreadStart(() =>
            {
                RunOnUiThread(async () =>
                {
                    try
                    {
                        var result = await Task.Run(() => AhbabDatabase.Login(e.UserName, e.Password));

                        if (result != null)
                        {
                            Ahbab.CurrentUser = result;

                            if (e.RememberMe)
                            {
                                Settings.Username = e.UserName;
                                Settings.Password = e.Password.Base64Encode();
                            }

                            var mainPageIntent = new Intent(this, typeof(MainPageActivity));

                            this.StartActivity(mainPageIntent);

                            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                                               Android.Resource.Animation.SlideOutRight);

                            this.Finish();

                            Toast.MakeText(this, "Login Successfull.", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, "Login Failed.", ToastLength.Short).Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                    }

                    progress.Hide();
                });
            })).Start();
        }

        protected override void Logout()
        {
        }
    }
}