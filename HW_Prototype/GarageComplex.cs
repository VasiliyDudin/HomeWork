using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public class GarageComplex : Garage
    {
        int NumberComplex;
        List<Garage> Garages;

        public int Number 
        {
            get { return NumberComplex; }
            set { NumberComplex = value; }
        }
        public GarageComplex() 
        {
            NumberComplex = 1;
            Garages = new List<Garage>();
        }

        public GarageComplex(bool build, int numbCmpx, int sq)
        {
            Garages = new List<Garage>();
            isBuild = build;
            NumberComplex = numbCmpx;
            square = sq;
        }

        public void AddGarage(Garage gr)
        {
            Garages.Add(gr);
        }
    }
}
