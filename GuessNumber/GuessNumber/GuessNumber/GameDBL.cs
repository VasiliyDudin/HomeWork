using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class GameDBL : GameINT
    {
        double number;

        public GameDBL() { }
        double GuessNumber
        {
            set { number = value; }
            get { return number; }
        }

        public bool ComparNumb(double pinpnmb)
        {
            bool result = number == pinpnmb ? true : false;
            return result;
        }
        public string Compare(double pinpnmb)
        {
            string result = string.Empty;

            if (ComparNumb(pinpnmb))
            {
                result = "Вы отгадали";
            }
            else
            {
                result = pinpnmb > number ? "Введеное число больше отгадываемого" : "Введеное число меньше отгадываемого";
            }

            return result;
        }
    }
}
