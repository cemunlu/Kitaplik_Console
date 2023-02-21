using Kitaplik.Model.Abstract;
using Kitaplik.Model.Concrete;
using Kitaplik.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Model.AnaMenu
{
    public class AnaMenu
    {
        public static void Menu(ConsoleKey cevap)
        {

            if (cevap == ConsoleKey.D1)
            {
                KullaniciPaneli.KullaniciMenu("KULLANICI PANELİ");
            }
            else if (cevap == ConsoleKey.D2)
            {
                AdminPaneli.AdminMenu("GİRİŞ PANELİ");
            }
        }
    }
}
