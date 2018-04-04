using System;
namespace Asawer
{
	public class Message
	{
		public Message()
		{

		}

		public int ID
		{
			get 
			{
				return this.message_id;
			}
			set 
			{
				this.message_id = value;
			}
		}

		public int Sender
		{
			get
			{
				return this.from_account;
			}
			set
			{
				this.from_account = value;
			}
		}

		public int Receiver
		{
			get 
			{
				return this.to_account;
			}
			set 
			{ 
				this.to_account = value;
			}
		}

		public string Subject
		{
			get
			{
				return this.subject;
			}
			set
			{
				this.subject = value;
			}
		}

		public string Body
		{
			get 
			{
				return this.body;
			}
			set
			{
				this.body = value;
			}
		}

		public string MessageDate
		{
			get 
			{
				return this.message_date.ToString("dd-MM-yyyy");
			}
			set
			{
				this.message_date = DateTime.Parse(value);
			}
		}

		public string MessageStatus
		{
			get;
			set;
		}

		public string MessageRead
		{
			get 
			{
				return this.message_read;
			}
			set
			{
				this.message_read = value;
			}
		}

        public string Username {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }

        public int message_id { private get; set;}
		public int from_account { private get; set;}
		public string subject { private get; set;}
		public DateTime message_date { private get; set;}
		public string message_read { private get; set;}
		public string body { private get; set;}
		public int to_account { private get; set; }
        public string username { private get; set; }
	}
}

