// See https://aka.ms/new-console-template for more information
using Asinc;
using System.Diagnostics;

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
List<string> linesConvert = new List<string>();
List<Thread> threads = new List<Thread>();
List<DataF> datas = new List<DataF>();
DataLoader loader = new DataLoader();
CustomerRepository dataBase = new CustomerRepository();
DataParser dataParse = new DataParser();
int count = 0;

CountdownEvent countdown = new CountdownEvent(Generator._threadCount);
var stopWatch = new Stopwatch();
stopWatch.Start();
linesF = loader.LoadData();

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
            linesConvert.Add(linesF[i]);
            count++;
            if (i % 4 == 0)
            {
                DataF df = dataParse.Parse(linesConvert);
                datas.Add(df);
                await CustomerRepository.AddDataAsinc(df);
                linesConvert.Clear();
            }
        }
    }
    catch (Exception ex)
    { 
        Console.WriteLine(ex.Message);
        result++;
    }

    //return result;
}
