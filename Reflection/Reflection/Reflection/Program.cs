// See https://aka.ms/new-console-template for more information

//namespace Reflection;

using Reflection;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

Stopwatch watch = new Stopwatch();
Type mytype = typeof(F);
F fs = new F();
fs.i1 = 10;
fs.i2 = 7;
fs.i3 = 5;
fs.i4 = 40;
fs.i5 = 500;
watch.Start();
for (int i = 0; i < 10000; i++)
    Serializer.Serialize(fs);
watch.Stop();
string result = Serializer.Serialize(fs);
Console.WriteLine(result);
Console.WriteLine("Serialize = " + watch.ElapsedMilliseconds);
watch.Start();
for (int i = 0; i < 10000; i++)
    Serializer.Deserialize(result);
watch.Stop();
Console.WriteLine("Deserialize = " + watch.ElapsedMilliseconds);
object test = Serializer.Deserialize(result);

//object test = Activator.CreateInstance(mytype);
//var method = mytype.GetMethods();
//string namemethod = method[0].Name;
//MethodInfo methodGet = mytype.GetMethod(namemethod);
//var res = methodGet.Invoke(null, null);

FileStream stream = File.Create("test.dat");
BinaryFormatter formatter = new BinaryFormatter();
watch.Start();
for (int i=0; i < 10000; i++)
    formatter.Serialize(stream, test);
watch.Stop();
stream.Close();
Console.WriteLine(watch.ElapsedMilliseconds);
Console.ReadKey();
stream = File.OpenRead("test.dat");
watch.Start();
test = formatter.Deserialize(stream);
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds);
//Console.WriteLine("Имя    : " + methodGet.Invoke(null, null));
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
test = formatterJS.ReadObject(streamJS);
//Console.WriteLine(methodGet.Invoke(null, null));
streamJS.Close();

Console.ReadKey();