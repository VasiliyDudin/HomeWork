using GuessNumber.GuessNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class GuessNumberGame
    {
        public void Run()
        {
            string rslt = string.Empty;
            int min, max, count, gamenumb;
            Console.WriteLine("Guess Number !\n");
            Console.WriteLine("Настроим параметры игры:\nВведите диапозон чисел от - \n");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("до - \n");
            max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество попыток отгадывания - \n");
            count = Convert.ToInt32(Console.ReadLine());
            Settings st = new Settings(min, max, count);
            IUserSettings ust = new Settings(min, max, count);
            IUserSettings ussqr = new SettingsSQR(count);
            Console.WriteLine("Count SQR - " + ussqr.GetCount());
            Console.WriteLine("Count - " + ust.GetCount());
            IGame gm = new GameINT();
            //IGame gm = new GameDBL();
            GameStart<IGame> start = new GameStart<IGame>(gm);
            Console.WriteLine("Игра началась...\n");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\nВведите число\n");
                gamenumb = Convert.ToInt32(Console.ReadLine());
                if (st.CheckDip(gamenumb))
                {
                    rslt = start.CompareNumbers(gamenumb, st.NUMBER);
                    Console.WriteLine(rslt);
                    if (rslt.Equals("\nВы отгадали !\n"))
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы вышли за указанный диапозон\n");
                }
            }
            Console.WriteLine("\nИгра завершена !\n");
        }
    }
}
