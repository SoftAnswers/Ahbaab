using Asawer;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Ahbab.iOS {
    public partial class SideMenuController : UITableViewController {
        public SideMenuController (IntPtr handle) : base (handle) { }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 40f;
            TableView.Source = new SideMenuControllerDataSource(this);
        }

        class SideMenuControllerDataSource : UITableViewSource {
            SideMenuController controller;
            List<String> slideMenuItems;
            List<String> slideMenuItemsBody;

            public SideMenuControllerDataSource(SideMenuController controller) {
                this.controller = controller;
                this.slideMenuItems = new List<string> {Constants.UI.ContactUs, Constants.UI.WhoAreWeTitle, Constants.UI.SecurityPolicyTitle,
                                        Constants.UI.TermsAndConditionTitle, Constants.UI.PrivacyPolicyTitle, Constants.UI.Logout};
                this.slideMenuItemsBody = new List<string> {Constants.UI.WhoAreWeBody, Constants.UI.SecurityPolicyBody,
                                        Constants.UI.TermsAndConditionsBody, Constants.UI.PrivacyPolicyBody};
            }

            // Returns the number of rows in each section of the table
            public override nint RowsInSection(UITableView tableView, nint section) {
                if (Ahbab.CurrentUser != null) {
                    return 7;
                } else {
                    return 6;
                }
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
                if (indexPath.Row.Equals(0)) {
                    var cell = tableView.DequeueReusableCell("ImageViewCustomCell") as ImageViewCustomCell;
                    cell.fillImageInSideMenue();
                    return cell;
                } else {
                    var cell = tableView.DequeueReusableCell("LabelCustomCell") as LabelCustomCell;
                    cell.TextLabel.Text = this.slideMenuItems[indexPath.Row - 1];
                    return cell;
                }
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath) {
                if (indexPath.Row > 1) {
                    UIAlertController alert = UIAlertController.Create(this.slideMenuItems[indexPath.Row-1], this.slideMenuItemsBody[indexPath.Row-2], UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create(Constants.UI.Cancel, UIAlertActionStyle.Cancel, null));
                    this.controller.PresentViewController(alert, animated: true, completionHandler: null);
                }
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath) {
                 if (indexPath.Row == 0) {
                    return 210;
                 } else {
                    return 44;
                 }
            }
        }
    }
}