using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using System.Threading;
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
using Asawer.Entities;
using Android;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Database;

namespace Asawer.Droid
{
    [Activity(Label = "@string/register", Theme = "@style/Theme.Ahbab")]
    public class RegisterActivity : AsawerAppCompatActivity
    {
        private const int REQUEST_CAMERA = 0;
        private const int SELECT_FILE = 1;
        private const string cameraPermission = Manifest.Permission.Camera;
        private Spinner mStatusSpinner;
        private Spinner mAgeSpinner;
        private Spinner mContactTimeSpinner;
        private Spinner mEducationSpinner;
        private Spinner mEyesColorSpinner;
        private Spinner mGoalFromSiteSpinner;
        private Spinner mHairColorSpinner;
        private Spinner mHeightSpinner;
        private Spinner mJobSpinner;
        private Spinner mResidentCountrySpinner;
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
        private CustomSpinnerAdapter mStatusAdapter;
        private CustomSpinnerAdapter mAgeAdapter;
        private CustomSpinnerAdapter mContactTimeAdapter;
        private CustomSpinnerAdapter mEducationAdapter;
        private CustomSpinnerAdapter mEyesColorAdapter;
        private CustomSpinnerAdapter mGoalFromSiteAdapter;
        private CustomSpinnerAdapter mHairColorAdapter;
        private CustomSpinnerAdapter mHeightAdapter;
        private CustomSpinnerAdapter mJobAdapter;
        private CustomSpinnerAdapter mResidenceCountriesAdapter;
        private CustomSpinnerAdapter mWeightAdapter;
        private CheckBox check;
        private EditText ContactWay;
        private LinearLayout mContactWaysLayout;
        private LinearLayout mGalleryLayout;
        private List<UserFile> userImages = new List<UserFile>();
        private List<UserFile> userImagesToDelete = new List<UserFile>();
        private string mCurrentPhotoPath;
        private string mCurrentFileName;

        public List<UserFile> UserImagesToDelete { get => userImagesToDelete; set => userImagesToDelete = value; }
        public List<UserFile> UserImages { get => userImages; set => userImages = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.Register);

            this.InitiateComponents();

            this.BindValues();
        }

