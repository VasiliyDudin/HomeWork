using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class Balcony : IMyCloneable<Balcony>, ICloneable
    {
        int square;
        string material;
        Repair repair;
        public int Square
        {
            get { return square; }
            set { square = value; }
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public Repair RepairBl
        {
            get{ return repair; }
            set{ repair = value; }
        }
        public Balcony() 
        {
            square = 5;
            material = "Wood";
        }

        public Balcony(int sq, string mater, Repair rp)
        {
            square = sq;
            material = mater;
            repair = rp;
        }

        public string GetInfo()
        {
            string info = "This is - Balcony.\n";
            info += "Square = " + square + " m^2\n";
            info += "Material - " + material + " $\n";
            info += "Repair - " + repair.GetRepairInfo() + " $\n\n";
            return info;
        }

        public Balcony Copy()
        {
            var copyRepair = repair?.Copy();
            return new Balcony(square, material, copyRepair);
        }

        public object Clone()
        {
            var copyRepair = repair?.Clone();
            return new Balcony(square, material, copyRepair == null ? null : (Repair)copyRepair);
        }
    }
}
