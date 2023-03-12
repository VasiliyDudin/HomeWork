using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class Repair
    {
        TypeRepair type;
        public TypeRepair TypeR
        {
            get{ return type; }
            set{ TypeR = value; }
        }
        public Repair() { }


    }

    public enum TypeRepair
    {
        modern,
        evro,
        cosmetic,
        old,
        without
    }
}
