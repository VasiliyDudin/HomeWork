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

        public string Compare(int p_inpnmb, int p_numb)
        {
            string result = string.Empty;
            INumbGame ng = new GameINT();

            if (ng.ComparisonNumbers(p_inpnmb, p_numb))
            {
                result = "\nВы отгадали !\n";
            }
            else
            {
                result = p_inpnmb > p_numb ? "Введеное число больше отгадываемого" : "Введеное число меньше отгадываемого";
            }

            return result;
        }
    }
}
