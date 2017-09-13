using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using System.Threading;
using Ahbab.Entities;
using Newtonsoft.Json;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Net.Wifi;
using SharedCode;
using System.IO;
using Android.Graphics;
using Android.Provider;
using Uri = Android.Net.Uri;

namespace Ahbab.Droid
{
    [Activity(Label = "@string/register", Theme = "@style/Theme.Ahbab")]
    public class RegisterActivity : AppCompatActivity
    {
        private static readonly int REQUEST_CAMERA = 0;
        private static readonly int SELECT_FILE = 1;
        private Spinner mStatusSpinner;
        private Spinner mAgeSpinner;
        private Spinner mContactTimeSpinner;
        private Spinner mEducationSpinner;
        private Spinner mEyesColorSpinner;
        private Spinner mGoalFromSiteSpinner;
        private Spinner mHairColorSpinner;
        private Spinner mHeightSpinner;
        private Spinner mJobSpinner;
        private Spinner mOriginCountrySpinner;
        private Spinner mResidentCountrySpinner;
        private Spinner mTimeSpinner;
        private Spinner mWeightSpinner;
        private Button mRegisterButton;
        private Button mUpdateButton;
        private TextInputLayout mUserNameInputLayout;
        private TextInputLayout mPasswordInputLayout;
        private TextInputLayout mFullNameInputLayout;
        private TextInputLayout mEmailInputLayout;
        private TextInputLayout mSelfDescriptionInputLayout;
        private TextInputLayout mPartnerDescriptionInputLayout;
        private RadioGroup mSex;
        private ImageView mUploadImage;
        private DrawerLayout mDrawerLayout;
        private CustomSpinnerAdapter mStatusAdapter;
        private CustomSpinnerAdapter mAgeAdapter;
        private CustomSpinnerAdapter mContactTimeAdapter;
        private CustomSpinnerAdapter mEducationAdapter;
        private CustomSpinnerAdapter mEyesColorAdapter;
        private CustomSpinnerAdapter mGoalFromSiteAdapter;
        private CustomSpinnerAdapter mHairColorAdapter;
        private CustomSpinnerAdapter mHeightAdapter;
        private CustomSpinnerAdapter mJobAdapter;
        private CustomSpinnerAdapter mCountriesAdapter;
        private CustomSpinnerAdapter mResidenceCountriesAdapter;
        private CustomSpinnerAdapter mTimeAdapter;
        private CustomSpinnerAdapter mWeightAdapter;
        private CheckBox check;
        private EditText ContactWay;
        private LinearLayout mContactWaysLayout;
        private LinearLayout mGalleryLayout;
        private List<UserImage> UserImages = new List<UserImage>();
        private List<UserImage> UserImagesToDelete = new List<UserImage>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.Register);

            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolBar);

            SetSupportActionBar(toolbar);

            SupportActionBar ab = SupportActionBar;

            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            ab.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }

            InitiateComponents();

            BindValues();

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
            }

            if (Ahbab.CurrentUser != null)
            {
                SetCurrentUserData();

                this.mRegisterButton.Visibility = ViewStates.Gone;

                this.mUpdateButton.Visibility = ViewStates.Visible;

                if (Ahbab.CurrentUser.Paid == "N")
                {
                    Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                    alert.SetTitle(Constants.UI.Subscription);
                    alert.SetMessage(Constants.UI.Upgrade);
                    alert.SetPositiveButton(Constants.UI.Subscribe, (senderAlert, args) =>
                    {
                        //TODO: Set up payment
                    });

                    alert.SetNegativeButton(Constants.UI.Cancel, (senderAlert, args) =>
                    {
                        var intent = new Intent(this, typeof(MainPageActivity))
                       .SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                    });

                    Android.Support.V7.App.AlertDialog dialog = alert.Create();
                    dialog.SetCanceledOnTouchOutside(false);
                    dialog.SetCancelable(false);
                    dialog.Show();
                }
            }
        }

        public void SetCurrentUserData()
        {
            this.mStatusSpinner.SetSelection(this.mStatusAdapter.GetPosition(Ahbab.statusItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.Status
            )));

            this.mAgeSpinner.SetSelection(this.mAgeAdapter.GetPosition(Ahbab.mAgeItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.Age
            )));

            this.mContactTimeSpinner.SetSelection(this.mContactTimeAdapter.GetPosition(Ahbab.mContactTimeItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.TimeFrameId
            )));

            this.mEducationSpinner.SetSelection(this.mEducationAdapter.GetPosition(Ahbab.mEducationItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.EducationLevelID
            )));

            this.mEyesColorSpinner.SetSelection(this.mEyesColorAdapter.GetPosition(Ahbab.mEyesColorItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.EyesColorId
            )));

            this.mGoalFromSiteSpinner.SetSelection(this.mGoalFromSiteAdapter.GetPosition(Ahbab.mGoalFromSiteItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.UsagePurposeId
            )));

            this.mHairColorSpinner.SetSelection(this.mHairColorAdapter.GetPosition(Ahbab.mHairColorItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.HairColorId
            )));

            this.mHeightSpinner.SetSelection(this.mHeightAdapter.GetPosition(Ahbab.mHeightItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.HeightId
            )));

            this.mJobSpinner.SetSelection(this.mJobAdapter.GetPosition(Ahbab.mJobItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.JobId
            )));

            this.mOriginCountrySpinner.SetSelection(this.mCountriesAdapter.GetPosition(Ahbab.mCountries.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.OriginCountryId
            )));

            this.mResidentCountrySpinner.SetSelection(this.mCountriesAdapter.GetPosition(Ahbab.mCountries.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.CurrentCountryId
            )));

            this.mTimeSpinner.SetSelection(this.mTimeAdapter.GetPosition(Ahbab.mTimeItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.TimeZoneId
            )));

            this.mWeightSpinner.SetSelection(this.mWeightAdapter.GetPosition(Ahbab.mWeightItems.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.WeightId
            )));

            if (Ahbab.CurrentUser.Gender == "M")
            {
                this.mSex.Check(Resource.Id.rdbMale);
            }
            else
            {
                this.mSex.Check(Resource.Id.rdbFemale);
            }

            // Adding the picture when found
            if (Ahbab.CurrentUser.ImageBytes != null) {
                if (Ahbab.CurrentUser.ImageBytes.Count >= 5)
                    this.mUploadImage.Visibility = ViewStates.Gone;
                for (int i = 0; i < Ahbab.CurrentUser.ImageBytes.Count; i++) {
                    var imageView = new ImageView(this);
                    imageView.Id = i;
                    LinearLayout.LayoutParams parame = new LinearLayout.LayoutParams(mUploadImage.Width, 300, 25f);
                    imageView.LayoutParameters = parame;
                    imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                    imageView.SetAdjustViewBounds(true);
                    imageView.SetImageBitmap(BitmapFactory.DecodeByteArray(Ahbab.CurrentUser.ImageBytes[i], 0, Ahbab.CurrentUser.ImageBytes[i].Length));
                    this.mGalleryLayout.AddView(imageView);
                    imageView.Click += imageView_Click;
                }
            }

            for (int i = 0; i < Ahbab.CurrentUser.ContactWays.Count; i++) {
                for (int j = 0; j < mContactWaysLayout.ChildCount; j++) {
                    var currentItem = mContactWaysLayout.GetChildAt(j);
                    if (currentItem is CheckBox && currentItem.Id == Ahbab.CurrentUser.ContactWays[i].way_id) {
                        var check = (CheckBox)mContactWaysLayout.GetChildAt(j);
                        check.Checked = true;
                    }
                }
            }

            this.mUserNameInputLayout.EditText.Text = Ahbab.CurrentUser.UserName;
            this.mEmailInputLayout.EditText.Text = Ahbab.CurrentUser.Email;
            this.mPasswordInputLayout.EditText.Text = Ahbab.CurrentUser.Password;
            this.mFullNameInputLayout.EditText.Text = Ahbab.CurrentUser.Name;
            this.mSelfDescriptionInputLayout.EditText.Text = Ahbab.CurrentUser.SelfDescription;
            this.mPartnerDescriptionInputLayout.EditText.Text = Ahbab.CurrentUser.OthersDescription;

        }
        // Function used to remove the image from the view and add it to the List to be deleted
        void imageView_Click(object sender, EventArgs e) {
            var imageView = sender as ImageView;
            var image = this.UserImages.Find(userImage => userImage.FileName.Equals(imageView.TransitionName));
            if (image != null) {
                this.UserImages.RemoveAt(imageView.Id);
            } else {
                var imageName = Ahbab.CurrentUser.ImageNames[imageView.Id];
                this.UserImagesToDelete.Add(new UserImage(null, imageName, "jpg"));
            }
            this.mGalleryLayout.RemoveView(imageView);
        }

        void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                if (e.MenuItem.ItemId != Resource.Id.contactUs)
                {
                    OpenLegalNotesFragment(e.MenuItem);
                    mDrawerLayout.CloseDrawers();
                }
                else
                {
                    var email = new Intent(Intent.ActionSend);
                    email.PutExtra(Intent.ExtraEmail, new string[] { "info@ahbaab.com" });
                    email.SetType("message/rfc822");
                    StartActivity(email);
                }
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Right);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void InitiateComponents()
        {
            this.mRegisterButton = this.FindViewById<Button>(Resource.Id.btnRegister);

            this.mStatusSpinner = this.FindViewById<Spinner>(Resource.Id.statusSpinner);

            this.mAgeSpinner = this.FindViewById<Spinner>(Resource.Id.ageSpinner);

            this.mContactTimeSpinner = this.FindViewById<Spinner>(Resource.Id.contactTimeSpinner);

            this.mEducationSpinner = this.FindViewById<Spinner>(Resource.Id.educationSpinner);

            this.mEyesColorSpinner = this.FindViewById<Spinner>(Resource.Id.eyesColorSpinner);

            this.mGoalFromSiteSpinner = this.FindViewById<Spinner>(Resource.Id.goalFromSiteSpinner);

            this.mHairColorSpinner = this.FindViewById<Spinner>(Resource.Id.hairColorSpinner);

            this.mHeightSpinner = this.FindViewById<Spinner>(Resource.Id.heightSpinner);

            this.mJobSpinner = this.FindViewById<Spinner>(Resource.Id.jobSpinner);

            this.mOriginCountrySpinner = this.FindViewById<Spinner>(Resource.Id.originCountrySpinner);

            this.mResidentCountrySpinner = this.FindViewById<Spinner>(Resource.Id.residentCountrySpinner);

            this.mTimeSpinner = this.FindViewById<Spinner>(Resource.Id.timeSpinner);

            this.mWeightSpinner = this.FindViewById<Spinner>(Resource.Id.weightSpinner);

            this.mUpdateButton = this.FindViewById<Button>(Resource.Id.btnUpdate);

            this.mSex = FindViewById<RadioGroup>(Resource.Id.rdgSex);

            this.mContactWaysLayout = FindViewById<LinearLayout>(Resource.Id.contactWays);

            this.mGalleryLayout = FindViewById<LinearLayout>(Resource.Id.galleryLayout);

            this.mUserNameInputLayout = FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutUserName);

            this.mEmailInputLayout = FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutEmail);

            this.mPasswordInputLayout = FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutPassword);

            this.mFullNameInputLayout = FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutFullName);

            this.mSelfDescriptionInputLayout = FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutSelfDescription);

            this.mPartnerDescriptionInputLayout = FindViewById<TextInputLayout>(Resource.Id.txtInputLayoutPartnerDescription);

            this.mUploadImage = FindViewById<ImageView>(Resource.Id.imgPic);

            for (int i = 0; i < Ahbab.mContactWays.Count; i++)
            {
                check = new CheckBox(this);
                check.Id = Ahbab.mContactWays[i].ID;
                check.Text = Ahbab.mContactWays[i].DescriptionAR;
                check.CheckedChange += Check_CheckedChange;
                ContactWay = new EditText(this);
                ContactWay.Id = Ahbab.mContactWays[i].ID;
                ContactWay.Hint = Ahbab.mContactWays[i].DescriptionAR;
                ContactWay.Visibility = ViewStates.Gone; ;
                mContactWaysLayout.AddView(check);
                mContactWaysLayout.AddView(ContactWay);
            }

            mRegisterButton.Click += MRegisterButton_Click;

            mUploadImage.Click += MUploadImage_Click;

            mUpdateButton.Click += MUpdateButton_Click;
        }

        void Check_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            var currentCheckBox = sender as CheckBox;
            var id = currentCheckBox.Id;
            var count = mContactWaysLayout.ChildCount;

            var gender = string.Empty;

            if (mSex.CheckedRadioButtonId == Resource.Id.rdbMale)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }

            if (e.IsChecked && gender == "F")
            {

                for (int i = 0; i < count; i++)
                {
                    var currentChild = mContactWaysLayout.GetChildAt(i);

                    if (currentChild is EditText && currentChild.Id == id)
                    {
                        currentChild.Visibility = ViewStates.Visible;
                    }
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    var currentChild = mContactWaysLayout.GetChildAt(i);

                    if (currentChild is EditText && currentChild.Id == id)
                    {
                        currentChild.Visibility = ViewStates.Gone;
                    }
                }
            }
        }

        void MRegisterButton_Click(object sender, EventArgs e)
        {
            var validInput = ValidateDataInput();

            if (validInput)
            {
                var registrationSuccessfull = false;
                ProgressDialog progress = new ProgressDialog(this);
                progress.Indeterminate = true;
                progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                progress.SetMessage(Constants.UI.RegistrationLoader);
                progress.SetCancelable(false);
                progress.Show();

                var userInput = GetUserInput();

                new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            var resultString = AhbabDatabase.RegisterOrUpdate(Constants.FunctionsUri.RegisterUri, userInput);

                            if (!string.IsNullOrEmpty(resultString))
                            {
                                var result = JsonConvert.DeserializeObject<List<User>>(resultString);

                                Ahbab.CurrentUser = result.FirstOrDefault();

                                Intent mainPageIntent = new Intent(this, typeof(MainPageActivity));

                                this.StartActivity(mainPageIntent);

                                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                                               Android.Resource.Animation.SlideOutRight);

                                registrationSuccessfull = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            registrationSuccessfull = false;
                        }

                        RunOnUiThread(() =>
                        {
                            if (registrationSuccessfull)
                            {
                                Toast.MakeText(this,
                                               Constants.UI.SuccessfullRegistration,
                                               ToastLength.Short).Show();
                            }
                            else
                            {
                                Toast.MakeText(this,
                                                   Constants.UI.ErrorOccured,
                                                   ToastLength.Short).Show();
                            }

                            //HIDE PROGRESS DIALOG
                            progress.Hide();
                        });
                    })).Start();
            }
        }

        void MUpdateButton_Click(object sender, EventArgs e)
        {
            var validInput = ValidateDataInput();

            var updateSuccessfull = false;

            if (validInput)
            {
                ProgressDialog progress = new ProgressDialog(this);
                progress.Indeterminate = true;
                progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                progress.SetMessage(Constants.UI.UpdateLoader);
                progress.SetCancelable(false);
                progress.Show();

                var userInput = GetUserInput();

                //var valueToUpload = JsonConvert.SerializeObject(userInput);

                new Thread(new ThreadStart(() => {
                    try
                    {
                        string resultString = null;
                        if (this.UserImagesToDelete.Count > 0)
                            resultString  = AhbabDatabase.RegisterOrUpdate(Constants.FunctionsUri.UpdateUri, userInput, this.UserImagesToDelete);
                        else
                            resultString = AhbabDatabase.RegisterOrUpdate(Constants.FunctionsUri.UpdateUri, userInput);

                        if (!string.IsNullOrEmpty(resultString)) {
                            var result = JsonConvert.DeserializeObject<List<User>>(resultString);
                            Ahbab.CurrentUser = result.FirstOrDefault();
                            Intent mainPageIntent = new Intent(this, typeof(MainPageActivity));
                            this.StartActivity(mainPageIntent);
                            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
                            updateSuccessfull = true;
                        }
                    } catch (Exception ex) {
                        updateSuccessfull = false;
                    }

                    RunOnUiThread(() =>
                    {
                        if (updateSuccessfull)
                        {
                            Toast.MakeText(this, Constants.UI.SuccessfullUpdate, ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, Constants.UI.ErrorOccured, ToastLength.Short).Show();
                        }
                        //HIDE PROGRESS DIALOG
                        progress.Hide();
                    });
                })).Start();
            }
        }

        User GetUserInput()
        {
            var currentUser = new User();

            currentUser.ID = Ahbab.CurrentUser.ID;
            currentUser.UserName = mUserNameInputLayout.EditText.Text;
            currentUser.Name = mFullNameInputLayout.EditText.Text;
            currentUser.Password = mPasswordInputLayout.EditText.Text;
            currentUser.Email = mEmailInputLayout.EditText.Text;
            currentUser.SelfDescription = mSelfDescriptionInputLayout.EditText.Text;
            currentUser.OthersDescription = mPartnerDescriptionInputLayout.EditText.Text;
            currentUser.Age = mAgeAdapter.GetItemAtPosition(mAgeSpinner.SelectedItemPosition).ID;
            currentUser.BlocksFrom = 0;
            currentUser.BlocksTo = 0;
            currentUser.CreatedOn = DateTime.Today;
            currentUser.LastActiveDate = DateTime.Today;
            currentUser.CurrentCountryId = mCountriesAdapter.GetItemAtPosition(mResidentCountrySpinner.SelectedItemPosition).ID;
            currentUser.EducationLevelID = mEducationAdapter.GetItemAtPosition(mEducationSpinner.SelectedItemPosition).ID;
            currentUser.EyesColorId = mEyesColorAdapter.GetItemAtPosition(mEyesColorSpinner.SelectedItemPosition).ID;
            currentUser.HairColorId = mHairColorAdapter.GetItemAtPosition(mHairColorSpinner.SelectedItemPosition).ID;
            currentUser.HeightId = mHeightAdapter.GetItemAtPosition(mHeightSpinner.SelectedItemPosition).ID;
            currentUser.InterestsFrom = 0;
            currentUser.InterestsTo = 0;
            WifiManager wifiManager = (WifiManager)this.GetSystemService(WifiService);
            int ip = wifiManager.ConnectionInfo.IpAddress;
            currentUser.IP = ip.ToString();
            currentUser.JobId = mJobAdapter.GetItemAtPosition(mJobSpinner.SelectedItemPosition).ID;
            currentUser.LastActiveDate = DateTime.Today;
            currentUser.NumberOfLogins = 1;
            currentUser.OriginCountryId = mCountriesAdapter.GetItemAtPosition(mOriginCountrySpinner.SelectedItemPosition).ID;
            currentUser.OthersDescription = mPartnerDescriptionInputLayout.EditText.Text;
            currentUser.Status = mStatusAdapter.GetItemAtPosition(mStatusSpinner.SelectedItemPosition).ID;
            currentUser.Paid = "N";
            currentUser.PaidEndDate = DateTime.Today;
            currentUser.PaidStartDate = DateTime.Today;
            currentUser.SelfDescription = mSelfDescriptionInputLayout.EditText.Text;
            currentUser.TimeFrameId = mContactTimeAdapter.GetItemAtPosition(mContactTimeSpinner.SelectedItemPosition).ID;
            currentUser.TimeZoneId = mTimeAdapter.GetItemAtPosition(mTimeSpinner.SelectedItemPosition).ID;
            currentUser.UsagePurposeId = mGoalFromSiteAdapter.GetItemAtPosition(mGoalFromSiteSpinner.SelectedItemPosition).ID;
            currentUser.WeightId = mWeightAdapter.GetItemAtPosition(mWeightSpinner.SelectedItemPosition).ID;
            currentUser.VisitCountFrom = 0;
            currentUser.VisitCountTo = 0;

            currentUser.Images = this.UserImages;

            if (mSex.CheckedRadioButtonId == Resource.Id.rdbMale)
            {
                currentUser.Gender = "M";
            }
            else
            {
                currentUser.Gender = "F";
            }

            var waysCount = mContactWaysLayout.ChildCount;
            var registerContactWays = new List<ContactWay>();

            for (int i = 0; i < waysCount; i++)
            {
                var cWay = new ContactWay();
                var currentChild = mContactWaysLayout.GetChildAt(i);

                if (currentChild is CheckBox)
                {
                    var currentChecBox = (CheckBox)mContactWaysLayout.GetChildAt(i);

                    if (currentChecBox.Checked)
                    {
                        cWay.way_id = currentChecBox.Id;
                        cWay.way_value = GetWayValue(i);
                        registerContactWays.Add(cWay);
                    }
                }
            }
            currentUser.ContactWays = registerContactWays;
            return currentUser;
        }

        string GetWayValue(int id)
        {
            var retVal = string.Empty;

            var waysCount = mContactWaysLayout.ChildCount;

            for (int i = 0; i < waysCount; i++)
            {
                var currentChild = mContactWaysLayout.GetChildAt(i);

                if (currentChild is EditText && currentChild.Id == id)
                {
                    retVal = (currentChild as EditText).Text;
                }
            }

            return retVal;
        }

        bool ValidateDataInput()
        {
            var validInput = false;

            if (string.IsNullOrEmpty(mUserNameInputLayout.EditText.Text))
            {
                mUserNameInputLayout.Error = "Can't leave this empty";
                validInput = false;
            }
            else
            {
                validInput = true;
            }

            if (string.IsNullOrEmpty(mPasswordInputLayout.EditText.Text))
            {
                mPasswordInputLayout.Error = "Can't leave this empty";
            }
            else
            {
                validInput = true;
            }
            if (string.IsNullOrEmpty(mFullNameInputLayout.EditText.Text))
            {
                mFullNameInputLayout.Error = "Can't leave this empty";
            }
            else
            {
                validInput = true;
            }
            if (string.IsNullOrEmpty(mEmailInputLayout.EditText.Text))
            {
                mEmailInputLayout.Error = "Can't leave this empty";
            }
            else
            {
                validInput = true;
            }

            return validInput;
        }

        void MUploadImage_Click(object sender, EventArgs e)
        {
            using (var dialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(this))
            {
                String[] items =
                {
                    Constants.TabsNames.FromCamera,
                    Constants.TabsNames.FromGallery,
                    Constants.TabsNames.Cancel
                };

                dialogBuilder.SetTitle(Constants.TabsNames.AddPhoto);
                dialogBuilder.SetItems(items, (d, args) =>
                {
                    //Take photo
                    if (args.Which == 0)
                    {
                        Intent intent = new Intent(MediaStore.ActionImageCapture);
                        App._file = new Java.IO.File(App._dir, string.Format("Ahbab_{0}.jpg", Guid.NewGuid()));
                        intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
                        StartActivityForResult(intent, 0);
                    }
                    //Choose from gallery
                    else if (args.Which == 1)
                    {
                        var intent = new Intent(Intent.ActionPick, MediaStore.Images.Media.ExternalContentUri);
                        intent.SetType("image/*");
                        intent.PutExtra(Intent.ExtraAllowMultiple, true);
                        intent.SetAction(Intent.ActionGetContent);
                        this.StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), SELECT_FILE);
                    }
                });

                dialogBuilder.Show();
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            var height = Resources.DisplayMetrics.HeightPixels;

            var width = mUploadImage.Width;

            if (resultCode == Result.Ok) {
                if (this.mGalleryLayout.ChildCount >= 5)
                    this.mUploadImage.Visibility = ViewStates.Gone;

                if (requestCode == REQUEST_CAMERA)
                {
                    // Handle the newly captured image
                    var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);

                    var contentUri = Uri.FromFile(App._file);

                    mediaScanIntent.SetData(contentUri);

                    SendBroadcast(mediaScanIntent);

                    App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);

                    if (App.bitmap != null)
                    {
                        var img = App.bitmap;
                        var fileName = App._file.Name;
                        var fileExtension = "jpg";
                        var imageView = new ImageView(this);
                        LinearLayout.LayoutParams parame = new LinearLayout.LayoutParams(width, 300, 25f);
                        imageView.LayoutParameters = parame;
                        imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                        imageView.SetAdjustViewBounds(true);
                        imageView.SetImageBitmap(img);
                        this.mGalleryLayout.AddView(imageView);
                        MemoryStream memStream = new MemoryStream();
                        img.Compress(Bitmap.CompressFormat.Jpeg, 100, memStream);
                        byte[] picData = memStream.ToArray();

                        this.UserImages.Add(new UserImage(picData, fileName, fileExtension));
                        // Using transition name just to hold the image name in case we want to delete it
                        imageView.TransitionName = fileName;
                        imageView.Click += imageView_Click;
                        App.bitmap = null;
                    }

                    // Dispose of the Java side bitmap.
                    GC.Collect();
                }
                else if (requestCode == SELECT_FILE)
                {
                    var clipData = data.ClipData;

                    if (clipData != null)
                    {
                        for (int i = 0; i < clipData.ItemCount; i++)
                        {

                            if (i > 5)
                            {
                                break;
                            }

                            ClipData.Item item = clipData.GetItemAt(i);
                            global::Android.Net.Uri uri = item.Uri;

                            //In case you need image's absolute path
                            var fileName = System.IO.Path.GetFileName(GetFilePath(uri));
                            var fileExtension = System.IO.Path.GetExtension(uri.ToString());

                            var currentImage = BitmapHelpers.DecodeBitmapFromStream(this, uri, width, height);

                            MemoryStream memStream = new MemoryStream();
                            currentImage.Compress(Bitmap.CompressFormat.Jpeg, 100, memStream);
                            byte[] picData = memStream.ToArray();

                            this.UserImages.Add(new UserImage(picData, fileName, fileExtension));

                            var imageView = new ImageView(this);
                            LinearLayout.LayoutParams parame = new LinearLayout.LayoutParams(width, 300, 25f);
                            imageView.LayoutParameters = parame;
                            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                            imageView.SetAdjustViewBounds(true);
                            imageView.SetImageBitmap(currentImage);
                            this.mGalleryLayout.AddView(imageView);
                            // Using transition name just to hold the image name in case we want to delete it
                            imageView.TransitionName = fileName;
                            imageView.Click += imageView_Click;
                        }
                    }
                    else
                    {
                        var img = BitmapHelpers.DecodeBitmapFromStream(this, data.Data, width, height);
                        var fileName = System.IO.Path.GetFileName(data.Data.ToString());
                        var fileExtension = System.IO.Path.GetExtension(data.Data.ToString());
                        if (img != null)
                        {
                            var imageView = new ImageView(this);
                            LinearLayout.LayoutParams parame = new LinearLayout.LayoutParams(width, 300, 25f);
                            imageView.LayoutParameters = parame;
                            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                            imageView.SetAdjustViewBounds(true);
                            imageView.SetImageBitmap(img);
                            this.mGalleryLayout.AddView(imageView);
                            MemoryStream memStream = new MemoryStream();
                            img.Compress(Bitmap.CompressFormat.Jpeg, 100, memStream);
                            byte[] picData = memStream.ToArray();

                            this.UserImages.Add(new UserImage(picData, fileName, fileExtension));
                            // Using transition name just to hold the image name in case we want to delete it
                            imageView.TransitionName = fileName;
                            imageView.Click += imageView_Click;
                        }
                    }
                }
            }
        }

        private string GetFilePath(Android.Net.Uri uri)
        {
            string[] proj = { MediaStore.Images.ImageColumns.Data };
            //Deprecated
            //var cursor = ManagedQuery(uri, proj, null, null, null);
            var cursor = ContentResolver.Query(uri, proj, null, null, null);
            var colIndex = cursor.GetColumnIndex(MediaStore.Images.ImageColumns.Data);
            cursor.MoveToFirst();
            return cursor.GetString(colIndex);
        }

        private void BindValues()
        {
            mStatusAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.statusItems);
            mStatusSpinner.Adapter = mStatusAdapter;

            mAgeAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mAgeItems);
            mAgeSpinner.Adapter = mAgeAdapter;

            mContactTimeAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mContactTimeItems);
            mContactTimeSpinner.Adapter = mContactTimeAdapter;

            mEducationAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mEducationItems);
            mEducationSpinner.Adapter = mEducationAdapter;

            mEyesColorAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mEyesColorItems);
            mEyesColorSpinner.Adapter = mEyesColorAdapter;

            mGoalFromSiteAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mGoalFromSiteItems);
            mGoalFromSiteSpinner.Adapter = mGoalFromSiteAdapter;

            mHairColorAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mHairColorItems);
            mHairColorSpinner.Adapter = mHairColorAdapter;

            mHeightAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mHeightItems);
            mHeightSpinner.Adapter = mHeightAdapter;

            mJobAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mJobItems);
            mJobSpinner.Adapter = mJobAdapter;

            mCountriesAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mCountries);
            mOriginCountrySpinner.Adapter = mCountriesAdapter;

            mResidenceCountriesAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mResidenceCountries);
            mResidentCountrySpinner.Adapter = mResidenceCountriesAdapter;

            mTimeAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mTimeItems);
            mTimeSpinner.Adapter = mTimeAdapter;

            mWeightAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mWeightItems);
            mWeightSpinner.Adapter = mWeightAdapter;
        }

        public void OpenLegalNotesFragment(IMenuItem item)
        {
            var mybundle = new Bundle();

            mybundle.PutInt("ItemId", item.ItemId);

            var transaction = SupportFragmentManager.BeginTransaction();

            LegalNotesFragment legalNotesFragment = new LegalNotesFragment();

            legalNotesFragment.Arguments = mybundle;

            legalNotesFragment.Show(transaction, "dialog_fragment");

            item.SetChecked(false);
        }

        private void CreateDirectoryForPictures()
        {
            App._dir = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "AhbabImages");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        public static class App
        {
            public static Java.IO.File _file;
            public static Java.IO.File _dir;
            public static Bitmap bitmap;
        }
    }
}