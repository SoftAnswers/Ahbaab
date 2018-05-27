using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Runtime;
using Asawer.Entities;
using SharedCode;
using Asawer.Droid.Helpers;

namespace Asawer.Droid
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
        private static string localDatabasePath;

        public static string LocalDatabasePath { get => localDatabasePath; set => localDatabasePath = value; }

        public Ahbab(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            LocalDatabasePath = FileAccessHelper.GetLocalFilePath(Constants.Database.LocalDatabaseName);
            
            LocalDatabaseAccess.CreateTable<SpinnerItem>(LocalDatabasePath);
        }
    }
}

