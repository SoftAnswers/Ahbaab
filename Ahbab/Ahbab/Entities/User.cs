using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ahbab.Entities
{
    public class User
    {
        public User()
        {

        }

        //this constructor is used by the login activity
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        //this constructor is used by the registration activity
        public User(string userName, string password, string name, int age, string email, string gender,
                    int status, string ip, DateTime lastActiveDate, DateTime createdOn, int eyesColorId,
                    int heightId, int weightId, int usagePurposeId, int educationLevelId,
                    int originCountryId, int currentCountryId, int JobId, string selfDescription,
                    string othersDescription, string phoneNumber, string paid, int visitCountTo, int visitCountFrom,
                    int interestsTo, int interestsFrom, int blocksTo, int blocksFrom, int numberOfLogins, int active,
                    int timeFrameId, DateTime paidStartDate, DateTime paidEndDate, string accountStatus, int timeZoneId)
        {
            Initialize(userName, password, name, email, gender, status, ip, lastActiveDate, createdOn,
                       eyesColorId, heightId, weightId, usagePurposeId, educationLevelId, originCountryId,
                       currentCountryId, JobId, selfDescription, othersDescription, phoneNumber, paid, visitCountTo,
                       visitCountFrom, interestsTo, interestsFrom, blocksTo, blocksFrom, numberOfLogins, active,
                       timeFrameId, paidStartDate, paidEndDate, accountStatus, timeZoneId, 0);
        }

        //this constructor will be used by the whole app after login/registration
        public User(int id, string userName, string password, string name, int age, string email, string gender,
                    int status, string ip, DateTime lastActiveDate, DateTime createdOn, int eyesColorId,
                    int heightId, int weightId, int usagePurposeId, int educationLevelId,
                    int originCountryId, int currentCountryId, int JobId, string selfDescription,
                    string othersDescription, string phoneNumber, string paid, int visitCountTo, int visitCountFrom,
                    int interestsTo, int interestsFrom, int blocksTo, int blocksFrom, int numberOfLogins, int active,
                    int timeFrameId, DateTime paidStartDate, DateTime paidEndDate, string accountStatus, int timeZoneId, int userID)
        {
            this.ID = id;
            Initialize(userName, password, name, email, gender, status, ip, lastActiveDate, createdOn,
                       eyesColorId, heightId, weightId, usagePurposeId, educationLevelId, originCountryId,
                       currentCountryId, JobId, selfDescription, othersDescription, phoneNumber, paid, visitCountTo,
                       visitCountFrom, interestsTo, interestsFrom, blocksTo, blocksFrom, numberOfLogins, active,
                       timeFrameId, paidStartDate, paidEndDate, accountStatus, timeZoneId, userID);
        }

        public int UserID{ get; set; }
        public string UserName { get; set; }
        public int ID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string IP { get; set; }
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int EyesColorId { get; set; }
        public int HairColorId { get; set; }
        public int HeightId { get; set; }
        public int WeightId { get; set; }
        public int UsagePurposeId { get; set; }
        public int EducationLevelID { get; set; }
        public int OriginCountryId { get; set; }
        public int CurrentCountryId { get; set; }
        public int JobId { get; set; }
        public string SelfDescription { get; set; }
        public string OthersDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Paid { get; set; }
        public int VisitCountTo { get; set; }
        public int VisitCountFrom { get; set; }
        public int InterestsTo { get; set; }
        public int InterestsFrom { get; set; }
        public int BlocksTo { get; set; }
        public int BlocksFrom { get; set; }
        public int NumberOfLogins { get; set; }
        public int Active { get; set; }
        public int TimeFrameId { get; set; }
        public DateTime PaidStartDate { get; set; }
        public DateTime PaidEndDate { get; set; }
        public string AccountStatus { get; set; }
        public int TimeZoneId { get; set; }
        public UserImage Image { get; set; }
        public List<UserImage> Images { get; set; }
        public string[] ImageNames { get; set; }
        public string[] ImageBase64 { private get; set; }
        public List<byte[]> ImageBytes {
            get {
                List<Byte[]> userImages = new List<byte[]>();
                for (int i = 0; i < ImageBase64.Length; i++) {
                    if (!string.IsNullOrEmpty(this.ImageBase64[i])) {
                        byte[] image = Convert.FromBase64String(this.ImageBase64[i]);
                        userImages.Add(image);
                    }
                }
                if (userImages.Count > 0)
                    return userImages;
                return null;
            }
        }

        public List<ContactWay> ContactWays { get; set; }

        void Initialize(string userName, string password, string name, string email,
                        string gender, int status, string ip, DateTime lastActiveDate,
                        DateTime createdOn, int eyesColorId, int heightId, int weightId,
                        int usagePurposeId, int educationLevelId, int originCountryId,
                        int currentCountryId, int jobId, string selfDescription,
                        string othersDescription, string phoneNumber, string paid, int visitCountTo,
                        int visitCountFrom, int interestsTo, int interestsFrom, int blocksTo,
                        int blocksFrom, int numberOfLogins, int active, int timeFrameId, DateTime paidStartDate,
                        DateTime paidEndDate, string accountStatus, int timeZoneId, int userID)
        {
            this.UserName = userName;
            this.Password = password;
            this.Name = name;
            this.Age = Age;
            this.Email = email;
            this.Gender = gender;
            this.Status = status;
            this.IP = ip;
            this.LastActiveDate = lastActiveDate;
            this.CreatedOn = createdOn;
            this.EyesColorId = eyesColorId;
            this.HeightId = heightId;
            this.WeightId = weightId;
            this.UsagePurposeId = usagePurposeId;
            this.EducationLevelID = educationLevelId;
            this.OriginCountryId = originCountryId;
            this.CurrentCountryId = currentCountryId;
            this.JobId = jobId;
            this.SelfDescription = selfDescription;
            this.OthersDescription = othersDescription;
            this.PhoneNumber = phoneNumber;
            this.Paid = paid;
            this.VisitCountTo = visitCountTo;
            this.VisitCountFrom = visitCountFrom;
            this.InterestsTo = interestsTo;
            this.InterestsFrom = interestsFrom;
            this.BlocksTo = blocksTo;
            this.BlocksFrom = blocksFrom;
            this.NumberOfLogins = numberOfLogins;
            this.Active = active;
            this.TimeFrameId = timeFrameId;
            this.PaidStartDate = paidStartDate;
            this.PaidEndDate = paidEndDate;
            this.AccountStatus = accountStatus;
            this.TimeZoneId = timeZoneId;
            this.UserID = userID;
        }

    }
}
