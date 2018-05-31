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
                if (Ahbab.CurrentUser.ImageBytes.Count >= 5)
                    this.mUploadImage.Visibility = ViewStates.Gone;
                for (int i = 0; i < Ahbab.CurrentUser.ImageBytes.Count; i++)
                {
                    var imageView = new ImageView(this)
                    {
                        Id = i
                    };
                    LinearLayout.LayoutParams parame = new LinearLayout.LayoutParams(mUploadImage.Width, 300, 25f);
                    imageView.LayoutParameters = parame;
                    imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                    imageView.SetAdjustViewBounds(true);
                    imageView.SetImageBitmap(BitmapFactory.DecodeByteArray(Ahbab.CurrentUser.ImageBytes[i], 0, Ahbab.CurrentUser.ImageBytes[i].Length));
                    this.mGalleryLayout.AddView(imageView);
                    imageView.Click += ImageView_Click;
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
                var registrationSuccessfull = false;
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

                            Intent mainPageIntent = new Intent(this, typeof(MainPageActivity));

                            this.StartActivity(mainPageIntent);

                            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft,
                                                           Android.Resource.Animation.SlideOutRight);

                            registrationSuccessfull = true;
                        }
                    }
                    catch
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

            var updateSuccessfull = false;

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
                            Intent mainPageIntent = new Intent(this, typeof(MainPageActivity));
                            this.StartActivity(mainPageIntent);
                            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
                            updateSuccessfull = true;
                        }
                    }
                    catch
                    {
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
            var errorText = "";

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
                errorText = "الرجاء إختيار الوضع العائلي";
                validInput = false;
            }

            if (mGoalFromSiteAdapter.GetItemAtPosition(mGoalFromSiteSpinner.SelectedItemPosition).ID == 0)
            {
                errorText = "الرجاء إختيار الهدف من الموقع";
                validInput = false;
            }

            if (mAgeAdapter.GetItemAtPosition(mAgeSpinner.SelectedItemPosition).ID == 0)
            {
                errorText = "الرجاء إختيار العمر";
                validInput = false;
            }

            if (mResidenceCountriesAdapter.GetItemAtPosition(mResidentCountrySpinner.SelectedItemPosition).ID == 0)
            {
                errorText = "الرجاء إختيار بلد السكن";
                validInput = false;
            }

            if (!errorText.Equals(""))
            {
                new Thread(new ThreadStart(() =>
                {
                    RunOnUiThread(() =>
                    {
                        Toast.MakeText(this, errorText, ToastLength.Long).Show();
                    });
                })).Start();
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
                                  "com.SoftAnswers.dating.Asawer.fileprovider",
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
                this.AddImageToView(bitmap, this.mCurrentFileName, "jpg", width);

                this.mCurrentFileName = string.Empty;

                this.mCurrentPhotoPath = string.Empty;
            }
        }

        //Method to be executed after the user chooses images from gallery
        private void ReadImagesFromGallery(Intent data, int width, int height)
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

                    var item = clipData.GetItemAt(i);

                    var uri = item.Uri;

                    var fileName = System.IO.Path.GetFileName(GetFilePath(uri));

                    var fileExtension = System.IO.Path.GetExtension(uri.ToString());

                    var currentImage = BitmapHelpers.DecodeBitmapFromStream(this, uri, width, height);

                    this.AddImageToView(currentImage, fileName, fileExtension, width);
                }
            }
            else
            {
                var currentImage = BitmapHelpers.DecodeBitmapFromStream(this, data.Data, width, height);

                var fileName = System.IO.Path.GetFileName(data.Data.ToString());

                var fileExtension = System.IO.Path.GetExtension(data.Data.ToString());

                if (currentImage != null)
                {
                    this.AddImageToView(currentImage, fileName, fileExtension, width);
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
        private void AddImageToView(Bitmap currentImage, string fileName, string fileExtension, int width)
        {
            using (var memStream = new MemoryStream())
            {
                currentImage.Compress(Bitmap.CompressFormat.Jpeg, 100, memStream);

                var picData = memStream.ToArray();

                this.UserImages.Add(new UserFile(picData, fileName, fileExtension));
            }

            var imageView = new ImageView(this)
            {
                LayoutParameters = new LinearLayout.LayoutParams(width, 300, 25f)
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

        private string GetFilePath(Uri uri)
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
    }
}