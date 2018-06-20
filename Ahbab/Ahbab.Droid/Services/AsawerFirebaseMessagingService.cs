using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace Asawer.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class AsawerFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var messageNotification = message.GetNotification();
            
            foreach (string key in message.Data.Keys)
            {
                Log.Debug("Asawer", "Key: {0} Value: {1}", key, message.Data[key]);
            }

            SendNotification(messageNotification.Title, messageNotification.Body, message.Data);
        }

        private void SendNotification(string title, string body,IDictionary<string,string> data)
        {
            var intent = new Intent(this, typeof(SplashActivity));

            intent.AddFlags(ActivityFlags.ClearTop);

            foreach (string key in data.Keys)
            {
                Log.Debug("Asawer", "Key: {0} Value: {1}", key, data[key]);
                intent.PutExtra(key, data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);

            var notificationBuilder = new NotificationCompat.Builder(this)
                .SetSmallIcon(Resource.Drawable.asawer_icon)
                .SetContentTitle(title)
                .SetContentText(body)
                .SetAutoCancel(true)
                .SetSound(defaultSoundUri)
                .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);
            
            notificationManager.Notify(0, notificationBuilder.Build());
        }
    }
}