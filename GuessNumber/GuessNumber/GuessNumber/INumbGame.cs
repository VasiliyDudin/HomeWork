using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public interface INumbGame : ICompar
    {
        public bool ComparisonNumbers(int pinpnmb, int pguessnumb)
        {
            bool result = false;
            result = pguessnumb == pinpnmb ? true : false;

            return result;
        }
    }
}
