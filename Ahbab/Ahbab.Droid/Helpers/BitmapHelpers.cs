using System;
using System.IO;
using Android.Content;
using Android.Graphics;
using Android.Media;
using static Android.Graphics.Bitmap;

namespace Asawer.Droid
{
    public static class BitmapHelpers
    {
        public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            options.InSampleSize = CalculateInSampleSize(options, width, height);

            options.InJustDecodeBounds = false;

            options.InPreferredConfig = Config.Rgb565;

            options.InDither = true;

            options.InPurgeable = true;

            var resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }

        public static Bitmap DecodeBitmapFromStream(Context context, Android.Net.Uri data,
                                                     int requestedWidth, int requestedHeight)
        {
            //Decode with InJustDecodeBounds = true to check dimensions
            System.IO.Stream stream = context.ContentResolver.OpenInputStream(data);
            BitmapFactory.Options options = new BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };
            BitmapFactory.DecodeStream(stream);

            //Calculate InSamplesize
            options.InSampleSize = CalculateInSampleSize(options, requestedWidth, requestedHeight);

            //Decode bitmap with InSampleSize set
            stream = context.ContentResolver.OpenInputStream(data); //Must read again
            options.InJustDecodeBounds = false;
            Bitmap bitmap = BitmapFactory.DecodeStream(stream, null, options);
            return bitmap;
        }

        private static int CalculateInSampleSize(BitmapFactory.Options options, int requestedWidth, int requestedHeight)
        {
            //Raw height and widht of image
            int height = options.OutHeight;
            int width = options.OutWidth;
            int inSampleSize = 1;

            if (height > requestedHeight || width > requestedWidth)
            {
                //the image is bigger than we want it to be
                int halfHeight = height / 2;
                int halfWidth = width / 2;

                while ((halfHeight / inSampleSize) > requestedHeight && (halfWidth / inSampleSize) > requestedWidth)
                {
                    inSampleSize *= 2;
                }

            }

            return inSampleSize;
        }
    }
}

