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

        bool ComparisonNumbers(double pinpnmb)
        {
            bool result = false;
            result = GuessNumber == pinpnmb ? true : false;

            return result;
        }
    }
}
