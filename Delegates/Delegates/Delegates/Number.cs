using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Number
    {
        private int valInt;
        private double valDbl;
        private string Type;

        public int VINT{ get => valInt; }
        public double VDBL { get => valDbl; }
        public Number(object val)
        {
            Type = string.Empty;
            valInt = Convert.ToInt32(val);
            if (valInt == null)
            {
                valDbl = Convert.ToDouble(val);
                if (valDbl != null)
                {
                    Type = "Double";
                }
            }
            else
            {
                Type = "Int";
            }
        }

        public string GetT()
        {
            return Type;
        }

        public static bool operator < (Number vl1, Number vl2)
        {
            bool res = false;
            switch (vl1.GetT(), vl2.GetT())
            {
                case ("Double", "Double"):
                        res = Convert.ToDouble(vl1.VDBL) < Convert.ToDouble(vl2.VDBL);
                    break;
                case ("Int", "Int"):
                    res = Convert.ToInt32(vl1.VINT) < Convert.ToInt32(vl2.VINT);
                    break;
            }

            return res;
        }

        public static bool operator >(Number vl1, Number vl2)
        {
            bool res = false;
            switch (vl1.GetT(), vl2.GetT())
            {
                case ("Double", "Double"):
                    res = Convert.ToDouble(vl1.VDBL) > Convert.ToDouble(vl2.VDBL);
                    break;
                case ("Int", "Int"):
                    res = Convert.ToInt32(vl1.VINT) > Convert.ToInt32(vl2.VINT);
                    break;
            }

            return res;
        }
    }
}
