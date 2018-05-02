using Asawer;
using Asawer.Entities;
using Foundation;
using Newtonsoft.Json;
using SharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace Ahbab.iOS {
    public partial class RegistrationController : UITableViewController {
        RegistrationDataSource dataSource;
        public RegistrationController(IntPtr handle) : base(handle) {}

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            this.dataSource = new RegistrationDataSource(this);
            TableView.Source = this.dataSource;
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
            
            currentUser.UserName = this.dataSource.user.UserName;
            currentUser.Name = this.dataSource.user.Name;
            currentUser.Password = this.dataSource.user.Password;
            currentUser.Email = this.dataSource.user.Email;
            currentUser.SelfDescription = this.dataSource.user.SelfDescription;
            currentUser.OthersDescription = this.dataSource.user.OthersDescription;
            currentUser.Age = this.dataSource.user.Age;
            currentUser.BlocksFrom = 0;
            currentUser.BlocksTo = 0;
            currentUser.CreatedOn = DateTime.Today;
            currentUser.LastActiveDate = DateTime.Today;
            currentUser.CurrentCountryId = this.dataSource.user.CurrentCountryId;
            currentUser.EducationLevelID = this.dataSource.user.EducationLevelID;
            currentUser.EyesColorId = this.dataSource.user.EyesColorId;
            currentUser.HairColorId = this.dataSource.user.HairColorId;
            currentUser.HeightId = this.dataSource.user.HeightId;
            currentUser.InterestsFrom = 0;
            currentUser.InterestsTo = 0;
            //WifiManager wifiManager = (WifiManager)this.GetSystemService(WifiService);
            //int ip = wifiManager.ConnectionInfo.IpAddress;
            //currentUser.IP = ip.ToString();
            currentUser.JobId = this.dataSource.user.JobId;
            currentUser.NumberOfLogins = 1;
            currentUser.OriginCountryId = this.dataSource.user.OriginCountryId;
            currentUser.Status = this.dataSource.user.Status;
            currentUser.Paid = "N";
            currentUser.PaidEndDate = DateTime.Today;
            currentUser.PaidStartDate = DateTime.Today;
            currentUser.TimeFrameId = this.dataSource.user.TimeFrameId;
            currentUser.TimeZoneId = this.dataSource.user.TimeZoneId;
            currentUser.UsagePurposeId = this.dataSource.user.UsagePurposeId;
            currentUser.WeightId = this.dataSource.user.WeightId;
            currentUser.VisitCountFrom = 0;
            currentUser.VisitCountTo = 0;
            currentUser.Images = this.dataSource.user.Images;
            currentUser.Gender = this.dataSource.user.Gender;
            currentUser.ContactWays = this.dataSource.user.ContactWays;
            return currentUser;
        }

        public class RegistrationDataSource : UITableViewSource {
            RegistrationController controller;
            List<String> textFieldsPlaceholder;
            List<List<SpinnerItem>> pickerItems;
            List<int> pickerSelectedValues;
            public User user; 

            public RegistrationDataSource(RegistrationController controller) {
                this.controller = controller;
                this.textFieldsPlaceholder = new List<string> {Constants.UI.UserName, Constants.UI.Password, Constants.UI.Email, Constants.UI.FullName};
                this.pickerItems = new List<List<SpinnerItem>> {Ahbab.statusItems, Ahbab.mEyesColorItems, Ahbab.mHairColorItems, Ahbab.mHeightItems,
                                    Ahbab.mWeightItems, Ahbab.mGoalFromSiteItems, Ahbab.mAgeItems, Ahbab.mEducationItems, Ahbab.mCountries,
                                    Ahbab.mResidenceCountries, Ahbab.mJobItems};
                this.user = new User();
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
                    if (this.user.Gender == null) {
                        genderCell.PopulateData("M", this);
                    } else {
                        genderCell.PopulateData(this.user.Gender, this);
                    }
                    return genderCell;
                } else if (indexPath.Row >= 5 && indexPath.Row <= 15) {
                    return this.InitializePickers(tableView, indexPath.Row);
                } else if (indexPath.Row == 16) {
                    TextFieldCustomCell cell = tableView.DequeueReusableCell("reusableTextFieldCell") as TextFieldCustomCell;
                    if (string.IsNullOrEmpty(this.user.SelfDescription)) {
                        cell.setPlaceholder(Constants.UI.selfDescription, this, indexPath.Row);
                    } else {
                        cell.setTextValue(this.user.SelfDescription);
                    }
                    return cell;
                } else if (indexPath.Row == 17) {
                    TextFieldCustomCell cell = tableView.DequeueReusableCell("reusableTextFieldCell") as TextFieldCustomCell;
                    if (string.IsNullOrEmpty(this.user.OthersDescription)) {
                        cell.setPlaceholder(Constants.UI.partnerDescription, this, indexPath.Row);
                    } else {
                        cell.setTextValue(this.user.OthersDescription);
                    }
                    return cell;
                } else if (indexPath.Row == 18) {
                    PickerCustomCell picker = tableView.DequeueReusableCell("reusablePickerCell") as PickerCustomCell;
                    picker.setPickerView(Ahbab.mTimeItems, indexPath.Row, this.user.TimeZoneId, this);
                    return picker;
                } else if (indexPath.Row == 19) {
                    PickerCustomCell picker = tableView.DequeueReusableCell("reusablePickerCell") as PickerCustomCell;
                    picker.setPickerView(Ahbab.mContactTimeItems, indexPath.Row, this.user.TimeFrameId, this);
                    return picker;
                } else if (indexPath.Row == 20) {
                    ContactWaysCustomCell contactWays = tableView.DequeueReusableCell("contactWays") as ContactWaysCustomCell;
                    contactWays.setContactWays(this);
                    return contactWays;
                } else if (indexPath.Row == 21) {
                    UploadimagesCell uploadImage = tableView.DequeueReusableCell("uploadImagesCell") as UploadimagesCell;
                    uploadImage.setCollectionView(this.controller, this);
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
                if (rowNumber == 5) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.Status, this);
                } else if (rowNumber == 6) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.EyesColorId, this);
                } else if (rowNumber == 7) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.HairColorId, this);
                } else if (rowNumber == 8) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.HeightId, this);
                } else if (rowNumber == 9) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.WeightId, this);
                } else if (rowNumber == 10) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.UsagePurposeId, this);
                } else if (rowNumber == 11) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.Age, this);
                } else if (rowNumber == 12) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.EducationLevelID, this);
                } else if (rowNumber == 13) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.OriginCountryId, this);
                } else if (rowNumber == 14) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.CurrentCountryId, this);
                } else if (rowNumber == 15) {
                    picker.setPickerView(this.pickerItems[rowNumber - 5], rowNumber, this.user.JobId, this);
                }
                return picker;
            }

            /**
             * Function used to draw the first 4 fields in the registration screen
             */
            private UITableViewCell InitializeUsernameInfoFields(UITableView tableView, int rowNumber) {
                TextFieldCustomCell cell = tableView.DequeueReusableCell("reusableTextFieldCell") as TextFieldCustomCell;
                if (rowNumber == 0) {
                    if (string.IsNullOrEmpty(this.user.UserName)) {
                        cell.setPlaceholder(this.textFieldsPlaceholder[rowNumber], this, rowNumber);
                    } else {
                        cell.setTextValue(this.user.UserName);
                    }
                } else if (rowNumber == 1) {
                    if (string.IsNullOrEmpty(this.user.Password)) {
                        cell.setPlaceholder(this.textFieldsPlaceholder[rowNumber], this, rowNumber);
                    } else {
                        cell.setTextValue(this.user.Password);
                    }
                } else if (rowNumber == 2) {
                    if (string.IsNullOrEmpty(this.user.Email)) {
                        cell.setPlaceholder(this.textFieldsPlaceholder[rowNumber], this, rowNumber);
                    } else {
                        cell.setTextValue(this.user.Email);
                    }
                } else if (rowNumber == 3) {
                    if (string.IsNullOrEmpty(this.user.Name)) {
                        cell.setPlaceholder(this.textFieldsPlaceholder[rowNumber], this, rowNumber);
                    } else {
                        cell.setTextValue(this.user.Name);
                    }
                }

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