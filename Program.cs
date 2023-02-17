// See https://aka.ms/new-console-template for more information
using System.Data;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;

const int count = 100000;
const int Tcount = 1000;

int[] sumints = new int[count];
List<Thread> threads = new List<Thread>();
int sum = 0, sum2 = 0, indx = 0, param = 0, countthread = count / Tcount;

Random rnd = new Random();
Stopwatch watch = new Stopwatch();
//watch.Start();
for (int i = 0; i < count; i++)
{
    sumints[i] = rnd.Next();
}

for (int i = 0; i < countthread; i++)
{
    Thread thrd = new Thread(() => { sum2 += OnGetLines(); });
    threads.Add(thrd);
}

for (int i=0; i<count; i++)
{
    sum += sumints[i];
}

//watch.Stop();

Console.WriteLine(sum);

//watch.Start();
foreach (Thread thrd in threads)
{
    thrd.Start();
    thrd.Join();
    thrd.Interrupt();
}


int OnGetLines()
{
    int result = 0;
    int k = indx * Tcount;

    for (int i = k; i < k + Tcount; i++)
    {
        result += sumints[i];
    }

    indx++;

    return result;
}

//watch.Stop();

Console.WriteLine(sum2);

Console.ReadLine();
