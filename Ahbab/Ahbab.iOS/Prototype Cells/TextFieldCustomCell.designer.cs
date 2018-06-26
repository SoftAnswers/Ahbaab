// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Asawer.iOS
{
    [Register ("TextFieldCustomCell")]
    partial class TextFieldCustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField cellTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cellTextField != null) {
                cellTextField.Dispose ();
                cellTextField = null;
            }
        }
    }
}