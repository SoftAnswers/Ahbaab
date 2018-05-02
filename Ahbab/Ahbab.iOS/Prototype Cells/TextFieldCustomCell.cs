using Foundation;
using System;
using UIKit;

namespace Ahbab.iOS {
    public partial class TextFieldCustomCell : UITableViewCell {
        RegistrationController.RegistrationDataSource parent;
        public TextFieldCustomCell(IntPtr handle) : base(handle) {}

        private void CellTextField_ValueChanged(object sender, EventArgs e) {
            parent.user.UserName = cellTextField.Text;
        }

        public void setPlaceholder(String placeholder, RegistrationController.RegistrationDataSource parent, int rowNb) {
            cellTextField.Text = "";
            cellTextField.TextAlignment = UITextAlignment.Right;
            cellTextField.Placeholder = placeholder;
            cellTextField.Tag = rowNb;
            this.parent = parent;
            MyTextFieldDelegate delegateTextField = new MyTextFieldDelegate(parent);
            cellTextField.Delegate = delegateTextField;
        }

        public String getTextFromField() {
            return cellTextField.Text;
        }

        public void setTextValue(string value) {
            this.cellTextField.Text = value;
        }

        public UITextField getField()
        {
            return cellTextField;
        }

        public class MyTextFieldDelegate : UITextFieldDelegate {
            RegistrationController.RegistrationDataSource parent;

            public MyTextFieldDelegate(RegistrationController.RegistrationDataSource parent) {
                this.parent = parent;
            }

            public override void EditingEnded(UITextField textField) {
                if (textField.Tag == 0) {
                    this.parent.user.UserName = textField.Text;
                } else if (textField.Tag == 1) {
                    this.parent.user.Password = textField.Text;
                } else if (textField.Tag == 2) {
                    this.parent.user.Email = textField.Text;
                } else if (textField.Tag == 3) {
                    this.parent.user.Name = textField.Text;
                } else if (textField.Tag == 16) {
                    this.parent.user.SelfDescription = textField.Text;
                } else if (textField.Tag == 17) {
                    this.parent.user.OthersDescription = textField.Text;
                }
            }
        }
    }
}