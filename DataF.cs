using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asinc
{
    public class DataF
    {
        int Id;
        string fio;
        string email;
        string phone;

        public int ID { get { return Id; } }
        public string FIO { get { return fio; } }
        public string EMAIL { get { return email; } }
        public string PHONE { get { return phone; } }

        public DataF()
        { }

        public DataF(int pid, string pfio, string pemail, string pphone)
        { 
            Id = pid;
            fio = pfio;
            email= pemail;
            phone= pphone;
        }
    }
}
