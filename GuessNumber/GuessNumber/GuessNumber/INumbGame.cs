using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public interface INumbGame : ICompar
    {
        public bool ComparisonNumbers(int p_inpnmb, int p_guessnumb)
        {
            bool result = false;
            result = p_guessnumb == p_inpnmb ? true : false;

            return result;
        }
    }
}
