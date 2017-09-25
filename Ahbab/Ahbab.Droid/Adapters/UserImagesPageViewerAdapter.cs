using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Ahbab.Droid.Adapters {
    class UserImagesPageViewerAdapter : PagerAdapter {

        Context context;
        List<byte[]> userImages;

        public UserImagesPageViewerAdapter(Context context, List<byte[]> userImages) {
            this.context = context;
            this.userImages = userImages;
        }

        //Returns the number of user images
        public override int Count {
            get { return this.userImages.Count; }
        }

        public override Java.Lang.Object InstantiateItem(View container, int position) {
            var imageView = new ImageView(context);
            imageView.SetImageBitmap(BitmapFactory.DecodeByteArray(this.userImages[position], 0, this.userImages[position].Length));
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.AddView(imageView);
            return imageView;
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object view) {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj) {
            return view == obj;
        }

    }
}