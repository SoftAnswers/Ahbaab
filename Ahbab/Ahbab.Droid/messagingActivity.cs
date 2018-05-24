using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Asawer.Entities;
using Java.IO;
using Newtonsoft.Json;
using SharedCode;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Asawer.Droid
{
    [Activity(Label = "messagingActivity", Theme = "@style/Theme.Ahbab.Transparent")]
    public class MessagingActivity : AppCompatActivity
    {
        public static readonly string EXTRA_CIRCULAR_REVEAL_X = "EXTRA_CIRCULAR_REVEAL_X";
        public static readonly string EXTRA_CIRCULAR_REVEAL_Y = "EXTRA_CIRCULAR_REVEAL_Y";
        public static readonly string EXTRA_USER = "EXTRA_USER";
        private const string RecordAudioPermission = Manifest.Permission.RecordAudio;

        private SupportToolbar toolbar;
        private TextInputLayout subjectInputLayout;
        private TextInputLayout bodyInputLayout;
        private Button sendMessageButton;
        private RelativeLayout rootLayout;
        private int revealX;
        private int revealY;
        private User user;
        private FloatingActionButton recodButton;
        private MediaRecorder recorder;
        private MediaPlayer audioPlayer;
        private string fileName;
        private bool startRecording = true;
        private bool startPlaying = false;
        private bool isPlaying = false;
        private LinearLayout linearLayoutPlay;
        private SeekBar seekBar;
        private Chronometer chronometer;
        private FloatingActionButton playAudioButton;
        private Java.Lang.Runnable runnable;
        private Handler mHandler = new Handler();
        private int lastProgress = 0;
        public string FileName { get => fileName; set => fileName = value; }
        public bool StartPlaying { get => startPlaying; set => startPlaying = value; }
        public bool StartRecording { get => startRecording; set => startRecording = value; }
        protected MediaRecorder Recorder { get => recorder; set => recorder = value; }
        protected MediaPlayer AudioPlayer { get => audioPlayer; set => audioPlayer = value; }
        public RelativeLayout RootLayout { get => rootLayout; set => rootLayout = value; }
        public int RevealX { get => revealX; set => revealX = value; }
        public int RevealY { get => revealY; set => revealY = value; }
        public User User { get => user; set => user = value; }
        public FloatingActionButton RecodButton { get => recodButton; set => recodButton = value; }
        public bool ActivityRevealed { get; set; }
        public SupportToolbar Toolbar { get => toolbar; set => toolbar = value; }
        public TextInputLayout SubjectInputLayout { get => subjectInputLayout; set => subjectInputLayout = value; }
        public TextInputLayout BodyInputLayout { get => bodyInputLayout; set => bodyInputLayout = value; }
        public Button SendMessageButton { get => sendMessageButton; set => sendMessageButton = value; }
        public SeekBar SeekBar { get => seekBar; set => seekBar = value; }
        public LinearLayout LinearLayoutPlay { get => linearLayoutPlay; set => linearLayoutPlay = value; }
        public Chronometer Chronometer { get => chronometer; set => chronometer = value; }
        public FloatingActionButton PlayAudioButton { get => playAudioButton; set => playAudioButton = value; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.messaging_activity);

            this.RootLayout = this.FindViewById<RelativeLayout>(Resource.Id.root_layout);

            InitializeActivity(savedInstanceState);

            this.SetTheme(Resource.Style.Theme_Ahbab);
        }

        private void InitializeActivity(Bundle savedInstanceState)
        {
            var intent = this.Intent;

            if (savedInstanceState == null && Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop &&
                intent.HasExtra(EXTRA_CIRCULAR_REVEAL_X) &&
                intent.HasExtra(EXTRA_CIRCULAR_REVEAL_Y))
            {
                rootLayout.Visibility = ViewStates.Invisible;

                this.RevealX = intent.GetIntExtra(EXTRA_CIRCULAR_REVEAL_X, 0);
                this.RevealY = intent.GetIntExtra(EXTRA_CIRCULAR_REVEAL_Y, 0);

                var viewTreeObserver = this.RootLayout.ViewTreeObserver;
                if (viewTreeObserver.IsAlive)
                {
                    viewTreeObserver.GlobalLayout += this.ViewTreeObserverGlobalLayoutHandler;
                }

            }
            else
            {
                rootLayout.Visibility = ViewStates.Visible;
            }

            this.Toolbar = this.FindViewById<SupportToolbar>(Resource.Id.toolBar);
            this.SubjectInputLayout = this.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutSubject);
            this.BodyInputLayout = this.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutBody);
            this.SendMessageButton = this.FindViewById<Button>(Resource.Id.btnSend);
            this.SendMessageButton.Click += OnSendMessageClick;
            this.RecodButton = this.FindViewById<FloatingActionButton>(Resource.Id.btnRecord);
            this.RecodButton.Click += this.OnRecordAudioClick;
            this.Chronometer = this.FindViewById<Chronometer>(Resource.Id.chronometerTimer);
            this.Chronometer.Base = SystemClock.ElapsedRealtime();
            this.SeekBar = this.FindViewById<SeekBar>(Resource.Id.seekBar);
            this.LinearLayoutPlay = this.FindViewById<LinearLayout>(Resource.Id.linearLayoutPlay);
            this.PlayAudioButton = this.FindViewById<FloatingActionButton>(Resource.Id.imageViewPlay);
            this.PlayAudioButton.SetImageResource(Resource.Drawable.baseline_play_arrow_24);
            this.PlayAudioButton.Click += OnPlayAudioButtonClick;
            this.User = JsonConvert.DeserializeObject<User>(intent.GetStringExtra(EXTRA_USER));
            this.Toolbar.SetTitle(Resource.String.message);
            this.Toolbar.Title += string.Format(" {0}", this.User.Name);
            this.Toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            this.FileName = this.GetExternalFilesDir(Android.OS.Environment.DirectoryMusic).AbsolutePath;
            this.FileName += string.Format(@"/{0}.mp3", this.User.Name);
            this.SeekBar.ProgressChanged += OnSeekBarProgressChanged;
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

        private void ViewTreeObserverGlobalLayoutHandler(object sender, EventArgs e)
        {
            if (!this.ActivityRevealed)
            {
                this.RevealActivity(this.RevealX, this.RevealY);
            }
        }

        protected void RevealActivity(int x, int y)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var finalRadius = (float)(Math.Max(rootLayout.Width, rootLayout.Height) * 1.1);

                // create the animator for this view (the start radius is zero)
                var circularReveal = ViewAnimationUtils.CreateCircularReveal(this.RootLayout, x, y, 0, finalRadius);
                circularReveal.SetDuration(700);
                circularReveal.SetInterpolator(new AccelerateInterpolator());

                // make the view visible and start the animation
                circularReveal.Start();
                this.RootLayout.Visibility = ViewStates.Visible;
            }
            else
            {
                this.Finish();
            }
            this.ActivityRevealed = true;
        }

        protected void UnRevealActivity()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                this.Finish();
            }
            else
            {
                var finalRadius = (float)(Math.Max(rootLayout.Width, rootLayout.Height) * 1.1);
                Animator circularReveal = ViewAnimationUtils.CreateCircularReveal(
                        rootLayout, revealX, revealY, finalRadius, 0);

                circularReveal.SetDuration(400);

                circularReveal.AddListener(new AnimatorAdapter(this.RootLayout, this));

                circularReveal.Start();
            }
        }

        private void OnSendMessageClick(object sender, EventArgs e)
        {
            var messageSubject = this.SubjectInputLayout.EditText.Text;

            if (!string.IsNullOrEmpty(messageSubject))
            {
                var messageBody = this.BodyInputLayout.EditText.Text;
                var audioFile = new UserFile(new byte[0], string.Empty, string.Empty);

                try
                {
                    audioFile.FileBytes = System.IO.File.ReadAllBytes(this.FileName);
                    audioFile.FileName = System.IO.Path.GetFileName(this.FileName);
                    audioFile.FileExtension = System.IO.Path.GetExtension(this.FileName);
                }
                catch (Exception ex)
                {

                }

                this.SendMessage(messageSubject, messageBody, audioFile);
            }
            else
            {
                this.SubjectInputLayout.Error = "الرجاء إدخال الموضوع";
                this.SubjectInputLayout.SetBackgroundColor(Android.Graphics.Color.White);
            }
        }

        private void SendMessage(string subject, string body, UserFile audio)
        {
            var message = new Message
            {
                body = body,
                subject = subject,
                from_account = Ahbab.CurrentUser.ID,
                to_account = user.ID,
                audio_message = audio
            };

            var result = AhbabDatabase.SendMessage(message, user.Gender);

            if (result.ToLower().Contains("success"))
            {
                Toast.MakeText(this, "Message sent successfully.", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Failed to send message.", ToastLength.Short).Show();
            }
        }

        private void OnRecordAudioClick(object sender, EventArgs args)
        {
            if (EnsureRecordAudioPermissions())
            {
                this.Record(this.StartRecording);
            }
        }

        internal bool EnsureRecordAudioPermissions()
        {
            if (this.CheckSelfPermission(RecordAudioPermission) == (int)Permission.Granted)
            {
                return true;
            }

            RequestPermissions(new string[] { RecordAudioPermission }, 0);

            return false;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case 0:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                            //Permission granted
                            Toast.MakeText(this,
                                            "Audio record permission is available.",
                                            ToastLength.Short).Show();

                            this.Record(this.StartRecording);
                        }
                        else
                        {
                            //Permission Denied :(
                            //Disabling location functionality
                            Toast.MakeText(this,
                                            "Audio record permission denied.",
                                            ToastLength.Short).Show();
                        }
                    }
                    break;
            }
        }

        protected void Record(bool start)
        {
            if (start)
            {
                this.StartRecordingAudio();
            }
            else
            {
                this.StopRecording();
            }
        }

        protected void StartRecordingAudio()
        {
            this.StartRecording = false;

            this.RecodButton.SetImageResource(Resource.Drawable.baseline_mic_off_white_18);

            try
            {
                this.Recorder = new MediaRecorder(); // Initial state.
                this.Recorder.Reset();
                this.Recorder.SetAudioSource(AudioSource.Mic);
                this.Recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                this.Recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                // Initialized state.
                this.Recorder.SetOutputFile(this.FileName);
                // DataSourceConfigured state.
                this.Recorder.Prepare(); // Prepared state
                this.Recorder.Start(); // Recording state.

                this.lastProgress = 0;
                this.SeekBar.SetProgress(0, true);
                //stopPlaying();
                //starting the chronometer
                this.Chronometer.Base = SystemClock.ElapsedRealtime();
                this.Chronometer.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void StopRecording()
        {
            this.RecodButton.SetImageResource(Resource.Drawable.baseline_mic_white_18);

            this.Recorder.Stop();

            this.Recorder.Release();

            this.Recorder = null;

            this.Chronometer.Stop();

            this.Chronometer.Base = SystemClock.ElapsedRealtime();

            this.StartRecording = true;

            this.PlayAudioButton.Visibility = ViewStates.Visible;
        }

        private void PlayAudio()
        {
            this.PlayAudioButton.SetImageResource(Resource.Drawable.baseline_pause_24);

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
                this.PlayAudioButton.SetImageResource(Resource.Drawable.baseline_play_arrow_24);

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
            this.PlayAudioButton.SetImageResource(Resource.Drawable.baseline_play_arrow_24);

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

        private class AnimatorAdapter : AnimatorListenerAdapter
        {
            private View rootLayout;
            private Activity activity;
            public View RootLayout { get => rootLayout; set => rootLayout = value; }
            public Activity Activity { get => activity; set => activity = value; }

            public AnimatorAdapter(View view, Activity activity)
            {
                this.RootLayout = view;
                this.Activity = activity;
            }

            public override void OnAnimationEnd(Animator animation)
            {
                this.RootLayout.Visibility = ViewStates.Visible;
                //this.Activity.Finish();
            }
        }
    }
}