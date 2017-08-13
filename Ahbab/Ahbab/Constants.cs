using System;
namespace Ahbab
{
    public struct Constants
    {
        public struct Tables
        {
            public const string Countries = "countries";
            public const string Status = "marital_status";
            public const string Age = "ages";
            public const string ContactTime = "available_time";
            public const string Education = "educ_levels";
            public const string EyesColor = "eye_colors";
            public const string GoalFromSite = "usage_purpose";
            public const string HairColor = "hair_color";
            public const string Height = "heights";
            public const string Job = "jobs";
            public const string Time = "timezones";
            public const string Weight = "weights";
            public const string About = "about";
            public const string Accounts = "accounts";
            public const string Blocks = "blocks";
            public const string BulkMessages = "bulkmessages";
            public const string CardCompanies = "card_companies";
            public const string Categories = "categories";
            public const string ContactPreferneces = "contact_preferences";
            public const string ContactWays = "contact_ways";
            public const string Emails = "emails";
            public const string Images = "images";
            public const string Interests = "interests";
            public const string LastActivity = "lastactivity";
            public const string MassMessage = "mass_message";
            public const string Messages = "messages";
            public const string PendingEmails = "pendingmail";
            public const string Privacy = "privacy";
            public const string Scrolling = "scrolling";
            public const string SecurityWarnings = "securitywarnings";
            public const string TempMass = "tempmass";
            public const string Transactions = "transactions";
            public const string UserColors = "user_colors";
            public const string Users = "users";
            public const string Visits = "visits";
        }

        public struct FunctionsUri
        {
            //private const string HostIP = "http://www.ahbaab.net/app";
            private const string HostIP = "http://192.168.2.236/ahbab/api"; 

            public const string GetSpinnerItemsUri = "http://192.168.2.236/ahbab/api/GetsAllItemsFromTable.php";
            public const string GetTwoColumnsSpinnersItemUri = "http://192.168.2.236/ahbab/api/GetItemsFromTableWithTwoColumns.php";
            public const string LoginUri = "http://192.168.2.236/ahbab/api/Login.php";
            public const string RegisterUri = "http://192.168.2.236/ahbab/api/AppRegister.php";
            public const string SearchUri = "http://192.168.2.236/ahbab/api/AppSearch.php";
            public const string InboxUri = "http://192.168.2.236/ahbab/api/inbox.php";
            public const string OutboxUri = "http://192.168.2.236/ahbab/api/outbox.php";
            public const string UpdateUri = "http://192.168.2.236/ahbab/api/update.php";
            public const string SendMessageUri = "http://192.168.2.236/ahbab/api/SendMessage.php";
            public const string BlockUri = "http://192.168.2.236/ahbab/api/block.php";
            public const string InterestUri = "http://192.168.2.236/ahbab/api/interest.php";
            public const string DeleteMessageUri = "http://192.168.2.236/ahbab/api/DeleteMessage.php";
            public const string LogMessage = "http://192.168.2.236/ahbab/api/AppLogging.php";
        }

        public struct TabsNames
        {
            public const string Search = "البحث";
            public const string Inbox = "الوارد";
            public const string Outbox = "الصادر";
            public const string FromCamera = "من الكاميرا";
            public const string FromGallery = "من الغاليري";
            public const string Cancel = "إلغاء";
            public const string AddPhoto = "أضف صورة";

        }

        public struct DefaultValues
        {
            public const string NA = "غير متاح";
            public const string FamilyStatus = "الوضع العائلي";
            public const string EyesColor = "لون العين";
            public const string HairColor = "لون الشعر";
            public const string Height = "الطول";
            public const string Weight = "الوزن";
            public const string GoalFromSite = "الهدف من الموقع";
            public const string Age = "العمر";
            public const string EducationLevel = "المستوى العلمي";
            public const string OriginCountry = "بلد الأصل";
            public const string ResidenceCountry = "بلد السكن";
            public const string Job = "الوظيفة";
            public const string TimeZone = "توقيت";
            public const string ContactTime = "الوقت للإتصال";
        }

        public struct UI
        {
            public const string RegistrationLoader = "الرجاء الانتظار، يتم التسجيل";
            public const string SuccessfullRegistration = "تم التسجيل بنجاح";
            public const string UpdateLoader = "الرجاء الانتظار، يتم تحديث المعلومات";
            public const string SuccessfullUpdate = "تم التحديث بنجاح";
            public const string ErrorOccured = "حصل خطأ";
            public const string Upgrade = "عليك أن تكون مشتركاً لتكمل";
            public const string Cancel = "إلغاء";
            public const string Subscribe = "إشترك";
            public const string Subscription = "إشتراك";
            public const string MessageDeleted = "تم حذف الرسالة";
            public const string LogoutMessage = "هل أنت متأكد من الخروج";
            public const string LogoutHeader = "تسجيل الخروج";
            public const string Logout = "خروج";
        }
    }
}

