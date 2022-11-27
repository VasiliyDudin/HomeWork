using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace WebClient
{
    static class Program
    {
        static HttpClient _client = new HttpClient();
        static void Main(string[] args)
        {
            Console.WriteLine($"You wont create user ?\n");
            ConsoleKeyInfo res = Console.ReadKey();
            char r = Convert.ToChar(res.Key);
            if (res.Key == ConsoleKey.N)
            {
                GetAsync().GetAwaiter().GetResult();
            }
            else if (res.Key == ConsoleKey.Y)
            {
                User usr = RandomUser();
                CreateAsync(usr).GetAwaiter().GetResult();
            }

            Console.ReadLine();
        }
        static async void GetUserAsync(string p_ID)
        {
            string path = $"https://localhost:5001/users/{p_ID}";
            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var usr = await response.Content.ReadAsStringAsync();
                ShowUser(usr);
            }
        }

        static async Task<int> CreateUserAsync(User p_usr)
        {
            int Id = 0;
            HttpResponseMessage response = await _client.PostAsJsonAsync("/users", p_usr);
            response.EnsureSuccessStatusCode();
            var userID = await response.Content.ReadAsStringAsync();
            if(userID != null)
                Id = Convert.ToInt32(userID);

            return Id;
        }

        private static User RandomUser()
        {
            Random RNG = new Random();
            User crUsr = new User();
            string[] pStr = new string[5];
            string rndStr = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    rndStr += ((char)(RNG.Next(1, 26) + 64)).ToString().ToLower();
                }
                pStr[i] = rndStr;
            }
            crUsr.FirstName= pStr[0];
            crUsr.SecondName= pStr[1];
            crUsr.LastName= pStr[2];
            crUsr.Address= pStr[3];
            crUsr.Email= pStr[4];
            crUsr.Age = RNG.Next(99);

            return crUsr;
        }
        static void ShowUser(string p_str)
        {
            Console.WriteLine(p_str);
        }

        static async Task GetAsync()
        {
            Console.WriteLine("Input User ID - ");
            string uID = Console.ReadLine();
            _client.BaseAddress = new Uri("https://localhost:5001");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                GetUserAsync(uID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task CreateAsync(User p_usr)
        {
            Console.WriteLine("Creating random User...\n");
            _client.BaseAddress = new Uri("https://localhost:5001");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                int uID = await CreateUserAsync(p_usr);
                if (uID > 0)
                {
                    Console.WriteLine($"You create user with ID - {uID} \n Do you wont show this user ?\n");
                    ConsoleKeyInfo res = Console.ReadKey();
                    if (res.Key == ConsoleKey.Y)
                    {
                        GetUserAsync(uID.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}