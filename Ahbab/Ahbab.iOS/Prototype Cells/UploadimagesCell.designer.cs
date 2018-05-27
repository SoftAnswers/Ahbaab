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
    [Register ("UploadimagesCell")]
    partial class UploadimagesCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView imageViewCollection { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel uploadImageLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imageViewCollection != null) {
                imageViewCollection.Dispose ();
                imageViewCollection = null;
            }

            if (uploadImageLabel != null) {
                uploadImageLabel.Dispose ();
                uploadImageLabel = null;
            }
        }
    }
}