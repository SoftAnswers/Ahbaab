using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asawer
{
    public class OnSignInEventArgs : EventArgs
    {
        private string mUserName;
        private string mPassword;
        private bool rememberMe;

        public string UserName
        {
            get { return this.mUserName; }
            set { this.mUserName = value; }
        }
        public string Password
        {
            get { return this.mPassword; }
            set { this.mPassword = value; }
        }

        public bool RememberMe
        {
            get { return this.rememberMe; }
            set { this.rememberMe = value; }
        }

        public OnSignInEventArgs(string userName, string password, bool rememberMe) : base()
        {
            this.UserName = userName;
            this.Password = password;
            this.RememberMe = rememberMe;
        }
    }
}
