using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Asawer.Entities;
using Firebase.Iid;
using SharedCode;

namespace Asawer.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, NoHistory = true, Theme = "@style/SplashTheme")]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Intent.Extras != null)
            {
                var extrasKeySet = this.Intent.Extras.KeySet();

                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug("Asawer", "Key: {0} Value: {1}", key, value);
                }
            }

            if (!Settings.DoSettingsContainKey(Constants.Settings.UsernamePreferenceName))
            {
                var intent = new Intent(this, typeof(MainActivity));

                intent.AddFlags(ActivityFlags.ClearTop);

                intent.AddFlags(ActivityFlags.SingleTop);

                this.StartActivity(intent);

                this.Finish();
            }
            else
            {
                var username = Settings.Username;

                var password = Settings.Password.Base64Decode();

                new Thread(new ThreadStart(() =>
                {
                    RunOnUiThread(async () =>
                    {
                        try
                        {
                            await this.Login(username, password);

                        }
                        catch (Exception ex)
                        {
                            var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                        }
                    });
                })).Start();
            }
        }

        private async Task Login(string username, string password)
        {
            var result = await Task.Run(() => AhbabDatabase.Login(username, password));

            if (result != null)
            {
                Ahbab.CurrentUser = result;

                Intent mainIntent = null;

                var extras = this.Intent.Extras;

                if (this.Intent.Extras != null && extras.ContainsKey("username") && extras.GetString("username") == username)
                {
                    var messageId = extras.ContainsKey("messageId") ? extras.GetString("messageId") : string.Empty;
                    var isUserPaid = extras.ContainsKey("isUserPaid") ? extras.GetString("isUserPaid") : string.Empty;

                    //if (isUserPaid == "Y")
                    //{
                    //    mainIntent = new Intent(this, typeof(MessageDetailsActivity));
                    //    mainIntent.PutExtra(MessageDetailsActivity.EXTRA_MESSAGE_ID, messageId);
                    //}
                    //else
                    //{

                    mainIntent = new Intent(this, typeof(MainPageActivity));

                    mainIntent.PutExtra(MainPageActivity.EXTRA_TAB_ID, 1);

                    //}
                }
                else
                {
                    mainIntent = new Intent(this, typeof(userProfileActivity));
                }

                this.StartActivity(mainIntent);

                this.Finish();

                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                                   Android.Resource.Animation.SlideOutRight);

                Toast.MakeText(this, "Login Successfull.", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Login Failed.", ToastLength.Short).Show();

                var intent = new Intent(this, typeof(MainActivity));

                this.StartActivity(intent);

                this.Finish();
            }
        }
    }
}