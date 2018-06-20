using Foundation;
using System;
using UIKit;

namespace Asawer.iOS {
    public partial class ImageViewCustomCell : UITableViewCell {
        public ImageViewCustomCell (IntPtr handle) : base (handle) {}

        public void fillImageInSideMenue() {
            ImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            ImageView.Image = UIImage.FromBundle("Drawbles/G0153384.JPG");
        }
    }
}