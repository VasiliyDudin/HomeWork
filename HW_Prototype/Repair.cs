using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class Repair : IMyCloneable<Repair>, ICloneable
    {
        TypeRepair type;
        public TypeRepair TypeR
        {
            get{ return type; }
            set{ type = value; }
        }
        public Repair() { type = TypeRepair.without; }
        public Repair(TypeRepair tp) { type = tp; }

        public string GetRepairInfo()
        { 
            string info = string.Empty;

            switch(type)
            {
                case TypeRepair.modern:
                    info = "Modern";
                    break;
                case TypeRepair.evro:
                    info = "Evro";
                    break;
                case TypeRepair.cosmetic:
                    info = "Cosmetic";
                    break;
                case TypeRepair.old:
                    info = "Old";
                    break;
                case TypeRepair.without:
                    info = "Without";
                    break;
            }

            return info;
        }

        public Repair Copy()
        {
            return new Repair(type);
        }

        public object Clone()
        {
            return new Repair(type);
        }
    }

    public enum TypeRepair
    {
        modern = 1,
        evro = 2,
        cosmetic = 3,
        old = 4,
        without = 5
    }
}
