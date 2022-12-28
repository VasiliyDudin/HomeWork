// See https://aka.ms/new-console-template for more information

//namespace Reflection;

using Reflection;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

Type mytype = typeof(F);
object test = Activator.CreateInstance(mytype);
var method = mytype.GetMethods();
string namemethod = method[0].Name;
MethodInfo methodGet = mytype.GetMethod(namemethod);
//var res = methodGet.Invoke(null, null);

Stopwatch watch = new Stopwatch();

FileStream stream = File.Create("test.dat");
BinaryFormatter formatter = new BinaryFormatter();
watch.Start();
for (int i=0; i < 10000; i++)
    formatter.Serialize(stream, test);
watch.Stop();
stream.Close();
Console.WriteLine(methodGet.Invoke(null, null));
Console.ReadLine();
Console.WriteLine(watch.ElapsedMilliseconds);
Console.ReadKey();
stream = File.OpenRead("test.dat");
test = formatter.Deserialize(stream);
Console.WriteLine("Имя    : " + methodGet.Invoke(null, null));
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
Console.WriteLine(methodGet.Invoke(null, null));
streamJS.Close();

Console.ReadKey();