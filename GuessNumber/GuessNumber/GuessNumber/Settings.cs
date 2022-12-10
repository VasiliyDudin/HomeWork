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
            set { numb = value; }
            get { return numb; }
        }
        int ICompSettings.Count
        {
            set { count = value; }
            get { return count; }
        }

        public Settings(int p_min, int p_max, int p_count)
        {
            min = p_min;
            max = p_max;
            count = p_count;
            Generete();
        }

        public bool CheckDip(int p_inpnmb)
        {
            bool result = false;
            if (p_inpnmb >= min && p_inpnmb <= max)
            {
                result = true;
            }

            return result;
        }

        public void Generete()
        {
            Random rnd = new Random();
            numb = rnd.Next(min, max); 
        }
    }
}
