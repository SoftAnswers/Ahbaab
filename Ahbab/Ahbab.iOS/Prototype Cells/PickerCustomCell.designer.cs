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
    [Register ("PickerCustomCell")]
    partial class PickerCustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView cellPicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cellPicker != null) {
                cellPicker.Dispose ();
                cellPicker = null;
            }
        }
    }
}