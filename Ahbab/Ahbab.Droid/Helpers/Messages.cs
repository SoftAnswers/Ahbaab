﻿using System;
using System.Collections.Generic;
using Android.Graphics;

namespace Ahbab.Droid
{
	public class Messages
	{
		private static Random RANDOM = new Random();

		public static int RandomMessagesDrawable 
		{
			get 
			{
				switch (RANDOM.Next(5))
				{
					default:
					case 0:
						return Resource.Drawable.Icon;
					case 1:
						return Resource.Drawable.femaleOn;
					case 2:
						return Resource.Drawable.femaleUsers;
					case 3:
						return Resource.Drawable.maleOn;
					case 4:
						return Resource.Drawable.maleOff;
				}
			}
		}


		internal static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Raw height and width of image
			int height = options.OutHeight;
			int width = options.OutWidth;
			int inSampleSize = 1;

			if (height > reqHeight || width > reqWidth)
			{

				// Calculate ratios of height and width to requested height and
				// width
				int heightRatio = height / reqHeight;
				int widthRatio = width / reqWidth;

				// Choose the smallest ratio as inSampleSize value, this will
				// guarantee
				// a final image with both dimensions larger than or equal to the
				// requested height and width.
				inSampleSize = heightRatio < widthRatio ? heightRatio : widthRatio;
			}

			return inSampleSize;
		}

}
}
