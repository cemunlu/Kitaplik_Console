using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Model
{
    internal class Baslik_Cikis
    {
        public static void Cikis()
        {
            ConsoleKey exit;
            do
            {
                Console.Write("Ana menüye dönmek için (e) tuşuna basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);
        }
        public static void BaslikYazdir(object baslik)
        {
            Console.Clear();
            Console.WriteLine(baslik);
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }
    }
}
