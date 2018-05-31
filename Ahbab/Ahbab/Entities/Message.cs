using Newtonsoft.Json;
using System;
namespace Asawer
{
    public class Message
    {
        public Message()
        {

        }

        [JsonProperty(PropertyName = "message_id")]
        public int ID
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "from_account")]
        public int Sender
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "to_account")]
        public int Receiver
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "subject")]
        public string Subject
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "body")]
        public string Body
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "message_date")]
        public string MessageDate
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "")]
        public string MessageStatus
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "message_read")]
        public string MessageRead
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "username")]
        public string Username
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; set; }

        [JsonProperty(PropertyName = "audio_message")]
        public UserFile AudioMessage
        {
            get;
            set;
        }
    }
}

