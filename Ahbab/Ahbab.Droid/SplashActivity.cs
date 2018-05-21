using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var intent = new Intent(this, typeof(MainActivity));

            intent.AddFlags(ActivityFlags.ClearTop);

            intent.AddFlags(ActivityFlags.SingleTop);

            this.StartActivity(intent);

            this.Finish();
        }
    }
}