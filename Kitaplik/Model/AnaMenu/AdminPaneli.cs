using Kitaplik.Model.Context;
using System;

namespace Kitaplik.Model.AnaMenu
{
    internal class AdminPaneli
    {
        internal static void AdminMenu(string baslik)
        {
            ConsoleKey exit;
            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                string kullaniciAdi = "admin", sifre = "1234", _kullaniciAdi, _sifre;
                Console.Write("Kullanıcı Adı:");
                _kullaniciAdi = Console.ReadLine();
                Console.Write("Şifre: ");
                _sifre = Sifre();

                if (kullaniciAdi == _kullaniciAdi && sifre == _sifre)
                {
                    YoneticiPaneli.YoneticiMenu("YÖNETİCİ PANELİ");
                }
                else
                {
                    Console.WriteLine("Kullanıcı adı veya şifre yanlış lütfen doğru giriniz.");
                    Console.WriteLine();
                }
                Console.Write("Ana menüye dönmek için ESC tuşuna basınız, tekrar denemek için herhangi bir tuşa basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);
        }

        static string Sifre()
        {
            string sifre = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                {
                    sifre += key.KeyChar;
                    Console.Write("*");
                }


            } while (key.Key != ConsoleKey.Enter);
            return sifre;
        }
    }
}