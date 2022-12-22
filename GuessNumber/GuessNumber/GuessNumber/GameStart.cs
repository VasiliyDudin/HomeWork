using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.GuessNumber
{
    internal class GameStart<T> where T : IGame
    {
        public T Game { get; private set; }
        public GameStart(T game) 
        {
            this.Game = game;
        }

        public string CompareNumbers(object pinpnmb, object pnumb) 
        {
            string result = string.Empty;
            var typeGame = Game.GetType();

            if (typeGame.Name == "GameINT")
            {
                int pnumber1 = Convert.ToInt32(pinpnmb);
                int pnumber2 = Convert.ToInt32(pnumb);
                if (pnumber1 == pnumber2)
                {
                    result = "\nВы отгадали !\n";
                }
                else
                {
                    result = pnumber1 > pnumber2 ? "Введеное число больше отгадываемого" : "Введеное число меньше отгадываемого";
                }
            }
            else if (typeGame.Name == "GameDBL")
            {
                double pnumber1 = Convert.ToDouble(pinpnmb);
                double pnumber2 = Convert.ToDouble(pnumb);
                if (pnumber1 == pnumber2)
                {
                    result = "\nВы отгадали !\n";
                }
                else
                {
                    result = pnumber1 > pnumber2 ? "Введеное число больше отгадываемого" : "Введеное число меньше отгадываемого";
                }
            }

            return result;
        }
    }
}
