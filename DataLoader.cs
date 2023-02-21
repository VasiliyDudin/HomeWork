using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asinc
{
    internal class DataLoader : IDataLoader
    {
        public List<string> LoadData() 
        {
            List<string> result = new List<string>();
            using (StreamReader sr = File.OpenText(Generator._FileName))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    result.Add(s);
                }
            }

            return result;
        }
    }
}
