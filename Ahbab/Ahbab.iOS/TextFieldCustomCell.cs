using Foundation;
using System;
using UIKit;

namespace Ahbab.iOS {
    public partial class TextFieldCustomCell : UITableViewCell {
        public TextFieldCustomCell (IntPtr handle) : base (handle) {
        }

        public void setPlaceholder(String placeholder) {
            cellTextField.Text = "";
            cellTextField.TextAlignment = UITextAlignment.Right;
            cellTextField.Placeholder = placeholder;
        }

        public String getTextFromField() {
            return cellTextField.Text;
        }
    }
}