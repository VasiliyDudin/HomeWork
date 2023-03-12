using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    internal interface IHouse
    {
        string GetInfo();
        Point GetLocation();
        long GetCost();
    }

    public enum TypeHouse
    {
        House,
        Cottage,
        Country_house,
        Townhouse,
        Apartment_building,
        Penthouse
    }
}
