// See https://aka.ms/new-console-template for more information

//namespace Reflection;

using Reflection;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

F test = new F();
Stopwatch watch = new Stopwatch();

FileStream stream = File.Create("test.dat");
BinaryFormatter formatter = new BinaryFormatter();
watch.Start();
for (int i=0; i < 10000; i++)
    formatter.Serialize(stream, test);
watch.Stop();
stream.Close();
Console.WriteLine(test.Get());
Console.ReadLine();
Console.WriteLine(watch.ElapsedMilliseconds);
Console.ReadKey();
stream = File.OpenRead("test.dat");
test = formatter.Deserialize(stream) as F;
Console.WriteLine("Имя    : " + test.Get());
stream.Close();
Console.ReadKey();
FileStream streamJS = File.Create("test.json");
DataContractJsonSerializer formatterJS = new DataContractJsonSerializer(test.GetType());
watch.Start();
formatterJS.WriteObject(streamJS, test);
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds);
streamJS.Close();
watch.Start();
streamJS = File.OpenRead("test.json");
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds);
test = formatterJS.ReadObject(streamJS) as F;
Console.WriteLine(test.Get());
streamJS.Close();

Console.ReadKey();
