using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Serializer
    {
        public static string Serialize(object obj)
        {
            var r = new StringBuilder();
            Type mytype = obj.GetType();
            r.Append(mytype.FullName);
            r.Append("#N#");//отделим имя

            foreach (var method in obj.GetType().GetMethods())
            {
                r.Append(method.Name);
                r.Append("#M#");//отделим методы
            }
            foreach (var field in obj.GetType().GetFields())
            {
                r.Append(field.Name);
                r.Append("=");
                r.Append(obj.GetType().GetField(field.Name).GetValue(obj));
                r.Append("#F#");//отделим поля
            }
            return r.ToString();
        }

        public static object Deserialize(string obj)
        {
            var Name = obj.Split("#N#");
            var mytype = Type.GetType(Name[0]);
            object F = Activator.CreateInstance(mytype);

            var methods = Name[1].Split("#M#");
            var fields = methods[methods.Length - 1].Split("#F#");
            foreach (var f in fields)
            {
                if (!string.IsNullOrEmpty(f.ToString()))
                {
                    var fieldName = f.Split("=")[0];
                    var value = f.Split("=")[1];
                    var field = mytype.GetField(fieldName);
                    field.SetValue(F, Convert.ChangeType(value, field.FieldType));
                }

            }


            return F;
        }
    }
}
