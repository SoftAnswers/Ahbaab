using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Iid;

namespace Asawer.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class AsawerFirebaseInstanceIdService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            base.OnTokenRefresh();
            Log.Debug("Refreshed Token:", FirebaseInstanceId.Instance.Token);

            Ahbab.FirebaseInstanceIdToken = FirebaseInstanceId.Instance.Token;
        }
    }
}