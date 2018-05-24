
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

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
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Asawer.Droid
{
    [Activity(Label = "MessageDetailsActivity", Theme = "@style/Theme.Ahbab")]
    public class MessageDetailsActivity : AppCompatActivity
    {
        public const string EXTRA_MESSAGE = "message";

        private Message message;

        private bool MessageDeleted;

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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MessageDetailsActivity);

            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            message = JsonConvert.DeserializeObject<Message>(Intent.GetStringExtra(EXTRA_MESSAGE));

            CollapsingToolbarLayout collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolBar.Title = message.Subject;

            var sender = FindViewById<TextView>(Resource.Id.txtSender);
            var subject = FindViewById<TextView>(Resource.Id.txtSubject);
            var body = FindViewById<TextView>(Resource.Id.txtBody);
            this.AudioCard = this.FindViewById<CardView>(Resource.Id.audioCard);
            this.Chronometer = this.FindViewById<Chronometer>(Resource.Id.chronometerTimer);
            this.Chronometer.Base = SystemClock.ElapsedRealtime();
            this.SeekBar = this.FindViewById<SeekBar>(Resource.Id.seekBar);
            this.PlayAudioButton = this.FindViewById<FloatingActionButton>(Resource.Id.imageViewPlay);
            this.PlayAudioButton.SetBackgroundResource(Resource.Drawable.baseline_play_arrow_24);
            this.PlayAudioButton.Click += OnPlayAudioButtonClick;
            this.SeekBar.ProgressChanged += OnSeekBarProgressChanged;

            sender.Text = message.Username;
            subject.Text = message.Subject;
            body.Text = message.Body;

            if (message.AudioMessage != null)
            {
                this.FileName = this.GetExternalFilesDir(Android.OS.Environment.DirectoryMusic).AbsolutePath;
                this.FileName += string.Format(@"/{0}{1}.3gp", Ahbab.CurrentUser.Name, DateTime.Now.ToShortTimeString());

                System.IO.File.WriteAllBytes(this.FileName, message.AudioMessage.FileBytes);

                this.AudioCard.Visibility = ViewStates.Visible;

            }

            LoadBackDrop();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var mClient = new WebClient();
            NameValueCollection parameters = new NameValueCollection();
            switch (item.ItemId)
            {
                case Resource.Id.deleteMessage:
                    parameters.Add("messageId", message.ID.ToString());
                    mClient.UploadValuesCompleted += MClient_UploadValuesCompleted;
                    mClient.UploadValuesAsync(new Uri(Constants.FunctionsUri.DeleteMessageUri), parameters);
                    return true;
                case Android.Resource.Id.Home:
                    Finish();
                    break;
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
            this.PlayAudioButton.SetBackgroundResource(Resource.Drawable.baseline_pause_24);

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

                        this.SeekBar.SetProgress(this.lastProgress, true);

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
                this.PlayAudioButton.SetBackgroundResource(Resource.Drawable.baseline_play_arrow_24);

                this.Chronometer.Stop();

                this.SeekBar.SetProgress(0, true);

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
            
            this.PlayAudioButton.SetBackgroundResource(Resource.Drawable.baseline_play_arrow_24);

            this.Chronometer.Stop();

            this.lastProgress = 0;

            this.SeekBar.SetProgress(0, true);

            this.IsPlaying = false;
        }

        private void SeekUpdation()
        {
            if (this.AudioPlayer != null)
            {
                var mCurrentPosition = this.AudioPlayer.CurrentPosition;
                this.SeekBar.SetProgress(mCurrentPosition, true);
                this.lastProgress = mCurrentPosition;
            }

            mHandler.PostDelayed(runnable, 100);
        }

        void MClient_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
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
    }
}