        protected override void OnStart()
        {
            base.OnStart();

            var headerView = base.NavigationView.GetHeaderView(0);

            if (Ahbab.CurrentUser != null)
            {
                SetCurrentUserData();
                this.mRegisterButton.Visibility = ViewStates.Gone;
                this.mUpdateButton.Visibility = ViewStates.Visible;
                this.mUserNameInputLayout.Visibility = ViewStates.Gone;
                this.mSex.Visibility = ViewStates.Gone;
                var sexText = FindViewById<TextView>(Resource.Id.txtSex);
                sexText.Visibility = ViewStates.Gone;
                var editAccount = headerView.FindViewById<ImageView>(Resource.Id.imgViewHeader);
                if (Ahbab.CurrentUser.ImageBase64 != null && Ahbab.CurrentUser.ImageBytes != null && Ahbab.CurrentUser.ImageBytes[0].Length > 0)
                {
                    var bitmap = BitmapFactory.DecodeByteArray(Ahbab.CurrentUser.ImageBytes[0], 0, Ahbab.CurrentUser.ImageBytes[0].Length);
                    editAccount.SetImageBitmap(bitmap);
                }
            }
            else
            {
                base.NavigationView.Menu.FindItem(Resource.Id.logout).SetVisible(false);
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

            this.mResidentCountrySpinner.SetSelection(this.mResidenceCountriesAdapter.GetPosition(Ahbab.mCountries.FirstOrDefault(
                        i => i.ID == Ahbab.CurrentUser.CurrentCountryId
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
            if (Ahbab.CurrentUser.ImageBytes != null)
            {
                if (this.mGalleryLayout.ChildCount <= 1)
                {
                    if (Ahbab.CurrentUser.ImageBytes.Count >= 5)
                        this.mUploadImage.Visibility = ViewStates.Gone;
                    for (int i = 0; i < Ahbab.CurrentUser.ImageBytes.Count; i++)
                    {
                        var currentUserImage = Ahbab.CurrentUser.ImageBytes[i];

                        var imageBitmap = BitmapFactory.DecodeByteArray(currentUserImage, 0, currentUserImage.Length);

                        this.AddImageToView(imageBitmap, Ahbab.CurrentUser.ImageNames[i], "jpg", mUploadImage.Width, false);
                    }
                }
            }

            for (int i = 0; i < Ahbab.CurrentUser.ContactWays.Count; i++)
            {
                for (int j = 0; j < mContactWaysLayout.ChildCount; j++)
                {
                    var currentItem = mContactWaysLayout.GetChildAt(j);
                    if (currentItem is CheckBox && currentItem.Id == Ahbab.CurrentUser.ContactWays[i].ID)
                    {
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

            this.mResidentCountrySpinner = this.FindViewById<Spinner>(Resource.Id.residentCountrySpinner);

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
                check = new CheckBox(this)
                {
                    Id = Ahbab.mContactWays[i].ID,
                    Text = Ahbab.mContactWays[i].DescriptionAR,
                    TextSize = 22
                };

                check.CheckedChange += Check_CheckedChange;
                ContactWay = new EditText(this)
                {
                    Id = Ahbab.mContactWays[i].ID,
                    Hint = Ahbab.mContactWays[i].DescriptionAR,
                    Visibility = ViewStates.Gone
                };

                mContactWaysLayout.AddView(check);
                mContactWaysLayout.AddView(ContactWay);
            }

            mRegisterButton.Click += MRegisterButton_Click;

            mUploadImage.Click += MUploadImage_Click;

            mUpdateButton.Click += MUpdateButton_Click;
        }

        private void Check_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
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

        private void MRegisterButton_Click(object sender, EventArgs e)
        {
            var validInput = ValidateDataInput();

            if (validInput)
            {
                var registrationSuccessful = false;
                var errorText = "";
                ProgressDialog progress = new ProgressDialog(this)
                {
                    Indeterminate = true
                };
                progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                progress.SetMessage(Constants.UI.RegistrationLoader);
                progress.SetCancelable(false);
                progress.Show();

                var userInput = GetUserInput();

                new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        var resultString = AhbabDatabase.RegisterOrUpdate(Constants.Database.ApiFiles.RegisterFileName, userInput);
                        errorText = resultString;
                        if (!string.IsNullOrEmpty(resultString))
                        {
                            var result = JsonConvert.DeserializeObject<List<User>>(resultString);

                            Ahbab.CurrentUser = result.FirstOrDefault();

                            Intent mainPageIntent = new Intent(this, typeof(userProfileActivity));

                            this.StartActivity(mainPageIntent);

                            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                                           Android.Resource.Animation.SlideOutRight);

                            registrationSuccessful = true;
                        }
                    }
                    catch
                    {
                        registrationSuccessful = false;
                    }

                    RunOnUiThread(() =>
                    {
                        if (registrationSuccessful)
                        {
                            Toast.MakeText(this,
                                           Constants.UI.SuccessfulRegistration,
                                           ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, errorText, ToastLength.Long).Show();
                        }

                        //HIDE PROGRESS DIALOG
                        progress.Hide();
                    });
                })).Start();
            }
        }

        private void MUpdateButton_Click(object sender, EventArgs e)
        {
            var validInput = ValidateDataInput();

            var updateSuccessful = false;

            if (validInput)
            {
                ProgressDialog progress = new ProgressDialog(this)
                {
                    Indeterminate = true
                };
                progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                progress.SetMessage(Constants.UI.UpdateLoader);
                progress.SetCancelable(false);
                progress.Show();

                var userInput = GetUserInput();

                //var valueToUpload = JsonConvert.SerializeObject(userInput);

                new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        string resultString = null;
                        if (this.UserImagesToDelete.Count > 0)
                            resultString = AhbabDatabase.RegisterOrUpdate(Constants.Database.ApiFiles.UpdateFileName, userInput, this.UserImagesToDelete);
                        else
                            resultString = AhbabDatabase.RegisterOrUpdate(Constants.Database.ApiFiles.UpdateFileName, userInput);

                        if (!string.IsNullOrEmpty(resultString))
                        {
                            var result = JsonConvert.DeserializeObject<List<User>>(resultString);
                            Ahbab.CurrentUser = result.FirstOrDefault();
                            Intent mainPageIntent = new Intent(this, typeof(userProfileActivity));
                            this.StartActivity(mainPageIntent);
                            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
                            updateSuccessful = true;
                        }
                    }
                    catch
                    {
                        updateSuccessful = false;
                    }

                    RunOnUiThread(() =>
                    {
                        if (updateSuccessful)
                        {
                            Toast.MakeText(this, Constants.UI.SuccessfulUpdate, ToastLength.Short).Show();
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

        private User GetUserInput()
        {
            var wifiManager = (WifiManager)this.GetSystemService(WifiService);

            var ip = wifiManager.ConnectionInfo.IpAddress;

            var waysCount = mContactWaysLayout.ChildCount;

            var registerContactWays = new List<ContactWay>();

            var gender = string.Empty;

            for (int i = 0; i < waysCount; i++)
            {
                var cWay = new ContactWay();
                var currentChild = mContactWaysLayout.GetChildAt(i);

                if (currentChild is CheckBox)
                {
                    var currentChecBox = (CheckBox)mContactWaysLayout.GetChildAt(i);

                    if (currentChecBox.Checked)
                    {
                        cWay.ID = currentChecBox.Id;
                        cWay.Value = GetWayValue(i);
                        registerContactWays.Add(cWay);
                    }
                }
            }

            if (mSex.CheckedRadioButtonId == Resource.Id.rdbMale)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }

            var currentUser = new User
            {
                UserName = mUserNameInputLayout.EditText.Text,
                Name = mFullNameInputLayout.EditText.Text,
                Password = mPasswordInputLayout.EditText.Text,
                Email = mEmailInputLayout.EditText.Text,
                SelfDescription = mSelfDescriptionInputLayout.EditText.Text,
                OthersDescription = mPartnerDescriptionInputLayout.EditText.Text,
                Age = mAgeAdapter.GetItemAtPosition(mAgeSpinner.SelectedItemPosition).ID,
                BlocksFrom = 0,
                BlocksTo = 0,
                CreatedOn = DateTime.Today,
                LastActiveDate = DateTime.Today,
                CurrentCountryId = mResidenceCountriesAdapter.GetItemAtPosition(mResidentCountrySpinner.SelectedItemPosition).ID,
                EducationLevelID = mEducationAdapter.GetItemAtPosition(mEducationSpinner.SelectedItemPosition).ID,
                EyesColorId = mEyesColorAdapter.GetItemAtPosition(mEyesColorSpinner.SelectedItemPosition).ID,
                HairColorId = mHairColorAdapter.GetItemAtPosition(mHairColorSpinner.SelectedItemPosition).ID,
                HeightId = mHeightAdapter.GetItemAtPosition(mHeightSpinner.SelectedItemPosition).ID,
                InterestsFrom = 0,
                InterestsTo = 0,
                IP = ip.ToString(),
                JobId = mJobAdapter.GetItemAtPosition(mJobSpinner.SelectedItemPosition).ID,
                NumberOfLogins = 1,
                Status = mStatusAdapter.GetItemAtPosition(mStatusSpinner.SelectedItemPosition).ID,
                Paid = "N",
                TimeFrameId = mContactTimeAdapter.GetItemAtPosition(mContactTimeSpinner.SelectedItemPosition).ID,
                UsagePurposeId = mGoalFromSiteAdapter.GetItemAtPosition(mGoalFromSiteSpinner.SelectedItemPosition).ID,
                WeightId = mWeightAdapter.GetItemAtPosition(mWeightSpinner.SelectedItemPosition).ID,
                VisitCountFrom = 0,
                VisitCountTo = 0,
                Images = this.UserImages,
                Gender = gender,
                ContactWays = registerContactWays,
                PaidEndDate = DateTime.Today,
                PaidStartDate = DateTime.Today
            };

            if (Ahbab.CurrentUser != null)
            {
                currentUser.ID = Ahbab.CurrentUser.ID;
            }

            return currentUser;
        }

        private string GetWayValue(int id)
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

        private bool ValidateDataInput()
        {
            var validInput = true;

            if (string.IsNullOrEmpty(mUserNameInputLayout.EditText.Text))
            {
                mUserNameInputLayout.Error = "الرجاء إدخال إسم المستخدم";
                validInput = false;
            }
            else
            {
                mUserNameInputLayout.Error = null;
            }

            if (string.IsNullOrEmpty(mPasswordInputLayout.EditText.Text))
            {
                mPasswordInputLayout.Error = "الرجاء إدخال كلمة السر";
                validInput = false;
            }
            else
            {
                mPasswordInputLayout.Error = null;
            }

            if (string.IsNullOrEmpty(mFullNameInputLayout.EditText.Text))
            {
                mFullNameInputLayout.Error = "الرجاء إدخال الإسم الكامل";
                validInput = false;
            }
            else
            {
                mFullNameInputLayout.Error = null;
            }

            if (string.IsNullOrEmpty(mEmailInputLayout.EditText.Text))
            {
                mEmailInputLayout.Error = "الرجاء إدخال البريد الإلكتروني";
                validInput = false;
            }
            else
            {
                mEmailInputLayout.Error = null;
            }

            if (string.IsNullOrEmpty(mSelfDescriptionInputLayout.EditText.Text))
            {
                mSelfDescriptionInputLayout.Error = "الرجاء تعبئة خانة أوصف نفسك";
                validInput = false;
            }
            else
            {
                mSelfDescriptionInputLayout.Error = null;
            }

            if (string.IsNullOrEmpty(mPartnerDescriptionInputLayout.EditText.Text))
            {
                mPartnerDescriptionInputLayout.Error = "الرجاء تعبئة خانة أوصف الشريك";
                validInput = false;
            }
            else
            {
                mPartnerDescriptionInputLayout.Error = null;
            }

            if (mStatusAdapter.GetItemAtPosition(mStatusSpinner.SelectedItemPosition).ID == -1)
            {
                var parentViewGroup = mStatusSpinner.Parent as ViewGroup;

                mStatusAdapter.SetError(mStatusSpinner.SelectedItemPosition, mStatusSpinner, parentViewGroup, "الرجاء إختيار الوضع العائلي");

                validInput = false;
            }

            if (mGoalFromSiteAdapter.GetItemAtPosition(mGoalFromSiteSpinner.SelectedItemPosition).ID == 0)
            {
                var parentViewGroup = mGoalFromSiteSpinner.Parent as ViewGroup;

                mGoalFromSiteAdapter.SetError(mGoalFromSiteSpinner.SelectedItemPosition, mGoalFromSiteSpinner, parentViewGroup, "الرجاء إختيار الهدف من الموقع");

                validInput = false;
            }

            if (mAgeAdapter.GetItemAtPosition(mAgeSpinner.SelectedItemPosition).ID == 0)
            {
                var parentViewGroup = mAgeSpinner.Parent as ViewGroup;

                mAgeAdapter.SetError(mAgeSpinner.SelectedItemPosition, mAgeSpinner, parentViewGroup, "الرجاء إختيار العمر");

                validInput = false;
            }

            if (mResidenceCountriesAdapter.GetItemAtPosition(mResidentCountrySpinner.SelectedItemPosition).ID == 0)
            {
                var parentViewGroup = mResidentCountrySpinner.Parent as ViewGroup;

                mResidenceCountriesAdapter.SetError(mResidentCountrySpinner.SelectedItemPosition, mResidentCountrySpinner, parentViewGroup, "الرجاء إختيار بلد السكن");

                validInput = false;
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
                        if (this.EnsureCameraPermission())
                        {
                            this.DispatchTakeImageIntent();
                        }
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

        private bool EnsureCameraPermission()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return true;
            }

            if (CheckSelfPermission(cameraPermission) == (int)Permission.Granted)
            {
                return true;
            }

            RequestPermissions(new string[] { cameraPermission }, 0);

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
                                            "Camera permission is available.",
                                            ToastLength.Short).Show();

                            this.DispatchTakeImageIntent();
                        }
                        else
                        {
                            //Permission Denied :(
                            //Disabling location functionality
                            Toast.MakeText(this,
                                            "Camera permission denied.",
                                            ToastLength.Short).Show();
                        }
                    }
                    break;
            }
        }

