using Ahbab.Entities;
using Foundation;
using Newtonsoft.Json;
using SharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UIKit;

namespace Ahbab.iOS {
    public partial class RegistrationController : UITableViewController {
        User user;
        public RegistrationController(IntPtr handle) : base(handle) {}

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            this.user = new User();
            TableView.Source = new RegistrationDataSource(this);
        }

        /**
        * Function used to handle the register button click 
        */
        public void registerButtonClicked() {
            // Validate inputs
            if (true) {
                var registrationSuccessfull = false;
                // display loader
                var userInput = GetUserInput();
                try {
                    var resultString = AhbabDatabase.RegisterOrUpdate(Constants.FunctionsUri.RegisterUri, userInput);
                    if (!string.IsNullOrEmpty(resultString)) {
                        var result = JsonConvert.DeserializeObject<List<User>>(resultString);
                        Ahbab.CurrentUser = result.FirstOrDefault();
                        // Navigate to the search activity
                        registrationSuccessfull = true;
                    }
                } catch (Exception ex) {
                    registrationSuccessfull = false;
                }
            }
        }

        /**
         * Function used to build the user object in order to save it in the backend
         */
        User GetUserInput() {
            var currentUser = new User();
            if (Ahbab.CurrentUser != null) {
                currentUser.ID = Ahbab.CurrentUser.ID;
            }
            TextFieldCustomCell x = TableView.CellAt(NSIndexPath.FromIndex((uint)0)) as TextFieldCustomCell;
            currentUser.UserName = x.getTextFromField();
            /*currentUser.Name = mFullNameInputLayout.EditText.Text;
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
            currentUser.ContactWays = registerContactWays;*/
            return currentUser;
        }

        public class RegistrationDataSource : UITableViewSource {
            RegistrationController controller;
            List<String> textFieldsPlaceholder;
            List<List<SpinnerItem>> pickerItems;

            public RegistrationDataSource(RegistrationController controller) {
                this.controller = controller;
                this.textFieldsPlaceholder = new List<string> {Constants.UI.UserName, Constants.UI.Password, Constants.UI.Email, Constants.UI.FullName};
                this.pickerItems = new List<List<SpinnerItem>> {Ahbab.statusItems, Ahbab.mEyesColorItems, Ahbab.mHairColorItems, Ahbab.mHeightItems,
                                    Ahbab.mWeightItems, Ahbab.mGoalFromSiteItems, Ahbab.mAgeItems, Ahbab.mEducationItems, Ahbab.mCountries,
                                    Ahbab.mResidenceCountries, Ahbab.mJobItems};
            }

            // Returns the number of rows in each section of the table
            public override nint RowsInSection(UITableView tableView, nint section) {
                return 23;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
                if (indexPath.Row >= 0 && indexPath.Row <= 3) {
                    return this.InitializeUsernameInfoFields(tableView, indexPath.Row);
                } else if (indexPath.Row == 4) {
                    GenderSelectionCustomCell genderCell = tableView.DequeueReusableCell("reusableGenderPickerCell") as GenderSelectionCustomCell;
                    genderCell.PopulateData();
                    return genderCell;
                } else if (indexPath.Row >= 5 && indexPath.Row <= 15) {
                    return this.InitializePickers(tableView, indexPath.Row);
                } else if (indexPath.Row == 16) {
                    TextFieldCustomCell cell = tableView.DequeueReusableCell("reusableTextFieldCell") as TextFieldCustomCell;
                    cell.setPlaceholder(Constants.UI.selfDescription);
                    return cell;
                } else if (indexPath.Row == 17) {
                    TextFieldCustomCell cell = tableView.DequeueReusableCell("reusableTextFieldCell") as TextFieldCustomCell;
                    cell.setPlaceholder(Constants.UI.partnerDescription);
                    return cell;
                } else if (indexPath.Row == 18) {
                    PickerCustomCell picker = tableView.DequeueReusableCell("reusablePickerCell") as PickerCustomCell;
                    picker.setPickerView(Ahbab.mTimeItems);
                    return picker;
                } else if (indexPath.Row == 19) {
                    PickerCustomCell picker = tableView.DequeueReusableCell("reusablePickerCell") as PickerCustomCell;
                    picker.setPickerView(Ahbab.mContactTimeItems);
                    return picker;
                } else if (indexPath.Row == 20) {
                    ContactWaysCustomCell contactWays = tableView.DequeueReusableCell("contactWays") as ContactWaysCustomCell;
                    contactWays.setContactWays();
                    return contactWays;
                } else if (indexPath.Row == 21) {
                    UploadimagesCell uploadImage = tableView.DequeueReusableCell("uploadImagesCell") as UploadimagesCell;
                    uploadImage.setCollectionView(this.controller);
                    return uploadImage;
                } else {
                    RegisterButtonCell registerButton = tableView.DequeueReusableCell("registerButtonCell") as RegisterButtonCell;
                    registerButton.setButtonTitle(Constants.UI.Register, this.controller);
                    return registerButton;
                }
            }

            /**
             * Function used to create the ui picker views containing the options 
             * the user will select from
             */
            private UITableViewCell InitializePickers(UITableView tableView, int rowNumber)  {
                PickerCustomCell picker = tableView.DequeueReusableCell("reusablePickerCell") as PickerCustomCell;
                picker.setPickerView(this.pickerItems[rowNumber - 5]);
                return picker;
            }

            /**
             * Function used to draw the first 4 fields in the registration screen
             */
            private UITableViewCell InitializeUsernameInfoFields(UITableView tableView, int rowNumber) {
                TextFieldCustomCell cell = tableView.DequeueReusableCell("reusableTextFieldCell") as TextFieldCustomCell;
                cell.setPlaceholder(this.textFieldsPlaceholder[rowNumber]);
                return cell;
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath) {
                if (indexPath.Row == 4) {
                    return 110;
                } else if (indexPath.Row >= 5 && indexPath.Row <= 15 || indexPath.Row == 18 || indexPath.Row == 19 || indexPath.Row == 21) {
                    return 216;
                } else if (indexPath.Row == 20) {
                    return 350;
                } else {
                    return 44;
                }
            }
        }
    }
}