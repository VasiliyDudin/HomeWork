using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal static class Delegat
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            T result = null;
            float max = 0;
            foreach (var vl in e)
            {
                float tmp = getParameter.Invoke((T)vl);
                if (tmp > max)
                {
                    max = tmp;
                    result = vl;
                }
            }

            if (max >= 0)
                Console.WriteLine(max + " - this max value");
            return result;
        }
    }
}
