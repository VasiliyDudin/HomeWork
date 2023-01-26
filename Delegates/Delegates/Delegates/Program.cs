// See https://aka.ms/new-console-template for more information

using Delegates;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Crypto;
using System.Collections;
using System.Security.Cryptography.Xml;


int length = 10, r;
IList<object> Lids = new List<object>();
Random rnd = new Random();
Func<object, float> getPar = getParameter;

for (double i = 1; i < length; i++)
{
    r = rnd.Next(1, 100);
    Lids.Add(r * i);
}

Delegat.GetMax<object>(Lids, getPar);
Console.ReadKey();


static float getParameter(object prm)
{
    float res = (float)Convert.ToDouble(prm);

    return res;
}


FindFile f = new FindFile();
f.Path = "C:\\Обучение\\ГИМС";
f.FileFound += OnFound;
f.Find();

void OnFound(object sender, EventArgs FileArgs)
{
    Console.WriteLine("File: " + ((Delegates.FileArgs)FileArgs).FoundFile);
    var key = Console.ReadKey();
    if(key.Key == ConsoleKey.S)
        ((Delegates.FileArgs)FileArgs).Cancel = true;
}
