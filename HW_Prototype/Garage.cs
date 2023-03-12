using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class Garage : Repair, IBuilding, IMyCloneable<Garage>, ICloneable
    {
        protected bool isBuild;
        protected bool isBasement;
        protected int countFloors;
        protected int square;
        protected long cost;

        public Garage() 
        {
            isBuild = true;
            isBasement  = true; 
            countFloors = 1;
        }

        public Garage(bool build, bool basement, int cntF, int sq, long pay, TypeRepair repair)
        {
            isBuild = build;
            isBasement = basement;
            countFloors = cntF;
            square = sq;
            cost = pay;
            TypeR = repair;
        }

        public string GetInfo()
        {
            string info = "This is - Garage.\n";
            if (isBuild) 
            {
                info += "Build completed.\n";
            }
            if (isBasement)
            {
                info += "With basement.\n";
            }
            if (TypeR > 0)
            {
                info += "With repair - " + GetRepairInfo() + ".\n";
            }
            if (countFloors > 0)
            {
                info += "Garage have " + countFloors + " floors.\n";
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

        public Garage Copy()
        {
            return new Garage(isBuild, isBasement, countFloors, square, cost, TypeR);
        }

        public object Clone()
        {
            return new Garage(isBuild, isBasement, countFloors, square, cost, TypeR);
        }
    }
}
