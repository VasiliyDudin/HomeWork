using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal interface IUserSettings
    {
        protected int MinNumb { get; set; }
        protected int MaxNumb { get; set; }
        protected int Numb { get; set; }
        protected int Count { get; set; }
        public bool CheckDip(int pinpnmb) 
        {
            bool result = false;
            if (pinpnmb >= MinNumb && pinpnmb <= MaxNumb)
            {
                result = true;
            }

            return result;
        }

        public abstract string GetCount();
    }
}
