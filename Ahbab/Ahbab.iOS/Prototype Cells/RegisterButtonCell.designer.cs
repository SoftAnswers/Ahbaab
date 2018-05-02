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

namespace Ahbab.iOS
{
    [Register ("RegisterButtonCell")]
    partial class RegisterButtonCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton registerButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (registerButton != null) {
                registerButton.Dispose ();
                registerButton = null;
            }
        }
    }
}