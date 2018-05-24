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
    public static class AhbabDatabase
    {
        public static async Task<User> Login(string userName, string password)
        {
            var mClient = new WebClient();

            User user = null;

            NameValueCollection parameters = new NameValueCollection
            {
                { "UserName", userName.Trim() },
                { "Password", password.Trim() }
            };

            var result = await mClient.UploadValuesTaskAsync(Constants.FunctionsUri.LoginUri, parameters);

            var resultString = Encoding.UTF8.GetString(result);

            if (!string.IsNullOrEmpty(resultString) && !resultString.Contains("Invalid") && !resultString.Contains("Empty"))
            {
                user = JsonConvert.DeserializeObject<List<User>>(resultString).FirstOrDefault();
            }

            return user;
        }

        public static List<SpinnerItem> GetSpinnerItems(Uri functionUri, string tableName)
        {
            var retVal = new List<SpinnerItem>();

            var mClient = new WebClient();

            NameValueCollection parameters = new NameValueCollection
            {
                { "TableName", tableName }
            };

            var result = mClient.UploadValues(functionUri, parameters);

            var items = Encoding.UTF8.GetString(result);

            retVal = JsonConvert.DeserializeObject<List<SpinnerItem>>(items);

            return retVal;
        }

        internal static string RegisterOrUpdate(string functionUri, User valueToUpload, List<UserFile> imgToDelete = null)
        {
            var mClient = new WebClient();

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

            var result = mClient.UploadValues(functionUri, parameters);

            var resultString = Encoding.UTF8.GetString(result);

            return resultString;
        }

        internal static List<User> Search(NameValueCollection parameters)
        {
            try
            {
                var mClient = new WebClient();

                var result = mClient.UploadValues(Constants.FunctionsUri.SearchUri, parameters);

                var resultString = Encoding.UTF8.GetString(result);

                var users = JsonConvert.DeserializeObject<List<User>>(resultString);

                return users;
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        internal static List<Message> GetMessages(Uri functionUri, int userID)
        {
            var messages = new List<Message>();

            try
            {
                var mClient = new WebClient();

                NameValueCollection parameters = new NameValueCollection
                {
                    { "userId", userID.ToString() }
                };

                var result = mClient.UploadValues(functionUri, parameters);

                var items = Encoding.UTF8.GetString(result);

                messages = JsonConvert.DeserializeObject<List<Message>>(items);

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
                var mClient = new WebClient();
                NameValueCollection parameters = new NameValueCollection
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

                var result = mClient.UploadValues(Constants.FunctionsUri.SendMessageUri, parameters);

                var resultAsString = Encoding.UTF8.GetString(result);

                return resultAsString;
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
                var mClient = new WebClient();

                NameValueCollection parameters = new NameValueCollection
                {
                    { "message", message },

                    { "level", level }
                };

                var result = mClient.UploadValues(Constants.FunctionsUri.LogMessage, parameters);

                return Encoding.UTF8.GetString(result);

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
                var mClient = new WebClient();
                NameValueCollection parameters = new NameValueCollection
                {
                    { "from", from.ToString() },
                    { "to", to.ToString() }
                };
                var result = mClient.UploadValues(Constants.FunctionsUri.VisitsUri, parameters);
                var resultString = Encoding.UTF8.GetString(result);
                return resultString;
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
                var mClient = new WebClient();
                NameValueCollection parameters = new NameValueCollection
                {
                    { destination, userId.ToString() },
                    { "TableName", tableName }
                };
                var result = mClient.UploadValues(Constants.FunctionsUri.GetActions, parameters);
                var resultString = Encoding.UTF8.GetString(result);
                var users = JsonConvert.DeserializeObject<List<User>>(resultString);
                return users;
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
                var mClient = new WebClient();
                NameValueCollection parameters = new NameValueCollection
                {
                    { "userId", userId.ToString() }
                };
                var result = mClient.UploadValues(Constants.FunctionsUri.Subscribe, parameters);
                var resultString = Encoding.UTF8.GetString(result);
                var user = JsonConvert.DeserializeObject<List<User>>(resultString).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                return new User();
            }
        }
    }
}
