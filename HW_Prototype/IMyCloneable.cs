using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Prototype
{
    public interface IMyCloneable<T>
    {
        T Copy();
    }
}
