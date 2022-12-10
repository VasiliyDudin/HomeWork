using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal interface IDoubleGame : ICompar
    {
        protected double GuessNumber { get; set; }

        bool ComparisonNumbers(double p_inpnmb)
        {
            bool result = false;
            result = GuessNumber == p_inpnmb ? true : false;

            return result;
        }
    }
}
