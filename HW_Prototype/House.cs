using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class House : Repair, IBuilding, IMyCloneable<House>, ICloneable
    {
        protected bool isBuild;
        protected int countFloors;
        protected int square;
        protected int countRoom;
        protected long cost;
        protected TypeHouse type;
        protected Balcony balcony;

        public Balcony Balcon
        {
            get { return balcony; }
            set { balcony = value; }
        }

        public House() 
        {
            isBuild = true;
            countFloors = 2;
            TypeR = TypeRepair.modern;
            type = TypeHouse.house;
        }

        public House(bool build, int cntF, int sq, int cntRoom, long pay, TypeRepair repair, TypeHouse typeHouse, Balcony bl)
        {
            isBuild = build;
            countFloors = cntF;
            square = sq;
            countRoom = cntRoom;
            cost = pay;
            TypeR = repair;
            type = typeHouse;
            balcony = bl;
        }

        public string GetInfo()
        {
            string hname = GetTypeInfo();
            string info = "This is - " + hname + ".\n";
            if (isBuild)
            {
                info += "Build completed.\n";
            }
            if (TypeR > 0)
            {
                info += "With repair - " + GetRepairInfo() + ".\n";
            }
            if (countFloors > 0)
            {
                info += hname + " have " + countFloors + " floors.\n";
            }
            if (countRoom > 0)
            {
                info += hname + " have " + countRoom + " rooms.\n";
            }
            if (balcony != null)
            {
                info += hname + " have balcony from - " + balcony.Material + ".\n";
            }
            info += "Square = " + square + " m^2\n";
            info += "Сost = " + cost + " $\n\n";
            return info;
        }

        public Point GetLocation()
        {
            Random rnd = new Random();
            int p1 = rnd.Next(1, 999);
            int p2 = rnd.Next(1, 999);
            Point location = new Point(p1, p2);
            return location;
        }

        public long GetCost()
        {
            return cost;
        }

        public string GetTypeInfo() 
        {
            string info = string.Empty;

            switch(type)
            {
                case TypeHouse.house:
                    info = "House";
                    break;
                case TypeHouse.cottage:
                    info = "Cottage";
                    break;
                case TypeHouse.countryHouse:
                    info = "Country house";
                    break;
                case TypeHouse.townhouse:
                    info = "Townhouse";
                    break;
                case TypeHouse.apartmentBuilding:
                    info = "Apartment building";
                    break;
                case TypeHouse.penthouse:
                    info = "Penthouse";
                    break;
            }

            return info;
        }

        public House Copy()
        {
            var copyBalcony = balcony?.Copy();
            return new House(isBuild, countFloors, square, countRoom, cost, TypeR, type, copyBalcony);
        }

        public object Clone()
        {
            var copyBalcony = balcony?.Clone();
            return new House(isBuild, countFloors, square, countRoom, cost, TypeR, type, copyBalcony == null ? null : (Balcony)copyBalcony);
        }
    }

    public enum TypeHouse
    {
        house = 1,
        cottage = 2,
        countryHouse = 3,
        townhouse = 4,
        apartmentBuilding = 5,
        penthouse = 6
    }
}
