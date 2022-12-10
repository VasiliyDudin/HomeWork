using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public interface ICompar
    {
        virtual bool ComparisonNumbers() { return true; }
        /*virtual bool ComparisonNumbers(object p_inpnmb)
        {
            bool result = false;
            result = GuessNumber == p_inpnmb ? true : false;

            return result;
        }*/

    }
}
