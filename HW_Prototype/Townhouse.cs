using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class Townhouse : House
    {
        public Townhouse() 
        {
            isBuild = true;
            countFloors = 2;
            TypeR = TypeRepair.cosmetic;
            type = TypeHouse.townhouse;
            balcony = new Balcony();
        }
    }
}
