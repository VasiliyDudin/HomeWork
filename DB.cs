using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asinc
{
    internal class DB
    {
        static string _connStr = "Host=localhost;Username=postgres;Password=gLnyVBeepCRx2022;Database=HW_Asinc";
        public async static Task<int> CreateCustomerAsync(DataF usr)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connStr);
            connection.Open();
            string commandText = $"INSERT INTO public.\"Users\" (\"ID\", \"FIO\", \"EMAIL\", \"PHONE\") VALUES ({usr.ID},'{usr.FIO}','{usr.EMAIL}','{usr.PHONE}');";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            return Convert.ToInt32(usr.ID);
        }
    }
}
