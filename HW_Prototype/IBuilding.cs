using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    internal interface IBuilding
    {
        string GetInfo();
        Point GetLocation();
        long GetCost();
    }
}
