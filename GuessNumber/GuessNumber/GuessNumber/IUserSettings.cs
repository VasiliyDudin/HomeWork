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
        public bool CheckDip(int p_inpnmb) 
        {
            bool result = false;
            if (p_inpnmb >= MinNumb && p_inpnmb <= MaxNumb)
            {
                result = true;
            }

            return result;
        }
    }
}