        private void DispatchTakeImageIntent()
        {
            var intent = new Intent(MediaStore.ActionImageCapture);

            Java.IO.File file = null;

            try
            {
                file = this.CreateImageFile();
            }
            catch
            {
            }

            if (file != null)
            {
                Uri photoURI = FileProvider.GetUriForFile(this,
                                  "com.AFM.Asawer.fileprovider",
                                  file);

                intent.PutExtra(MediaStore.ExtraOutput, photoURI);

                this.StartActivityForResult(intent, REQUEST_CAMERA);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            var height = mUploadImage.Height;

            var width = mUploadImage.Width;

            if (resultCode == Result.Ok)
            {
                if (this.mGalleryLayout.ChildCount >= 5)
                    this.mUploadImage.Visibility = ViewStates.Gone;

                switch (requestCode)
                {
                    case REQUEST_CAMERA:
                        //Get the result image from the camera
                        this.ReadImageFromCamera(width, height);

                        // Dispose of the Java side bitmap.
                        GC.Collect();
                        break;
                    case SELECT_FILE:
                        //Get the images from the gallery
                        this.ReadImagesFromGallery(data, width, height);

                        // Dispose of the Java side bitmap.
                        GC.Collect();
                        break;
                    default:
                        break;
                }
            }
        }

        //Method to be executed after taking the image from the camera
        private void ReadImageFromCamera(int width, int height)
        {
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);

            var currentFile = new Java.IO.File(this.mCurrentPhotoPath);

            var contentUri = Uri.FromFile(currentFile);

            mediaScanIntent.SetData(contentUri);

            this.SendBroadcast(mediaScanIntent);

            var bitmap = this.mCurrentPhotoPath.LoadAndResizeBitmap(width, height);

            if (bitmap != null)
            {
                this.AddImageToView(bitmap, this.mCurrentFileName, "jpg", width, true);

                this.mCurrentFileName = string.Empty;

                this.mCurrentPhotoPath = string.Empty;
            }
        }

