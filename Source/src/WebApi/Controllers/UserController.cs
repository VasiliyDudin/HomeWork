using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        SqlConnection _connStr = new SqlConnection("Data Source=LAPTOP-IQ3A8DB6\\SQLEXPRESS;Initial Catalog=HW_OTUS;Integrated Security=True");
        DataSet _dataSet = new DataSet();

        [HttpGet("{id:int}")]   
        public Task<User> GetCustomerAsync([FromRoute] int id)
        {
            object[] result = new object[7];
            string queryString = $"SELECT * FROM dbo.Users where Id = {id};";
            SqlDataAdapter adapSQL = new SqlDataAdapter(queryString, _connStr);
            _connStr.Open();
            adapSQL.Fill(_dataSet);
            _connStr.Close();
            if (_dataSet != null && _dataSet.Tables.Count > 0)
            {
                result = _dataSet.Tables[0].Rows[0].ItemArray.ToArray();
            }

            User usr = new User();
            usr.Id = Convert.ToInt32(result[0]);
            usr.FirstName = result[1].ToString();
            usr.SecondName = result[2].ToString();
            usr.LastName = result[3].ToString();
            usr.Address = result[4].ToString();
            usr.Email = result[5].ToString();
            usr.Age = Convert.ToInt32(result[6]);

            return Task.FromResult(usr);
        }

        [HttpPost("")]   
        public Task<int> CreateCustomerAsync([FromBody] User customer)
        {
            int userID = 0;
            User usr = new User();
            usr.FirstName = customer.FirstName.ToString();
            usr.SecondName = customer.SecondName.ToString();
            usr.LastName = customer.LastName.ToString();
            usr.Address = customer.Address.ToString();
            usr.Email = customer.Email.ToString();
            usr.Age = Convert.ToInt32(customer.Age);

            string queryString = $"INSERT INTO dbo.Users (FirstName,SecondName,LastName,Address,Email,Age) VALUES ('{usr.FirstName}','{usr.SecondName}','{usr.LastName}','{usr.Address}','{usr.Email}',{usr.Age});SELECT SCOPE_IDENTITY();";
            SqlCommand cmdSQL = new SqlCommand(queryString, _connStr);
            _connStr.Open();
            userID = Convert.ToInt32(cmdSQL.ExecuteScalar());
            _connStr.Close();

            return Task.FromResult(userID);
        }
    }
}