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
using Android.Views;
using Android.Widget;
using Asawer.Entities;
using SharedCode;

namespace Asawer.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, NoHistory = true, Theme = "@style/SplashTheme")]
    public class SplashActivity : AppCompatActivity
    {
        private static Task[] getSpinnersFromDatabaseTask;
        public static Task[] GetSpinnersFromDatabaseTask { get => getSpinnersFromDatabaseTask; set => getSpinnersFromDatabaseTask = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var test = Settings.FirstVisit;

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
                            var result = await Task.Run(() => AhbabDatabase.Login(username, password));

                            if (result != null)
                            {
                                Ahbab.CurrentUser = result;

                                var mainPageIntent = new Intent(this, typeof(MainPageActivity));

                                this.StartActivity(mainPageIntent);

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
                        catch (Exception ex)
                        {
                            var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                        }
                    });
                })).Start();
            }
        }
    }
}