using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Asinc
{
    internal class Generator
    {
        public const string _FileName = "GenerateFile.csv";
        public const int _threadCount = 1000000;
        static public void Run()
        {
            long phone = 79995008010;
            var GenerateDatas = new List<DataF>();
            Random rnd = new Random();
            for (int i = 0; i < _threadCount; i++)
            {
                GenerateDatas.Add(new DataF(rnd.Next(1, _threadCount), "Ivanov Alex Sebastianos", $"test{i+1}@mail.ru", "+" + (phone + (_threadCount + i)).ToString()));
            }

            using (var writer = new StreamWriter(_FileName))
            {
                foreach(DataF dt in GenerateDatas)
                {
                    writer.WriteLine("ID: " + dt.ID);
                    writer.WriteLine(dt.FIO);
                    writer.WriteLine(dt.EMAIL);
                    writer.WriteLine(dt.PHONE);
                }
            }
        }
    }
}
