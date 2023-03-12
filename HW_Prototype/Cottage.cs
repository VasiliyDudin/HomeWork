using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class Cottage : House
    {
        public Cottage() 
        {
            isBuild = true;
            countFloors = 2;
            TypeR = TypeRepair.modern;
            type = TypeHouse.cottage;
        }
    }
}
