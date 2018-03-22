using System;
namespace Asawer
{
	public class OnSendMessageEventArgs: EventArgs
	{
		private string mSubject;
		private string mBody;

		public string Subject
		{
			get { return mSubject; }
			set { mSubject = value; }
		}
		public string Body
		{
			get { return mBody; }
			set { mBody = value; }
		}

		public OnSendMessageEventArgs(string subject, string body) : base()
        {
			this.Subject = subject;
			this.Body = body;
		}
	}
}
