using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahbab
{
    public class OnSignInEventArgs : EventArgs
    {
        private string mUserName;
        private string mPassword;

        public string UserName
        {
            get { return mUserName; }
            set { mUserName = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignInEventArgs(string userName, string password) : base()
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
