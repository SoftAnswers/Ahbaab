using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Runtime;
using Asawer.Entities;
using Asawer;
using SharedCode;
using Asawer.Droid.Helpers;
using System.Linq;

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
        public static string FirebaseInstanceIdToken;
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

            if (!Settings.FirstVisit)
            {
                this.GetSpinnersItemsFromLocalDatabase();
            }
        }

        private void GetSpinnersItemsFromLocalDatabase()
        {
            var allSpinnersItems = LocalDatabaseAccess.GetAllItems<SpinnerItem>(Ahbab.LocalDatabasePath);

            Ahbab.statusItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.StatusType).ToList();

            Ahbab.statusItems.Insert(0, new SpinnerItem(-1, Constants.DefaultValues.Choose, Constants.DefaultValues.FamilyStatus));

            Ahbab.mAgeItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.AgeType).ToList();

            Ahbab.mAgeItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Age));

            Ahbab.mContactTimeItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.ContactTimeType).ToList();

            Ahbab.mContactTimeItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.ContactTime));

            Ahbab.mEducationItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.EducationType).ToList();

            Ahbab.mEducationItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.EducationLevel));

            Ahbab.mEyesColorItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.EyesColorType).ToList();

            Ahbab.mEyesColorItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.EyesColor));

            Ahbab.mGoalFromSiteItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.GoalFromSiteType).ToList();

            Ahbab.mGoalFromSiteItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.GoalFromSite));

            Ahbab.mHairColorItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.HairColorType).ToList();

            Ahbab.mHairColorItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.HairColor));

            Ahbab.mHeightItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.HeightType).ToList();

            Ahbab.mHeightItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Height));

            Ahbab.mJobItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.JobType).ToList();

            Ahbab.mJobItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Job));

            Ahbab.mCountries = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.CountryType).ToList();

            Ahbab.mCountries.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.OriginCountry));

            Ahbab.mResidenceCountries = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.CountryType).ToList();

            Ahbab.mResidenceCountries.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.ResidenceCountry));

            Ahbab.mContactWays = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.ContactWaysType).ToList();

            Ahbab.mTimeItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.TimeType).ToList();

            Ahbab.mTimeItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.TimeZone));

            Ahbab.mWeightItems = allSpinnersItems.Where(i => i.Type == Constants.ItemTypes.WeightType).ToList();

            Ahbab.mWeightItems.Insert(0, new SpinnerItem(0, Constants.DefaultValues.Choose, Constants.DefaultValues.Weight));
        }
    }
}

