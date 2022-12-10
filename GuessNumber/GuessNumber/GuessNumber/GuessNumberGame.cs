using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class GuessNumberGame //: INumbGame //Game//, ISettings
    {
        public void Run()
        {
            string rslt = string.Empty;
            int min, max, count, gnumb;
            Console.WriteLine("Guess Number !\n");
            Console.WriteLine("Настроим параметры игры:\nВведите диапозон чисел от - \n");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("до - \n");
            max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество попыток отгадывания - \n");
            count = Convert.ToInt32(Console.ReadLine());
            Settings st = new Settings(min, max, count);
            IGame gm = new GameINT();
            Console.WriteLine("Игра началась...\n");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\nВведите число\n");
                gnumb = Convert.ToInt32(Console.ReadLine());
                if (st.CheckDip(gnumb))
                {
                    rslt = gm.Compare(gnumb, st.NUMBER);
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
