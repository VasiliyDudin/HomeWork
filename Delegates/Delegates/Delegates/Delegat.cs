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
        public static Func<Number, float> _GetPar;
        public static void GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T : Number
        {
            _GetPar = (Func<Number, float>)getParameter;
            float res;
            Number max = new Number(0);
            List<Number> numbers = (List<Number>)e;
            foreach (Number vl in numbers)
            {
                if (vl > max)
                    max = vl;
            }

            res = _GetPar.Invoke(max);
            if (res >= 0)
                Console.WriteLine(res + " - this max value");
        }
    }
}
