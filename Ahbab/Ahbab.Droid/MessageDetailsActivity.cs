
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.IO;
using Newtonsoft.Json;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;
using SharedCode;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Asawer.Droid
{
    [Activity(Label = "MessageDetailsActivity", Theme = "@style/Theme.Ahbab")]
    public class MessageDetailsActivity : AppCompatActivity
    {
        public const string EXTRA_MESSAGE = "message";
        public const string EXTRA_HIDE_TEXT = "hideText";
        public const string EXTRA_MESSAGE_ID = "messageId";

        private Message message;
        private bool hideText;
        private bool MessageDeleted;

        private CardView bodyCard;
        private CardView audioCard;
        private string fileName;
        private bool startPlaying = false;
        private bool isPlaying = false;
        private MediaPlayer audioPlayer;
        private SeekBar seekBar;
        private Chronometer chronometer;
        private FloatingActionButton playAudioButton;
        private Java.Lang.Runnable runnable;
        private Handler mHandler = new Handler();
        private int lastProgress = 0;
        public string FileName { get => fileName; set => fileName = value; }
        public bool StartPlaying { get => startPlaying; set => startPlaying = value; }
        public CardView AudioCard { get => audioCard; set => audioCard = value; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
        public MediaPlayer AudioPlayer { get => audioPlayer; set => audioPlayer = value; }
        public SeekBar SeekBar { get => seekBar; set => seekBar = value; }
        public Chronometer Chronometer { get => chronometer; set => chronometer = value; }
        public FloatingActionButton PlayAudioButton { get => playAudioButton; set => playAudioButton = value; }
        public int LastProgress { get => lastProgress; set => lastProgress = value; }
        public CardView BodyCard { get => bodyCard; set => bodyCard = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MessageDetailsActivity);

            var toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            message = JsonConvert.DeserializeObject<Message>(this.Intent.GetStringExtra(EXTRA_MESSAGE));
            hideText = this.Intent.GetBooleanExtra(EXTRA_HIDE_TEXT, false);

            var collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolBar.Title = message.Subject;

            var sender = FindViewById<TextView>(Resource.Id.txtSender);

            var subject = FindViewById<TextView>(Resource.Id.txtSubject);

            var body = FindViewById<TextView>(Resource.Id.txtBody);

            this.AudioCard = this.FindViewById<CardView>(Resource.Id.audioCard);

            this.BodyCard = this.FindViewById<CardView>(Resource.Id.bodyCard);

            this.Chronometer = this.FindViewById<Chronometer>(Resource.Id.chronometerTimer);

            this.Chronometer.Base = SystemClock.ElapsedRealtime();

            this.SeekBar = this.FindViewById<SeekBar>(Resource.Id.seekBar);

            this.PlayAudioButton = this.FindViewById<FloatingActionButton>(Resource.Id.imageViewPlay);

            this.PlayAudioButton.Click += OnPlayAudioButtonClick;

            this.SeekBar.ProgressChanged += OnSeekBarProgressChanged;

            if (!this.hideText)
            {
                sender.Text = message.Username;
                subject.Text = message.Subject;

                if (!string.IsNullOrEmpty(message.Body))
                {
                    body.Text = message.Body;
                }
                else
                {
                    this.BodyCard.Visibility = ViewStates.Gone;
                }

                if (this.message.Sender != Ahbab.CurrentUser.ID)
                {
                    AhbabDatabase.UpdateMessageStatus(this.message.ID);
                }
            }
            else
            {
                this.Chronometer.ChronometerTick += OnChronometerTick;

                var titleRegisterButton = this.FindViewById<Button>(Resource.Id.titleRegisterButton);
                var bodyRegisterButton = this.FindViewById<Button>(Resource.Id.bodyRegisterButton);

                bodyRegisterButton.Click += OnRegisterButtonClick;
                titleRegisterButton.Click += OnRegisterButtonClick;

                bodyRegisterButton.Visibility = ViewStates.Visible;
                titleRegisterButton.Visibility = ViewStates.Visible;

                subject.Visibility = ViewStates.Gone;
                body.Visibility = ViewStates.Gone;
            }

            if (message.AudioMessage != null)
            {
                this.FileName = this.GetExternalFilesDir(Android.OS.Environment.DirectoryMusic).AbsolutePath;
                this.FileName += string.Format(@"/{0}{1}.3gp", Ahbab.CurrentUser.Name, DateTime.Now.ToShortTimeString());

                System.IO.File.WriteAllBytes(this.FileName, message.AudioMessage.FileBytes);

                this.AudioCard.Visibility = ViewStates.Visible;
            }

            this.LoadBackDrop();

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
        }

        private void OnRegisterButtonClick(object sender, EventArgs e)
        {
            this.PerformPurchase();
        }

        private void OnChronometerTick(object sender, EventArgs e)
        {
            var elapsedMillis = SystemClock.ElapsedRealtime() - this.Chronometer.Base;

            if (elapsedMillis >= 2000 && this.hideText)//Ahbab.CurrentUser.Gender.Equals("M") && Ahbab.CurrentUser.Paid == "N" && 
            {
                this.StopPlaying();

                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                alert.SetTitle(Constants.UI.Subscription);
                alert.SetMessage(Constants.UI.Upgrade);
                alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
                {
                    this.PerformPurchase();
                });

                alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) => { });

                Android.Support.V7.App.AlertDialog dialog = alert.Create();
                dialog.SetCanceledOnTouchOutside(false);
                dialog.SetCancelable(false);
                dialog.Show();
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.deleteMessage)
            {
                AhbabDatabase.DeleteMessage(Constants.Database.ApiFiles.DeleteMessageFileName, message.ID, OnDeleteMessageCompleted);

                return true;
            }
            else if (item.ItemId == Android.Resource.Id.Home)
            {
                this.Finish();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MessageDetailsMenu, menu);
            return true;
        }

        private void OnPlayAudioButtonClick(object sender, EventArgs e)
        {
            if (!this.IsPlaying)
            {
                this.PlayAudio();
            }
            else
            {
                this.StopPlaying();
            }
        }

        private void PlayAudio()
        {
            this.PlayAudioButton.SetImageDrawable(this.GetDrawable(Resource.Drawable.baseline_pause_24));

            this.AudioPlayer = new MediaPlayer();

            this.runnable = new Java.Lang.Runnable(SeekUpdation);

            this.SeekUpdation();

            if (System.IO.File.Exists(this.FileName))
            {
                FileInputStream fileInputStream = null;
                try
                {
                    this.Chronometer.Base = SystemClock.ElapsedRealtime();

                    using (fileInputStream = new FileInputStream(this.FileName))
                    {
                        this.AudioPlayer.SetDataSource(fileInputStream.FD);

                        this.AudioPlayer.Prepare();

                        this.AudioPlayer.Start();

                        this.SeekBar.Progress = this.lastProgress;

                        this.AudioPlayer.SeekTo(lastProgress);

                        this.SeekBar.Max = this.AudioPlayer.Duration;

                        this.Chronometer.Start();

                        this.IsPlaying = true;

                        this.AudioPlayer.Completion += OnAudioPlayerCompletion;
                    }
                }
                catch { }
            }
        }

        private void OnSeekBarProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            if (this.AudioPlayer != null && e.FromUser)
            {

                this.AudioPlayer.SeekTo(e.Progress);
                //timer is being updated as per the progress of the seekbar

                chronometer.Base = SystemClock.ElapsedRealtime() - this.AudioPlayer.CurrentPosition;

                lastProgress = e.Progress;
            }
        }

        private void OnAudioPlayerCompletion(object sender, EventArgs e)
        {
            if (!this.AudioPlayer.IsPlaying)
            {
                this.PlayAudioButton.SetImageDrawable(this.GetDrawable(Resource.Drawable.baseline_play_arrow_24));

                this.Chronometer.Stop();

                this.SeekBar.Progress = 0;

                this.IsPlaying = false;
            }
        }

        private void StopPlaying()
        {
            try
            {
                this.AudioPlayer.Stop();
                this.AudioPlayer.Release();
            }
            catch (Exception e)
            {

            }
            this.AudioPlayer = null;
            //showing the play button

            this.PlayAudioButton.SetImageDrawable(this.GetDrawable(Resource.Drawable.baseline_play_arrow_24));

            this.Chronometer.Stop();

            this.lastProgress = 0;

            this.SeekBar.Progress = 0;

            this.IsPlaying = false;
        }

        private void SeekUpdation()
        {
            if (this.AudioPlayer != null)
            {
                var mCurrentPosition = this.AudioPlayer.CurrentPosition;
                this.SeekBar.Progress = mCurrentPosition;
                this.lastProgress = mCurrentPosition;
            }

            mHandler.PostDelayed(runnable, 100);
        }

        private void OnDeleteMessageCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            var result = System.Text.Encoding.UTF8.GetString(e.Result);

            if (result.Contains("Successfully"))
            {
                this.MessageDeleted = true;

                Toast.MakeText(this, Constants.UI.MessageDeleted, ToastLength.Short).Show();
            }
        }

        private void LoadBackDrop()
        {
            ImageView imageView = FindViewById<ImageView>(Resource.Id.backdrop);
            imageView.SetImageResource(Messages.RandomMessagesDrawable);
        }

        public override void OnBackPressed()
        {
            this.StopPlaying();
            base.OnBackPressed();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
        }

        private async void PerformPurchase()
        {
            var succeeded = await this.PurchaseItem("asawer_yearly_subscription", "AsawerPayload");
        }

        public async Task<bool> PurchaseItem(string productId, string payload)
        {

            var supported = CrossInAppBilling.IsSupported;

            var billing = CrossInAppBilling.Current;

            try
            {
                var connected = await billing.ConnectAsync(ItemType.Subscription);

                if (!connected)
                {
                    //we are offline or can't connect, don't try to purchase
                    return false;
                }

                var product = await billing.GetProductInfoAsync(ItemType.Subscription, productId);

                //check purchases
                var purchase = await billing.PurchaseAsync(productId, ItemType.Subscription, payload);

                //possibility that a null came through.
                if (purchase == null)
                {
                    //did not purchase
                    return false;
                }
                else
                {
                    try
                    {
                        var result = AhbabDatabase.Subscribe(Ahbab.CurrentUser.ID);
                        if (result != null)
                        {
                            Ahbab.CurrentUser = result;
                        }
                    }
                    catch (Exception ex)
                    {
                        var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
                    }
                    return false;
                }
            }
            catch (InAppBillingPurchaseException purchaseEx)
            {
                //Billing Exception handle this based on the type
                return false;
            }
            catch (Exception ex)
            {
                //Something else has gone wrong, log it
                return false;
            }
            finally
            {
                await billing.DisconnectAsync();
            }
        }
    }
}

