using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Runtime;
using Asawer.Entities;
using SharedCode;

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
        private static Task getSpinnersFromDatabaseTask;
        public static Task GetSpinnersFromDatabaseTask { get => getSpinnersFromDatabaseTask; set => getSpinnersFromDatabaseTask = value; }

        public Ahbab(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            try
            {
                GetSpinnersFromDatabaseTask =  Task.Run(() => GetSpinnersItems());
                GetSpinnersFromDatabaseTask.Start();
            }
            catch (Exception ex)
            {
                
            }
        }

        private static async void GetSpinnersItems()
        {
            Ahbab.statusItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                        Constants.Tables.Status));

            Ahbab.statusItems.Insert(0, new SpinnerItem(-1, "Choose", Constants.DefaultValues.FamilyStatus));

            Ahbab.mAgeItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                                      Constants.Tables.Age));
            Ahbab.mAgeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Age));

            Ahbab.mContactTimeItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                                                 Constants.Tables.ContactTime));
            Ahbab.mContactTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ContactTime));

            Ahbab.mEducationItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                            Constants.Tables.Education));
            Ahbab.mEducationItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EducationLevel));

            Ahbab.mEyesColorItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                            Constants.Tables.EyesColor));
            Ahbab.mEyesColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EyesColor));

            Ahbab.mGoalFromSiteItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                               Constants.Tables.GoalFromSite));
            Ahbab.mGoalFromSiteItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.GoalFromSite));

            Ahbab.mHairColorItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                            Constants.Tables.HairColor));
            Ahbab.mHairColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.HairColor));

            Ahbab.mHeightItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                         Constants.Tables.Height));
            Ahbab.mHeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Height));

            Ahbab.mJobItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                      Constants.Tables.Job));
            Ahbab.mJobItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Job));

            Ahbab.mCountries = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                       Constants.Tables.Countries));
            Ahbab.mCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.OriginCountry));

            Ahbab.mResidenceCountries = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                       Constants.Tables.Countries));
            Ahbab.mResidenceCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ResidenceCountry));

            Ahbab.mContactWays = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                  Constants.Tables.ContactWays));

            Ahbab.mTimeItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                                       Constants.Tables.Time));
            Ahbab.mTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.TimeZone));

            Ahbab.mWeightItems = await Task.Run(() => AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                                        Constants.Tables.Weight));
            Ahbab.mWeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Weight));
        }
    }
}

