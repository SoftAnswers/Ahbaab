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
        private static bool? getSpinnersFromDatabasrCompleted;
        public static Task GetSpinnersFromDatabaseTask { get => getSpinnersFromDatabaseTask; set => getSpinnersFromDatabaseTask = value; }
        public static bool GetSpinnersFromDatabasrCompleted
        {
            get
            {
                if (getSpinnersFromDatabasrCompleted == null)
                {
                    getSpinnersFromDatabasrCompleted = false;
                }

                return getSpinnersFromDatabasrCompleted.Value;
            }
            set => getSpinnersFromDatabasrCompleted = value;
        }



        public Ahbab(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            try
            {
                var tasks = GetSpinnersItems();

                GetSpinnersFromDatabaseTask = Task.WhenAll(tasks);

                GetSpinnersFromDatabaseTask.ContinueWith(t =>
                {

                    GetSpinnersFromDatabasrCompleted = true;
                });
            }
            catch (Exception ex)
            {

            }
        }

        private static Task[] GetSpinnersItems()
        {
            var tasks = new List<Task>();

            tasks.Add(Task.Run(() =>
            {
                Ahbab.statusItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                            Constants.Tables.Status);
                Ahbab.statusItems.Insert(0, new SpinnerItem(-1, "Choose", Constants.DefaultValues.FamilyStatus));
            }));


            tasks.Add(Task.Run(() =>
            {
                Ahbab.mAgeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                          Constants.Tables.Age);
                Ahbab.mAgeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Age));
            }));


            tasks.Add(Task.Run(() =>
            {
                Ahbab.mContactTimeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                                                    Constants.Tables.ContactTime);
                Ahbab.mContactTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ContactTime));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mEducationItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                                               Constants.Tables.Education);
                Ahbab.mEducationItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EducationLevel));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mEyesColorItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                      Constants.Tables.EyesColor);
                Ahbab.mEyesColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.EyesColor));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mGoalFromSiteItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                      Constants.Tables.GoalFromSite);

                Ahbab.mGoalFromSiteItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.GoalFromSite));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mHairColorItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                      Constants.Tables.HairColor);
                Ahbab.mHairColorItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.HairColor));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mHeightItems =
                AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                      Constants.Tables.Height);
                Ahbab.mHeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Height));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mJobItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                      Constants.Tables.Job);
                Ahbab.mJobItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Job));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mCountries = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                          Constants.Tables.Countries);
                Ahbab.mCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.OriginCountry));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mResidenceCountries = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
             Constants.Tables.Countries);
                Ahbab.mResidenceCountries.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.ResidenceCountry));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mContactWays = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
               Constants.Tables.ContactWays);
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mTimeItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetTwoColumnsSpinnersItemUri),
                      Constants.Tables.Time);
                Ahbab.mTimeItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.TimeZone));
            }));

            tasks.Add(Task.Run(() =>
            {
                Ahbab.mWeightItems = AhbabDatabase.GetSpinnerItems(new Uri(Constants.FunctionsUri.GetSpinnerItemsUri),
                     Constants.Tables.Weight);
                Ahbab.mWeightItems.Insert(0, new SpinnerItem(0, "Choose", Constants.DefaultValues.Weight));
            }));

            return tasks.ToArray();
        }
    }
}

