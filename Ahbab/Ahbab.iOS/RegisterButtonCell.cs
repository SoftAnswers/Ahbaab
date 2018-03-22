using Foundation;
using System;
using UIKit;

namespace Ahbab.iOS {
    public partial class RegisterButtonCell : UITableViewCell {
        RegistrationController parent;
        public RegisterButtonCell (IntPtr handle) : base (handle) {}

        public void setButtonTitle(String title, RegistrationController parent) {
            this.parent = parent;
            registerButton.SetTitle(title, UIControlState.Normal);
            registerButton.TouchUpInside += RegisterButton_TouchUpInside;
        }

        private void RegisterButton_TouchUpInside(object sender, EventArgs e) {
            this.parent.registerButtonClicked();
        }
    }
}