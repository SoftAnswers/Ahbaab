using System;
using System.Collections.Generic;
using Ahbab.Entities;
using Android.App;
using Android.Content;
using Android.Runtime;
using SharedCode;

namespace Ahbab.Droid
{
    [Application]
    public class Ahbab : Application
    {
        public static List<SpinnerItem> statusItems;
        public static List<SpinnerItem> mAgeItems;
        public static List<SpinnerItem> mContactTimeItems;
        public static List<SpinnerItem> mEducationItems;
        public static List<SpinnerItem> mEyesColorItems;
        public static List<SpinnerItem> mGoalFromSiteItems;
        public static List<SpinnerItem> mHairColorItems;
        public static List<SpinnerItem> mHeightItems;
        public static List<SpinnerItem> mJobItems;
        public static List<SpinnerItem> mCountries;
        public static List<SpinnerItem> mResidenceCountries;
        public static List<SpinnerItem> mTimeItems;
        public static List<SpinnerItem> mWeightItems;
        public static List<SpinnerItem> mContactWays;
        public static User CurrentUser;
        public static List<User> SearchResults;

        public Ahbab(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

        }


    }
}

