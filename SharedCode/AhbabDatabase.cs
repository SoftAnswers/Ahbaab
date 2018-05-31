using Asawer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Asawer;
using System.Threading.Tasks;

namespace SharedCode
{
    public class AhbabDatabase
    {
        protected static readonly string HostIP = "http://www.asawer.net/api/{0}";
        //protected static readonly string HostIP = "http://192.168.1.112/api/{0}";

        public static async Task<User> Login(string userName, string password)
        {
            using (var mClient = new WebClient())
            {
                User user = null;

                var parameters = new NameValueCollection
                {
                    { "UserName", userName.Trim() },
                    { "Password", password.Trim() }
                };

                var address = string.Format(HostIP, Constants.Database.ApiFiles.LoginFileName);

                var result = await mClient.UploadValuesTaskAsync(address, parameters);

                var resultString = Encoding.UTF8.GetString(result);

                if (!string.IsNullOrEmpty(resultString) && !resultString.Contains("Invalid") && !resultString.Contains("Empty"))
                {
                    user = JsonConvert.DeserializeObject<List<User>>(resultString).FirstOrDefault();
                }

                return user;
            }
        }

        public static List<SpinnerItem> GetSpinnerItems(string functionUri, string tableName)
        {
            var retVal = new List<SpinnerItem>();

            using (var mClient = new WebClient())
            {

                var parameters = new NameValueCollection
                {
                    { "TableName", tableName }
                };

                var address = string.Format(HostIP, functionUri);

                var result = mClient.UploadValues(address, parameters);

                var items = Encoding.UTF8.GetString(result);

                retVal = JsonConvert.DeserializeObject<List<SpinnerItem>>(items);
            }
            return retVal;
        }

        internal static string RegisterOrUpdate(string functionUri, User valueToUpload, List<UserFile> imgToDelete = null)
        {
            using (var mClient = new WebClient())
            {
                NameValueCollection parameters = new NameValueCollection
            {
                { "userid", valueToUpload.ID.ToString() },
                { "user", valueToUpload.UserName },
                { "pass", valueToUpload.Password },
                { "mail", valueToUpload.Email },
                { "name", valueToUpload.Name },
                { "gender", valueToUpload.Gender },
                { "status", valueToUpload.Status.ToString() },
                { "eyecolor", valueToUpload.EyesColorId.ToString() },
                { "haircolor", valueToUpload.HairColorId.ToString() },
                { "height", valueToUpload.HeightId.ToString() },
                { "weight", valueToUpload.WeightId.ToString() },
                { "usagepurpose", valueToUpload.UsagePurposeId.ToString() },
                { "age", valueToUpload.Age.ToString() },
                { "educlevel", valueToUpload.EducationLevelID.ToString() },
                { "origin", valueToUpload.OriginCountryId.ToString() },
                { "current", valueToUpload.CurrentCountryId.ToString() },
                { "job", valueToUpload.JobId.ToString() },
                { "describeyou", valueToUpload.SelfDescription },
                { "describeother", valueToUpload.OthersDescription },
                { "available", valueToUpload.TimeFrameId.ToString() },
                { "timezone", valueToUpload.TimeZoneId.ToString() },
                { "way", JsonConvert.SerializeObject(valueToUpload.ContactWays) },
                //parameters.Add("wayval", string.Empty);
                { "accept", "Y" }
            };

                if (valueToUpload.Images.Count > 0)
                {
                    parameters.Add("Images", JsonConvert.SerializeObject(valueToUpload.Images));
                }
                else
                {
                    parameters.Add("Images", string.Empty);
                }
                if (imgToDelete != null)
                {
                    parameters.Add("ImagesToDelete", JsonConvert.SerializeObject(imgToDelete));
                }

                var address = string.Format(HostIP, functionUri);

                var result = mClient.UploadValues(address, parameters);

                var resultString = Encoding.UTF8.GetString(result);

                return resultString;
            }
        }

