using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class GameDBL : IDoubleGame, IGame
    {
        double number;

        public GameDBL() { }
        double IDoubleGame.GuessNumber
        {
            set { number = value; }
            get { return number; }
        }
        public string Compare(double p_inpnmb)
        {
            string result = string.Empty;
            IDoubleGame ng = new GameDBL();

            if (ng.ComparisonNumbers(p_inpnmb))
            {
                result = "Вы отгадали";
            }
            else
            {
                result = p_inpnmb > number ? "Введеное число больше отгадываемого" : "Введеное число меньше отгадываемого";
            }

            return result;
        }
    }
}
