using Ahbab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Ahbab;

namespace SharedCode
{
    public static class AhbabDatabase
    {
        public static User Login(string userName, string password)
        {
            var mClient = new WebClient();

            User user = null;

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("UserName", userName.Trim());
            parameters.Add("Password", password.Trim());

            var result = mClient.UploadValues(Constants.FunctionsUri.LoginUri, parameters);

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

            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("TableName", tableName);

            var result = mClient.UploadValues(functionUri, parameters);

            var items = Encoding.UTF8.GetString(result);

            retVal = JsonConvert.DeserializeObject<List<SpinnerItem>>(items);

            return retVal;
        }

        internal static string RegisterOrUpdate(string functionUri, User valueToUpload)
        {
            var mClient = new WebClient();

            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("user", valueToUpload.UserName);
            parameters.Add("pass", valueToUpload.Password);
            parameters.Add("mail", valueToUpload.Email);
            parameters.Add("name", valueToUpload.Name);
            parameters.Add("gender", valueToUpload.Gender);
            parameters.Add("status", valueToUpload.Status.ToString());
            parameters.Add("eyecolor", valueToUpload.EyesColorId.ToString());
            parameters.Add("haircolor", valueToUpload.HairColorId.ToString());
            parameters.Add("height", valueToUpload.HeightId.ToString());
            parameters.Add("weight", valueToUpload.WeightId.ToString());
            parameters.Add("usagepurpose", valueToUpload.UsagePurposeId.ToString());
            parameters.Add("age", valueToUpload.Age.ToString());
            parameters.Add("educlevel", valueToUpload.EducationLevelID.ToString());
            parameters.Add("origin", valueToUpload.OriginCountryId.ToString());
            parameters.Add("current", valueToUpload.CurrentCountryId.ToString());
            parameters.Add("job", valueToUpload.JobId.ToString());
            parameters.Add("describeyou", valueToUpload.SelfDescription);
            parameters.Add("describeother", valueToUpload.OthersDescription);
            parameters.Add("available", valueToUpload.TimeFrameId.ToString());
            parameters.Add("timezone", valueToUpload.TimeZoneId.ToString());
            parameters.Add("way", JsonConvert.SerializeObject(valueToUpload.ContactWays));
            //parameters.Add("wayval", string.Empty);
            parameters.Add("accept", "Y");
            if (valueToUpload.Images.Count > 0)
            {
                parameters.Add("Images", JsonConvert.SerializeObject(valueToUpload.Images));
            }
            else
            {
                parameters.Add("Images", string.Empty);
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

                NameValueCollection parameters = new NameValueCollection();

                parameters.Add("userid", userID.ToString());

                var result = mClient.UploadValues(functionUri, parameters);

                var items = Encoding.UTF8.GetString(result);

                messages = JsonConvert.DeserializeObject<List<Message>>(items);

            }
            catch (Exception ex)
            {

            }

            return messages;
        }

        internal static string SendMessage(Message message)
        {
            try
            {
                var mClient = new WebClient();

                NameValueCollection parameters = new NameValueCollection();

                parameters.Add("from", message.Sender.ToString());

                parameters.Add("to", message.Receiver.ToString());

                parameters.Add("subject", message.Subject);

                parameters.Add("body", message.Body);

                var result = mClient.UploadValues(Constants.FunctionsUri.SendMessageUri, parameters);

                return Encoding.UTF8.GetString(result);

            }
            catch (Exception ex)
            {
                return "Send Failed";
            }
        }

        internal static string LogMessage(String message, String level) {
            try {
                var mClient = new WebClient();

                NameValueCollection parameters = new NameValueCollection();

                parameters.Add("message", message);

                parameters.Add("level", level);

                var result = mClient.UploadValues(Constants.FunctionsUri.LogMessage, parameters);

                return Encoding.UTF8.GetString(result);

            }
            catch (Exception ex) {
                return "Logging Failed";
            }
        }
    }
}
