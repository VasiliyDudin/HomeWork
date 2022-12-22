using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class GameINT : INumbGame, IGame
    {
        public GameINT() { }
        protected bool ComparNumb(int pinpnmb, int pnumb)
        {
            INumbGame numgame = new GameINT();
            bool result = numgame.ComparisonNumbers(pinpnmb, pnumb);
            return result;
        }

        public string Compare(int pinpnmb, int pnumb)
        {
            string result = string.Empty;

            if (ComparNumb(pinpnmb, pnumb))
            {
                result = "\nВы отгадали !\n";
            }
            else
            {
                result = pinpnmb > pnumb ? "Введеное число больше отгадываемого" : "Введеное число меньше отгадываемого";
            }

            return result;
        }
    }
}
