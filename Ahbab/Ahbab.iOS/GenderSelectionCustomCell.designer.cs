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
    [Register ("GenderSelectionCustomCell")]
    partial class GenderSelectionCustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cellLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl cellSegmentedControl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cellLabel != null) {
                cellLabel.Dispose ();
                cellLabel = null;
            }

            if (cellSegmentedControl != null) {
                cellSegmentedControl.Dispose ();
                cellSegmentedControl = null;
            }
        }
    }
}