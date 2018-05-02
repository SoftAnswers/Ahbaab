using Asawer;
using System;
using System.Collections.Generic;
using UIKit;

namespace Ahbab.iOS {
    public partial class ContactWaysCustomCell : UITableViewCell {
        RegistrationController.RegistrationDataSource parent;
        public ContactWaysCustomCell (IntPtr handle) : base (handle) {}

        public void setContactWays(RegistrationController.RegistrationDataSource parent) {
            var height = 40;
            for (int i = 0; i < Ahbab.mContactWays.Count; i++) {
                this.parent = parent;
                var checkbox = new SaturdayMP.XPlugins.iOS.BEMCheckBox(new CoreGraphics.CGRect(UIScreen.MainScreen.Bounds.Width - 50, height, 25, 25));
                checkbox.Tag = Ahbab.mContactWays[i].ID;
                UILabel label = new UILabel(new CoreGraphics.CGRect(UIScreen.MainScreen.Bounds.Width - 205, height, 150, 25));
                label.Text = Ahbab.mContactWays[i].DescriptionAR;
                label.TextAlignment = UITextAlignment.Right;
                this.AddSubview(checkbox);
                this.AddSubview(label);
                checkbox.ValueChanged += Checkbox_ValueChanged;
                height += 40;
            }
            this.parent.user.ContactWays = new List<ContactWay>();
        }

        private void Checkbox_ValueChanged(object sender, EventArgs e) {
            var checkbox = sender as SaturdayMP.XPlugins.iOS.BEMCheckBox;
            var cWay = new ContactWay();
            if (checkbox.On) {
                cWay.way_id = (int)checkbox.Tag;
                cWay.way_value = "";
                this.parent.user.ContactWays.Add(cWay);
            } else {
                for (int i = 0; i < this.parent.user.ContactWays.Count; i++) {
                    if (this.parent.user.ContactWays[i].way_id == checkbox.Tag) {
                        this.parent.user.ContactWays.RemoveAt(i);
                    }
                }
            }
        }
    }
}