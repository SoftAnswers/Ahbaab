using Foundation;
using System;
using UIKit;

namespace Ahbab.iOS {
    public partial class RegistrationController : UITableViewController {
        public RegistrationController(IntPtr handle) : base(handle) {}

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            TableView.Source = new RegistrationDataSource(this);
        }

        class RegistrationDataSource : UITableViewSource {
            RegistrationController controller;

            public RegistrationDataSource(RegistrationController controller) {
                this.controller = controller;
            }

            // Returns the number of rows in each section of the table
            public override nint RowsInSection(UITableView tableView, nint section) {
                return 22;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
                var cell = tableView.DequeueReusableCell("reusableTextFieldCell") as TextFieldCustomCell;

                //int row = indexPath.Row;
                //.TextLabel.Text = "hey " + row;
                return cell;
            }
        }
    }
}