using Asawer;
using Foundation;
using System;
using System.Collections.Generic;
using System.Drawing;
using UIKit;

namespace Ahbab.iOS {
    public partial class UploadimagesCell : UITableViewCell {
        RegistrationController parent;
        RegistrationController.RegistrationDataSource parent2;
        UIImagePickerController imagePicker;
        List<UIImageView> imagesList = new List<UIImageView>();
        ImageSource source;

        public UploadimagesCell (IntPtr handle) : base (handle) {}

        /**
         * Function used to initialize the upload image cell
         */
        public void setCollectionView(RegistrationController parent, RegistrationController.RegistrationDataSource parent2) {
            this.parent = parent;
            this.parent2 = parent2;
            this.parent2.user.Images = new List<UserFile>();
            UIImageView imageView = new UIImageView(UIImage.FromBundle("Drawbles/add_img.png"));
            imagesList.Add(imageView);
            this.source = new ImageSource(imagesList);
            imageViewCollection.RegisterClassForCell(typeof(ImageViewCell), ImageViewCell.CellID);
            imageViewCollection.Source = this.source;
            imageViewCollection.Delegate = new MyCollectionDelegate(this);
        } 

        /**
         * Function used to handle the add image click. It opend a new activity
         * sheet where the user can select to upload image either from the camera
         * or from the gallery
         */
        private void addImage_Clicked() {
            UIAlertController alert = UIAlertController.Create(Constants.UI.Login, "", UIAlertControllerStyle.ActionSheet);

            alert.AddAction(UIAlertAction.Create(Constants.TabsNames.FromCamera, UIAlertActionStyle.Default, action => {
                this.chooseFromCamera();
            }));
            alert.AddAction(UIAlertAction.Create(Constants.TabsNames.FromGallery, UIAlertActionStyle.Default, action => {
                this.chooseFromGallery();
            }));
            alert.AddAction(UIAlertAction.Create(Constants.UI.Cancel, UIAlertActionStyle.Cancel, null));
            parent.PresentViewController(alert, animated: true, completionHandler: null);
        }

        /**
         * Function used to handle the from camera click. I opens the photos
         * and lets the user selet any photo from the gallery
         */
        private void chooseFromGallery() {
            this.imagePicker = new UIImagePickerController();
            this.imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            this.imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            this.imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            this.imagePicker.Canceled += Handle_Canceled;
            this.parent.PresentModalViewController(this.imagePicker, true);
        }

        private void chooseFromCamera() {
            this.imagePicker = new UIImagePickerController();
            this.imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
            this.imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);
            this.imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            this.imagePicker.Canceled += Handle_Canceled;
            this.parent.PresentModalViewController(this.imagePicker, true);
        }
        
        /**
         * Function used th handle the image selection
         */
        protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e) {
            // determine what was selected, video or image
            bool isImage = false;
            switch (e.Info[UIImagePickerController.MediaType].ToString()) {
                case "public.image":
                    isImage = true;
                    break;
                case "public.video":
                    break;
            }

            // get common info (shared between images and video)
            NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceURL")] as NSUrl;
            // if it was an image, get the other image info
            if (isImage) {
                // get the original image
                UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                
                if (originalImage != null) {
                    // do something with the image
                    UIImageView ImageView = new UIImageView(originalImage);
                    this.imagesList.Add(ImageView);
                    this.source.images = this.imagesList;
                    imageViewCollection.ReloadData();

                    var data = originalImage.AsPNG();
                    var dataBytes = new byte[data.Length];
                    System.Runtime.InteropServices.Marshal.Copy(data.Bytes, dataBytes, 0, Convert.ToInt32(data.Length));
                    var url = (NSUrl)e.Info.ValueForKey(new NSString("UIImagePickerControllerImageURL"));
                    String[] array = url.ToString().Split('/');
                    String fileName = array[array.Length - 1].Substring(0, array[array.Length - 1].Length - 5);
                    this.parent2.user.Images.Add(new UserFile(dataBytes, fileName, "jpg"));
                }
            }
            // dismiss the picker
            imagePicker.DismissModalViewController(true);
        }

        /**
         * Function used to handle the cancel button click
         */
        void Handle_Canceled(object sender, EventArgs e) {
            imagePicker.DismissModalViewController(true);
        }

        public class ImageSource : UICollectionViewSource {
            public List<UIImageView> images;

            public ImageSource(List<UIImageView> images) {
                this.images = images;
            }

            public override nint NumberOfSections(UICollectionView collectionView){
                return 1;
            }

            public override nint GetItemsCount(UICollectionView collectionView, nint section) {
                return images.Count;
            }

            public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath) {
                ImageViewCell cell = (ImageViewCell)collectionView.DequeueReusableCell(ImageViewCell.CellID, indexPath);
                cell.UpdateRow(this.images[indexPath.Row]);
                return cell;
            }
        }

        /**
         * Class to mock the cell inside the collection vew
         */
        public class ImageViewCell : UICollectionViewCell {
            public static NSString CellID = new NSString("ImageSource");
            public UIImageView ImageView;

            [Export("initWithFrame:")]
            public ImageViewCell(RectangleF frame): base(frame) {
                ImageView = new UIImageView();
                ImageView.ContentMode = UIViewContentMode.ScaleToFill;
                ContentView.AddSubview(ImageView);
            }

            public void UpdateRow(UIImageView image) {
                ImageView.Image = image.Image;
                ImageView.Frame = new RectangleF(0, 0, 155, 155);
            }
        }

        public class MyCollectionDelegate : UICollectionViewDelegate {
            UploadimagesCell parentController;

            public MyCollectionDelegate(UploadimagesCell parentController) {
                this.parentController = parentController;
            }

            public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath) {
                this.parentController.addImage_Clicked();
            }
        }
    }
}