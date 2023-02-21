using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asinc
{
    public class CustomerRepository : ICustomerRepository
    {
        static string _connStr = "Host=localhost;Username=postgres;Password=gLnyVBeepCRx2022;Database=HW_Asinc";

        public int AddData(DataF data)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connStr);
            connection.Open();
            string commandText = $"INSERT INTO public.\"Users\" (\"ID\", \"FIO\", \"EMAIL\", \"PHONE\") VALUES ({data.ID},'{data.FIO}','{data.EMAIL}','{data.PHONE}');";
            using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.ExecuteNonQueryAsync();
            }

            return Convert.ToInt32(data.ID);
        }
        public async static Task<int> AddDataAsinc(DataF data)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connStr);
            connection.Open();
            string commandText = $"INSERT INTO public.\"Users\" (\"ID\", \"FIO\", \"EMAIL\", \"PHONE\") VALUES ({data.ID},'{data.FIO}','{data.EMAIL}','{data.PHONE}');";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            return Convert.ToInt32(data.ID);
        }
    }
}
