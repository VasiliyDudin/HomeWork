// See https://aka.ms/new-console-template for more information
using System.Data;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;

const int count = 100000;
const int Tcount = 1000;

int[] sumints = new int[count];
List<Thread> threads = new List<Thread>();
var numbers = Enumerable.Range(0, count);
int sum = 0, sum2 = 0, sum3 = 0, indx = 0, param = 0, countthread = count / Tcount;

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
    thrd.Start();
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
    thrd.Join();
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

watch.Start();
//sum3 = numbers.AsParallel().Sum();
Parallel.ForEach( numbers, i =>
{
    lock (numbers)
    {
        sum3 += i;
    }
});
watch.Stop();

Console.WriteLine(sum3);

Console.ReadLine();
