using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asinc
{
    public class DataParser : IDataParser
    {
        public DataF Parse(List<string> pStr) 
        {
            string fio = String.Empty, email = String.Empty, phone = String.Empty;
            int id = 0;
            foreach (string str in pStr)
            {
                if (str.Contains("ID:") && id == 0)
                {
                    id = Convert.ToInt32(str.Substring(4, str.Length - 4));
                    continue;
                }
                else if (string.IsNullOrEmpty(fio))
                {
                    fio = str;
                    continue;
                }
                else if (string.IsNullOrEmpty(email))
                {
                    email = str;
                    continue;
                }
                else if (string.IsNullOrEmpty(phone))
                {
                    phone = str;
                    continue;
                }
                else
                {
                    break;
                }
            }

            DataF df = new DataF(id, fio, email, phone);
            return df;
        }
    }
}
