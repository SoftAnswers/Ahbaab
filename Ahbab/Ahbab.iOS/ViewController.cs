using System;

using UIKit;
using SharedCode;
using Asawer.Entities;
using SlideMenuControllerXamarin;
using Asawer;

namespace Asawer.iOS {
    public partial class ViewController : UIViewController {

        public ViewController(IntPtr handle) : base(handle) {}

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            this.initializeSideMenuButton();
            try {
                GetData();
            } catch (Exception ex) {
                
            }
        }

        partial void LoginBtn_TouchUpInside(UIButton sender) {
            this.ShowUIAlertController();
        }

        partial void UIButton109_TouchUpInside(UIButton sender) { }

        /**
         * Function used to create and draw the button of the side menu 
         */
        private void initializeSideMenuButton() {
            this.NavigationItem.SetRightBarButtonItem(
                new UIBarButtonItem(UIImage.FromFile("Drawbles/menu.png"), UIBarButtonItemStyle.Plain, (sender, args) => {
                    this.slideMenuController().OpenRight();
            }), true);
        }

        /**
         * Function used to display the pop up containg the username/password field
         * in order to login
         */
        private void ShowUIAlertController() {
            UIAlertController alert = UIAlertController.Create(Constants.UI.Login, "", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create(Constants.UI.Login, UIAlertActionStyle.Default, action => {
                this.LoginClicked(alert.TextFields[0].Text, alert.TextFields[1].Text);
            }));

            alert.AddAction(UIAlertAction.Create(Constants.UI.Cancel, UIAlertActionStyle.Cancel, null));
            alert.AddTextField((field) => {
                field.Placeholder = Constants.UI.UserName;
                field.TextAlignment = UITextAlignment.Right;
            });
            alert.AddTextField((field) => {
                field.Placeholder = Constants.UI.Password;
                field.SecureTextEntry = true;
                field.TextAlignment = UITextAlignment.Right;
            });
            PresentViewController(alert, animated: true, completionHandler: null);
        }

        /**
         * Fuction used to perform the actual login. It calls the login service
         * that returns the requested user
         */
        private async void LoginClicked(String username, String password) {
            try {
                var result = await AhbabDatabase.Login(username, password);
                if (result != null) {
                    Ahbab.CurrentUser = result;
                    MainPageTabController mainPage = this.Storyboard.InstantiateViewController("MainPageTabController") as MainPageTabController;
                    if (mainPage != null) {
                        this.NavigationController.PushViewController(mainPage, true);
                    }
                }
            } catch (Exception ex) {
                var result = AhbabDatabase.LogMessage("Login error: " + ex.Message, "error");
            }
        }

        static void GetData() {
            Ahbab.statusItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.Status);
            Ahbab.statusItems.Insert(0, new SpinnerItem(-1, "Choose", Constants.DefaultValues.FamilyStatus));
            Ahbab.mAgeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetTwoColumnsSpinnersItemFileName), Constants.Database.Tables.Age);
            Ahbab.mAgeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Age));
            Ahbab.mContactTimeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetTwoColumnsSpinnersItemFileName), Constants.Database.Tables.ContactTime);
            Ahbab.mContactTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ContactTime));
            Ahbab.mEducationItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.Education);
            Ahbab.mEducationItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EducationLevel));
            Ahbab.mEyesColorItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.EyesColor);
            Ahbab.mEyesColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EyesColor));
            Ahbab.mGoalFromSiteItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.GoalFromSite);
            Ahbab.mGoalFromSiteItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.GoalFromSite));
            Ahbab.mHairColorItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.HairColor);
            Ahbab.mHairColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.HairColor));
            Ahbab.mHeightItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.Height);
            Ahbab.mHeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Height));
            Ahbab.mJobItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName),Constants.Database.Tables.Job);
            Ahbab.mJobItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Job));
            Ahbab.mCountries = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.Countries);
            Ahbab.mCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.OriginCountry));
            Ahbab.mResidenceCountries = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.Countries);
            Ahbab.mResidenceCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ResidenceCountry));
            Ahbab.mContactWays = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.ContactWays);
            Ahbab.mTimeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetTwoColumnsSpinnersItemFileName), Constants.Database.Tables.Time);
            Ahbab.mTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.TimeZone));
            Ahbab.mWeightItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.Database.ApiFiles.GetSpinnerItemsFileName), Constants.Database.Tables.Weight);
            Ahbab.mWeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Weight));
        }
    }
}