        internal static List<User> Search(NameValueCollection parameters)
        {
            try
            {
                using (var mClient = new WebClient())
                {
                    var address = string.Format(HostIP, Constants.Database.ApiFiles.SearchFileName);

                    var result = mClient.UploadValues(address, parameters);

                    var resultString = Encoding.UTF8.GetString(result);

                    var users = JsonConvert.DeserializeObject<List<User>>(resultString);

                    return users;
                }
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        internal static List<Message> GetMessages(string functionUri, int userID)
        {
            var messages = new List<Message>();

            try
            {
                using (var mClient = new WebClient())
                {
                    var parameters = new NameValueCollection
                    {
                        { "userId", userID.ToString() }
                    };

                    var address = string.Format(HostIP, functionUri);

                    var result = mClient.UploadValues(address, parameters);

                    var items = Encoding.UTF8.GetString(result);

                    messages = JsonConvert.DeserializeObject<List<Message>>(items);
                }
            }
            catch (Exception ex)
            {

            }

            return messages;
        }

        internal static string SendMessage(Message message, string sex)
        {
            try
            {
                using (var mClient = new WebClient())
                {
                    var parameters = new NameValueCollection
                    {
                        { "from", message.Sender.ToString() },
                        { "to", message.Receiver.ToString() },
                        { "subject", message.Subject },
                        { "body", message.Body },
                        { "gender", sex },
                        {"audioMessage",
                            !string.IsNullOrEmpty(message.AudioMessage.FileName)
                            ? JsonConvert.SerializeObject(message.AudioMessage)
                            : null
                        }
                    };

                    var address = string.Format(HostIP, Constants.Database.ApiFiles.SendMessageFileName);

                    var result = mClient.UploadValues(address, parameters);

                    var resultAsString = Encoding.UTF8.GetString(result);

                    return resultAsString;
                }
            }
            catch (Exception)
            {
                return "Send Failed";
            }
        }

        internal static string LogMessage(String message, String level)
        {
            try
            {
                using (var mClient = new WebClient())
                {
                    var parameters = new NameValueCollection
                    {
                        { "message", message },

                        { "level", level }
                    };

                    var address = string.Format(HostIP, Constants.Database.ApiFiles.LogMessageFileName);

                    var result = mClient.UploadValues(address, parameters);

                    return Encoding.UTF8.GetString(result);
                }

            }
            catch (Exception)
            {
                return "Logging Failed";
            }
        }

        internal static string UpdateVisits(int from, int to)
        {
            try
            {

                using (var mClient = new WebClient())
                {
                    var parameters = new NameValueCollection
                    {
                        { "from", from.ToString() },
                        { "to", to.ToString() }
                    };

                    var address = string.Format(HostIP, Constants.Database.ApiFiles.VisitsFileName);

                    var result = mClient.UploadValues(address, parameters);
                    var resultString = Encoding.UTF8.GetString(result);
                    return resultString;
                }
            }
            catch (Exception)
            {
                return "Update Visits failed";
            }
        }

        internal static List<User> GetActions(int userId, string tableName, string destination)
        {
            try
            {
                using (var mClient = new WebClient())
                {
                    var parameters = new NameValueCollection
                    {
                        { destination, userId.ToString() },
                        { "TableName", tableName }
                    };

                    var address = string.Format(HostIP, Constants.Database.ApiFiles.GetActionsFileName);

                    var result = mClient.UploadValues(address, parameters);

                    var resultString = Encoding.UTF8.GetString(result);

                    var users = JsonConvert.DeserializeObject<List<User>>(resultString);

                    return users;
                }
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        internal static User Subscribe(int userId)
        {
            try
            {
                using (var mClient = new WebClient())
                {
                    var parameters = new NameValueCollection
                    {
                        { "userId", userId.ToString() }
                    };

                    var address = string.Format(HostIP, Constants.Database.ApiFiles.SubscribeFileName);

                    var result = mClient.UploadValues(address, parameters);

                    var resultString = Encoding.UTF8.GetString(result);

                    var user = JsonConvert.DeserializeObject<List<User>>(resultString).FirstOrDefault();

                    return user;
                }
            }
            catch (Exception)
            {
                return new User();
            }
        }

        internal static void SendBlockOrInterest(string functionUri, int fromUserId, int toUserId, UploadValuesCompletedEventHandler handler)
        {
            var parameters = new NameValueCollection()
            {
                { "from", fromUserId.ToString()},
                { "to", toUserId.ToString()}
            };

            var address = string.Format(HostIP, functionUri);

            using (var client = new WebClient())
            {
                client.UploadValuesCompleted += handler;

                client.UploadValuesAsync(new Uri(address), parameters);
            }
        }

        internal static void DeleteMessage(string functionUri, int messageId, UploadValuesCompletedEventHandler handler)
        {
            var parameters = new NameValueCollection()
            {
                { "messageId", messageId.ToString()}
            };

            var address = string.Format(HostIP, functionUri);

            using (var client = new WebClient())
            {
                client.UploadValuesCompleted += handler;

                client.UploadValuesAsync(new Uri(address), parameters);
            }
        }
    }
}
