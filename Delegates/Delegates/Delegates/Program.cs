// See https://aka.ms/new-console-template for more information

using Delegates;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Crypto;
using System.Collections;
using System.Security.Cryptography.Xml;


int length = 10, r;
IList<Number> Lids = new List<Number>();
Random rnd = new Random();
Func<Number, float> getPar = getParameter;

for (double i = 1; i < length; )
{
    r = rnd.Next(1, 100);
    Lids.Add(new Number(r*i));
    i += 0.5;
}

Delegat.GetMax<Number>(Lids, getPar);
Console.ReadKey();


static float getParameter(Number prm)
{
    float res = -1;
    if (!string.IsNullOrEmpty(prm.GetT()))
    {
        if(prm.GetT() == "Double")
            res = (float)Convert.ToDouble(prm.VDBL);
        if (prm.GetT() == "Int")
            res = (float)Convert.ToDouble(prm.VINT);
    }

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
