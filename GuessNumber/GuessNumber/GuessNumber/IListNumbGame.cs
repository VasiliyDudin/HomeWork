using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal interface IListNumbGame : ICompar
    {
        protected List<int> GuessNumber { get; set; }

        bool ComparisonNumbers(List<int> p_inpnmbs)
        { 
            bool result = false;
            int countNmbs = GuessNumber.Count, indx = 0;
            foreach (int nmb in p_inpnmbs)
            {
                if (GuessNumber.Contains(nmb))
                {
                    indx++;
                }
            }

            if (indx == countNmbs)
            {
                result = true;
            }

            return result;
        }
    }
}
