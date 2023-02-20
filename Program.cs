// See https://aka.ms/new-console-template for more information
using Asinc;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;

Console.WriteLine("Run generate fila by thread ?");
if (Console.ReadKey().Key == ConsoleKey.Y)
{
    Thread th = new Thread(Generator.Run);
    th.Start();
    th.Join();
}
else
{
    Generator.Run();
}

List<string> linesF = new List<string>();
List<Thread> threads = new List<Thread>();
List<DataF> datas = new List<DataF>();
int count = 0;

/*using (StreamReader sr = File.OpenText(Generator._FileName))
{
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        linesF.Add(s);
    }
}*/
CountdownEvent countdown = new CountdownEvent(Generator._threadCount);
var stopWatch = new Stopwatch();
stopWatch.Start();
using (StreamReader reader = File.OpenText(Generator._FileName))
{
    string s;
    while ((s = await reader.ReadLineAsync()) != null)
    {
        linesF.Add(s);
    }
}

for (int i = 0; i < Generator._threadCount; i++)
{
    int CountRep = 0;
    ThreadPool.QueueUserWorkItem(OnGetLinesAsync);//(HandleInThreadPool, CountRep);
    /*Thread thread = new Thread(() => { CountRep = OnGetLines(); });
    threads.Add(thread);
    threads[i].Start();
    while (CountRep > 0 && CountRep < 10)
    {
        Thread.Sleep(10);
        threads[i].Abort();
        threads[i].Start();
    }*/
}

/*for (int i = 0; i < Generator._threadCount; i++)
{
    threads[i].Join();
}*/

countdown.Wait();
stopWatch.Stop();

Console.ReadLine();

async void OnGetLinesAsync(object item)//int OnGetLines()
{
    int result = 0;
    try
    {
        string fio = String.Empty, email = String.Empty, phone = String.Empty;
        int id = 0;
        for (int i = count; i < linesF.Count; i++)
        {
            string line = linesF[i];
            count++;
            if (line.Contains("ID:") && id == 0)
            {
                id = Convert.ToInt32(line.Substring(4, line.Length - 4));
                continue;
            }
            else if (string.IsNullOrEmpty(fio))
            {
                fio = line;
                continue;
            }
            else if (string.IsNullOrEmpty(email))
            {
                email = line;
                continue;
            }
            else if (string.IsNullOrEmpty(phone))
            {
                phone = line;
                continue;
            }
            else
            {
                count--;
                break;
            }
        }

        DataF df = new DataF(id, fio, email, phone);
        datas.Add(df);
        await DB.CreateCustomerAsync(df);
    }
    catch (Exception ex)
    { 
        Console.WriteLine(ex.Message);
        result++;
    }

    //return result;
}
