using Foundation;
using System;
using UIKit;

namespace Ahbab.iOS {
    public partial class GenderSelectionCustomCell : UITableViewCell {
        public GenderSelectionCustomCell (IntPtr handle) : base (handle) {}

        public void PopulateData() {
            cellLabel.TextAlignment = UITextAlignment.Right;
            cellLabel.Text = Constants.UI.sex;
            cellSegmentedControl.SelectedSegment = 0;
        }
    }
}