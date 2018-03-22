using Foundation;
using System;
using UIKit;

namespace Ahbab.iOS {
    public partial class ContactWaysCustomCell : UITableViewCell {
        public ContactWaysCustomCell (IntPtr handle) : base (handle) {}

        public void setContactWays() {
            var height = 40;
            for (int i = 0; i < Ahbab.mContactWays.Count; i++) {
                var checkbox = new SaturdayMP.XPlugins.iOS.BEMCheckBox(new CoreGraphics.CGRect(UIScreen.MainScreen.Bounds.Width - 50, height, 25, 25));
                UILabel label = new UILabel(new CoreGraphics.CGRect(UIScreen.MainScreen.Bounds.Width - 205, height, 150, 25));
                label.Text = Ahbab.mContactWays[i].DescriptionAR;
                label.TextAlignment = UITextAlignment.Right;
                this.AddSubview(checkbox);
                this.AddSubview(label);
                height += 40;
            }
        }
    }
}