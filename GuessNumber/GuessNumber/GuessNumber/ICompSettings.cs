using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal interface ICompSettings
    {
        protected int MinNumb { get; set; }
        protected int MaxNumb { get; set; }
        protected int Numb { get; set; }
        protected int Count { get; set; }
        public bool CheckDip(int p_inpnmb)
        {
            return true;
        }
        public void Generete() 
        {
            Random rnd = new Random();
            MinNumb = rnd.Next(); 
            MaxNumb = rnd.Next();
            Count = rnd.Next();
            Numb = rnd.Next(MinNumb, MaxNumb);
        }
    }
}