        //Method to be executed after the user chooses images from gallery
        private void ReadImagesFromGallery(Intent data, int width, int height)
        {
            if (data.ClipData != null)
            {
                using (var clipData = data.ClipData)
                {
                    for (int i = 0; i < clipData.ItemCount; i++)
                    {
                        if (i > 5)
                        {
                            break;
                        }

                        var item = clipData.GetItemAt(i);

                        var uri = item.Uri;

                        var filePath = GetActualPathFromFile(uri);

                        var fileName = System.IO.Path.GetFileName(filePath);

                        var fileExtension = System.IO.Path.GetExtension(uri.ToString());

                        var currentImage = BitmapHelpers.DecodeBitmapFromStream(this, uri, width, height);

                        this.AddImageToView(currentImage, fileName, fileExtension, width, true);
                    }
                }
            }
            else
            {
                using (var imageData = data.Data)
                {
                    using (var currentImage = BitmapHelpers.DecodeBitmapFromStream(this, imageData, width, height))
                    {
                        var fileName = System.IO.Path.GetFileName(imageData.ToString());

                        var fileExtension = System.IO.Path.GetExtension(imageData.ToString());

                        if (currentImage != null)
                        {
                            this.AddImageToView(currentImage, fileName, fileExtension, width, true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calling this method adds the passed bitmap to the linear layout
        /// </summary>
        /// <param name="currentImage"></param>
        /// <param name="fileName"></param>
        /// <param name="fileExtension"></param>
        /// <param name="width"></param>
        private void AddImageToView(Bitmap currentImage, string fileName, string fileExtension, int width, bool addToUserImages)
        {
            if (addToUserImages)
            {
                using (var memStream = new MemoryStream())
                {
                    currentImage.Compress(Bitmap.CompressFormat.Jpeg, 100, memStream);

                    var picData = memStream.ToArray();

                    this.UserImages.Add(new UserFile(picData, fileName, fileExtension));
                }
            }

            var imageView = new ImageView(this)
            {
                LayoutParameters = new LinearLayout.LayoutParams(width, 300, 25f),
                Id = this.mGalleryLayout.ChildCount + 1
            };

            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);

            imageView.SetAdjustViewBounds(true);

            imageView.SetImageBitmap(currentImage);

            this.mGalleryLayout.AddView(imageView);

            // Using transition name just to hold the image name in case we want to delete it
            imageView.TransitionName = fileName;

            imageView.Click += ImageView_Click;

            GC.Collect();
        }

        // Method used to remove the image from the view and add it to the List to be deleted
        private void ImageView_Click(object sender, EventArgs e)
        {
            var imageView = sender as ImageView;

            var image = this.UserImages.FirstOrDefault(userImage => userImage.FileName.Equals(imageView.TransitionName));

            if (image != null)
            {
                this.UserImages.Remove(image);
            }
            else
            {
                var imageName = Ahbab.CurrentUser.ImageNames[imageView.Id];
                this.UserImagesToDelete.Add(new UserFile(null, imageName, "jpg"));
            }

            this.mGalleryLayout.RemoveView(imageView);
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

            mResidenceCountriesAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mResidenceCountries);
            mResidentCountrySpinner.Adapter = mResidenceCountriesAdapter;

            mWeightAdapter = new CustomSpinnerAdapter(this, Resource.Drawable.spinnerItem, Resource.Id.item_value, Ahbab.mWeightItems);
            mWeightSpinner.Adapter = mWeightAdapter;
        }

        private Java.IO.File CreateImageFile()
        {
            // Create an image file name
            var timeStamp = DateTime.Today.ToString("yyyyMMdd_HHmmss");

            this.mCurrentFileName = "Asawer_" + timeStamp;

            var storageDir = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);

            Java.IO.File image = Java.IO.File.CreateTempFile(
                this.mCurrentFileName,  /* prefix */
                ".jpg",         /* suffix */
                storageDir      /* directory */
            );

            // Save a file: path for use with ACTION_VIEW intents
            this.mCurrentPhotoPath = image.AbsolutePath;

            return image;
        }

        /*private void CreateDirectoryForPictures()
        {
            App._dir = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "AsawerImages");

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
        }*/

        protected override void Logout()
        {
            throw new NotImplementedException();
        }

        private string GetActualPathFromFile(Uri uri)
        {
            bool isKitKat = Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat;

            if (isKitKat && DocumentsContract.IsDocumentUri(this, uri))
            {
                // ExternalStorageProvider
                if (IsExternalStorageDocument(uri))
                {
                    string docId = DocumentsContract.GetDocumentId(uri);

                    char[] chars = { ':' };
                    string[] split = docId.Split(chars);
                    string type = split[0];

                    if ("primary".Equals(type, StringComparison.OrdinalIgnoreCase))
                    {
                        return Android.OS.Environment.ExternalStorageDirectory + "/" + split[1];
                    }
                }
                // DownloadsProvider
                else if (IsDownloadsDocument(uri))
                {
                    string id = DocumentsContract.GetDocumentId(uri);

                    var contentUri = ContentUris.WithAppendedId(
                                    Uri.Parse("content://downloads/public_downloads"), long.Parse(id));

                    //System.Diagnostics.Debug.WriteLine(contentUri.ToString());

                    return GetDataColumn(this, contentUri, null, null);
                }
                // MediaProvider
                else if (IsMediaDocument(uri))
                {
                    String docId = DocumentsContract.GetDocumentId(uri);

                    char[] chars = { ':' };
                    String[] split = docId.Split(chars);

                    String type = split[0];

                    Android.Net.Uri contentUri = null;
                    if ("image".Equals(type))
                    {
                        contentUri = MediaStore.Images.Media.ExternalContentUri;
                    }
                    else if ("video".Equals(type))
                    {
                        contentUri = MediaStore.Video.Media.ExternalContentUri;
                    }
                    else if ("audio".Equals(type))
                    {
                        contentUri = MediaStore.Audio.Media.ExternalContentUri;
                    }

                    String selection = "_id=?";
                    String[] selectionArgs = new String[]
                    {
                split[1]
                    };

                    return GetDataColumn(this, contentUri, selection, selectionArgs);
                }
            }
            // MediaStore (and general)
            else if ("content".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
            {

                // Return the remote address
                if (IsGooglePhotosUri(uri))
                    return uri.LastPathSegment;

                return GetDataColumn(this, uri, null, null);
            }
            // File
            else if ("file".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                return uri.Path;
            }

            return null;
        }

        public static String GetDataColumn(Context context, Uri uri, String selection, String[] selectionArgs)
        {
            ICursor cursor = null;
            String column = "_data";
            String[] projection =
            {
                column
            };

            try
            {
                cursor = context.ContentResolver.Query(uri, projection, selection, selectionArgs, null);
                if (cursor != null && cursor.MoveToFirst())
                {
                    int index = cursor.GetColumnIndexOrThrow(column);
                    return cursor.GetString(index);
                }
            }
            finally
            {
                if (cursor != null)
                    cursor.Close();
            }
            return null;
        }

        //Whether the Uri authority is ExternalStorageProvider.
        public static bool IsExternalStorageDocument(Uri uri)
        {
            return "com.android.externalstorage.documents".Equals(uri.Authority);
        }

        //Whether the Uri authority is DownloadsProvider.
        public static bool IsDownloadsDocument(Uri uri)
        {
            return "com.android.providers.downloads.documents".Equals(uri.Authority);
        }

        //Whether the Uri authority is MediaProvider.
        public static bool IsMediaDocument(Uri uri)
        {
            return "com.android.providers.media.documents".Equals(uri.Authority);
        }

        //Whether the Uri authority is Google Photos.
        public static bool IsGooglePhotosUri(Uri uri)
        {
            return "com.google.android.apps.photos.content".Equals(uri.Authority);
        }
    }
}