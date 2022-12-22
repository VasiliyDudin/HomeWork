using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class Settings : IUserSettings, ICompSettings
    {
        private int min;
        private int max;
        private int count;
        private int number;
        public int NUMBER { get { return number; } }
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
            set { number = value; }
            get { return number; }
        }
        int IUserSettings.Count
        {
            set { count = value; }
            get { return count; }
        }
        int ICompSettings.MinNumb
        {
            set { min = value; }
            get { return min; }
        }
        int ICompSettings.MaxNumb
        {
            set { max = value; }
            get { return max; }
        }
        int ICompSettings.Numb
        {
            set { number = value; }
            get { return number; }
        }
        int ICompSettings.Count
        {
            set { count = value; }
            get { return count; }
        }

        public Settings(int pmin, int pmax, int pcount)
        {
            min = pmin;
            max = pmax;
            count = pcount;
            Generete();
        }

        public bool CheckDip(int pinpnmb)
        {
            bool result = false;
            if (pinpnmb >= min && pinpnmb <= max)
            {
                result = true;
            }

            return result;
        }

        public void Generete()
        {
            Random rnd = new Random();
            number = rnd.Next(min, max); 
        }

        string IUserSettings.GetCount()
        { 
            return count.ToString();
        }
    }
}
