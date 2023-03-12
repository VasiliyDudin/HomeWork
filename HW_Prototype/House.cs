using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    internal class House : Repair, IHouse
    {
        bool isBuild;
        int countFloors;
        int square;
        int countRoom;
        long cost;
        TypeHouse type;

        public House() { }

        public string GetInfo()
        { 
            return string.Empty;
        }

        public Point GetLocation()
        {
            return new Point();
        }

        public long GetCost()
        {
            return 10;
        }

        public string GetType() 
        {
            return string.Empty;
        }

        public string GetRepair()
        {
            return string.Empty;
        }
    }
}
