using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class Hangar : Garage
    {
        int countSpace;
        public Hangar() 
        {
            isBuild = true;
            isBasement = true;
            countSpace = 10;
        }

        public Hangar(bool build, bool basement, int sq, int cntSp, long pay, TypeRepair repair) 
        {
            isBuild = build;
            isBasement = basement;
            square = sq;
            countSpace = cntSp;
            cost = pay;
            TypeR = repair;
        }
        public string GetInfo()
        {
            string info = "This is - Hangar.\n";
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
                info += "With repair - " + base.GetRepairInfo() + ".\n";
            }
            if (countSpace > 0)
            {
                info += "Hangar have " + countSpace + " spaces.\n";
            }
            info += "Square = " + square + " m^2\n";
            info += "Сost = " + cost + " $\n\n";
            return info;
        }

        public Point GetLocation()
        {
            Random rnd = new Random();
            int p1 = rnd.Next(1, 100);
            int p2 = rnd.Next(1, 100);
            Point location = new Point(p1, p2);
            return location;
        }
    }
}
