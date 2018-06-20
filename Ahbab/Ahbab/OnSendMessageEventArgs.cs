using System;
namespace Asawer
{
    public class OnSendMessageEventArgs : EventArgs
    {
        private string mSubject;
        private string mBody;
        private byte[] fileBytes;

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
        public byte[] FileBytes
        {
            get { return this.fileBytes; }
            set { this.fileBytes = value; }
        }

        public OnSendMessageEventArgs(string subject, string body, byte[] fileBytes)
            : base()
        {
            this.Subject = subject;
            this.Body = body;
            this.FileBytes = fileBytes;
        }
    }
}
