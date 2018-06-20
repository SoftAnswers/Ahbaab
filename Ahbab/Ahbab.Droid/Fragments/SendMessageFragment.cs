
using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.IO;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Asawer.Droid
{
    public class SendMessageFragment : AppCompatDialogFragment
    {
        private const string RecordAudioPermission = Manifest.Permission.RecordAudio;
        private SupportToolbar mToolbar;
        private TextInputLayout mSubjectInputLayout;
        private TextInputLayout mBodyInputLayout;
        private Button mSendMessage;
        private string mUserName;
        public EventHandler<OnSendMessageEventArgs> mOnSendMessageComplete;
        private Button recodButton;
        private MediaRecorder recorder;
        private MediaPlayer audioPlayer;
        private string fileName;
        public string FileName { get => fileName; set => fileName = value; }
        private bool startRecording = true;
        private bool startPlaying = false;
        public bool StartPlaying { get => startPlaying; set => startPlaying = value; }
        public bool StartRecording { get => startRecording; set => startRecording = value; }
        protected MediaRecorder Recorder { get => recorder; set => recorder = value; }
        protected MediaPlayer AudioPlayer { get => audioPlayer; set => audioPlayer = value; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation;

            Dialog.Window.RequestFeature(WindowFeatures.ActionBar);

            var view = inflater.Inflate(Resource.Layout.SendMessageFragment, container, false);

            mToolbar = view.FindViewById<SupportToolbar>(Resource.Id.dialogActionBar);

            mSubjectInputLayout = view.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutSubject);

            mBodyInputLayout = view.FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutBody);

            mSendMessage = view.FindViewById<Button>(Resource.Id.btnDialogSend);

            mSendMessage.Click += OnSendMessageClick;

            this.recodButton = view.FindViewById<Button>(Resource.Id.btnDialogRecord);

            this.recodButton.Click += this.OnRecordAudioClick;

            mUserName = Arguments.GetString("User");

            mToolbar.SetTitle(Resource.String.message);
            mToolbar.Title += string.Format(" {0}", mUserName);
            mToolbar.SetTitleTextColor(Android.Graphics.Color.White);

            this.FileName = this.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryMusic).AbsolutePath;
            this.FileName += string.Format(@"/{0}{1}.3gp", mUserName, DateTime.Now.ToShortTimeString());

            return view;
        }

        private void OnSendMessageClick(object sender, EventArgs e)
        {
            var messageSubject = this.mSubjectInputLayout.EditText.Text;
            var messageBody = this.mBodyInputLayout.EditText.Text;
            byte[] fileBytes = null;

            try
            {
                fileBytes = System.IO.File.ReadAllBytes(this.FileName);
            }
            catch 
            {
                
            }

            mOnSendMessageComplete.Invoke(this, new OnSendMessageEventArgs(messageSubject, messageSubject, fileBytes));

            this.Dismiss();
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
            if (this.Context.CheckSelfPermission(RecordAudioPermission) == (int)Permission.Granted)
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
                            Toast.MakeText(this.Context,
                                            "Audio record permission is available.",
                                            ToastLength.Short).Show();

                            this.Record(this.StartRecording);
                        }
                        else
                        {
                            //Permission Denied :(
                            //Disabling location functionality
                            Toast.MakeText(this.Context,
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
            }
            catch (Exception ex)
            {

            }
        }

        private void StopRecording()
        {
            this.Recorder.Stop();

            this.Recorder.Release();

            this.Recorder = null;

            if (System.IO.File.Exists(this.FileName))
            {
                this.PlayAudio();
            }
        }

        private void PlayAudio()
        {
            this.AudioPlayer = new MediaPlayer();

            FileInputStream fileInputStream = null;
            try
            {
                fileInputStream = new FileInputStream(this.FileName);

                this.AudioPlayer.SetDataSource(fileInputStream.FD);

                this.AudioPlayer.Prepare();

                this.AudioPlayer.Start();
            }
            finally
            {
                if (fileInputStream != null)
                {
                    try
                    {
                        fileInputStream.Close();
                    }
                    catch { }
                }
            }
        }
    }
}
