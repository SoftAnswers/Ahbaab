using Asawer;
using System;
using UIKit;

namespace Ahbab.iOS {
    public partial class GenderSelectionCustomCell : UITableViewCell {
        RegistrationController.RegistrationDataSource parent;

        public GenderSelectionCustomCell (IntPtr handle) : base (handle) {}

        public void PopulateData(string gender, RegistrationController.RegistrationDataSource parent) {
            this.parent = parent;
            cellLabel.TextAlignment = UITextAlignment.Right;
            cellLabel.Text = Constants.UI.Sex;
            if(String.IsNullOrEmpty(gender) || gender.Equals("M")) {
                cellSegmentedControl.SelectedSegment = 0;
                this.parent.user.Gender = "M";
            } else {
                cellSegmentedControl.SelectedSegment = 1;
                this.parent.user.Gender = "F";
            }
               
            cellSegmentedControl.ValueChanged += CellSegmentedControl_ValueChanged;
        }

        private void CellSegmentedControl_ValueChanged(object sender, EventArgs e) {
            this.parent.user.Gender = cellSegmentedControl.SelectedSegment == 0 ? "M" : "F";
        }
    }
}