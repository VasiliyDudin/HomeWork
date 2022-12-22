using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.GuessNumber
{
    internal class SettingsSQR : IUserSettings
    {
        public SettingsSQR(int pcount) { count = pcount; }
        private int min;
        private int max;
        private int count;
        private int numb;
        public int NUMBER { get { return numb; } }
        int IUserSettings.MinNumb
        {
            set { min = value; }
            get { return min; }
        }
        int IUserSettings.MaxNumb
        {
            set { max = value; }
            get { return max; }
        }
        int IUserSettings.Numb
        {
            set { numb = value; }
            get { return numb; }
        }
        int IUserSettings.Count
        {
            set { count = value; }
            get { return count; }
        }

        string IUserSettings.GetCount()
        {
            return (count * count).ToString();
        }
    }
}
