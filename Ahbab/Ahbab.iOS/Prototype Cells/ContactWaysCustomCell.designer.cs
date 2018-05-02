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
    [Register ("ContactWaysCustomCell")]
    partial class ContactWaysCustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel contactWaysLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (contactWaysLabel != null) {
                contactWaysLabel.Dispose ();
                contactWaysLabel = null;
            }
        }
    }
}