using Kitaplik.Model.Abstract;
using Kitaplik.Model.AnaMenu;
using Kitaplik.Model.Concrete;
using Kitaplik.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Kitaplik.Model.AnaMenu
{
    internal class KullaniciPaneli
    {
        public static void KullaniciMenu(string baslik)
        {

            ConsoleKey cevap;
            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                Console.WriteLine("\r        1- Kitap Adına Göre Listele" +
                    "\r\n        2- Kitap Türüne Göre Listele" +
                    "\r\n        3- Kitap Yazarına Göre Listele" +
                    "\r\n        4- Kitap ID'sine Göre Ara" +
                    "\r\n        ESC- Programdan Çık");
                Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                cevap = Console.ReadKey().Key;
                Menu(cevap);
            } while (cevap != ConsoleKey.Escape);


        }
        public static void Menu(ConsoleKey cevap)
        {
            switch (cevap)
            {
                case ConsoleKey.D1:
                    KitapAdınaGoreListele("ADLARINA GÖRE KİTAPLAR");
                    break;
                case ConsoleKey.D2:
                    TurlereGoreListele("TÜRLERİNE GÖRE KİTAPLAR");
                    break;
                case ConsoleKey.D3:
                    YazarlaraGoreListele("YAZARLARINA GÖRE KİTAPLAR");
                    break;
                case ConsoleKey.D4:
                    KitapAra("ID BİLGİSİNE GÖRE KİTAP ARA");
                    break;
                case ConsoleKey.D5:
                    // KisiEkle("KİSİ EKLE");
                    break;


            }
        }

        private static void KitapAdınaGoreListele(string baslik)
        {
            ConsoleKey exit;

            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                using (var db = new BookDbContext())
                {
                    var kategoriler = db.Kitaplar.Where(w => w.IsDeleted == false).GroupBy(g => g.KitapAdi);

                    foreach (var kategori in kategoriler)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Kitap: " + kategori.Key);
                        Console.WriteLine("--------------------------------");
                        foreach (var kitap in kategori)
                        {
                            Console.WriteLine("Kitap ID: " + kitap.Id);
                            Console.WriteLine("Yazar: " + kitap.YazarAdi);
                            Console.WriteLine("Fiyat: " + kitap.Fiyat);
                            Console.WriteLine();
                        }
                    }
                }
                Console.Write("Ana menüye dönmek için ESC tuşuna basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);
        }

        private static void KitapAra(string baslik)
        {
            ConsoleKey exit;
            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                Console.Write("Aramak istediğiniz kitabın ID'sini giriniz: ");
                int kitapId = int.Parse(Console.ReadLine());

                using (var db = new BookDbContext())
                {
                    var kitapBul = db.Kitaplar.Find(kitapId);
                    if (kitapBul == null)
                    {
                        Console.WriteLine("Kitap bulunamadı.");
                    }
                    else
                    {
                        Console.WriteLine("Kitap adı: " + kitapBul.KitapAdi);
                        Console.WriteLine("Yazar adı: " + kitapBul.YazarAdi);
                        Console.WriteLine("Fiyat: " + kitapBul.Fiyat);
                    }
                }
                Console.Write("Ana menüye dönmek için ESC tuşuna basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);
        }

        private static void YazarlaraGoreListele(string baslik)
        {
            ConsoleKey exit;

            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                using (var db = new BookDbContext())
                {
                    var kategoriler = db.Kitaplar.Where(w => w.IsDeleted == false).GroupBy(g => g.YazarAdi);

                    foreach (var kategori in kategoriler)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Yazar: " + kategori.Key);
                        Console.WriteLine("--------------------------------");
                        foreach (var kitap in kategori)
                        {
                            Console.WriteLine("Kitap ID: " + kitap.Id);
                            Console.WriteLine("Kitap adı: " + kitap.KitapAdi);
                            Console.WriteLine("Fiyat: " + kitap.Fiyat);
                            Console.WriteLine();
                        }
                    }
                }
                Console.Write("Ana menüye dönmek için ESC tuşuna basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);
        }

        private static void TurlereGoreListele(string baslik)
        {
            ConsoleKey exit;

            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                using (var db = new BookDbContext())
                {
                    var kategoriler = db.Kitaplar.Where(w => w.IsDeleted == false).GroupBy(g => g.Tur.Turu);



                    foreach (var kategori in kategoriler)
                    {
                        Console.WriteLine("***** KİTAP TÜRÜ *****");
                        Console.WriteLine("      " + kategori.Key);
                        Console.WriteLine("Kitap sayısı: " + kategori.Count());
                        Console.WriteLine("--------------------------------");
                        foreach (var kitap in kategori)
                        {
                            Console.WriteLine("Kitap ID: " + kitap.Id);
                            Console.WriteLine("Kitap adı: " + kitap.KitapAdi);
                            Console.WriteLine("Yazar adı: " + kitap.YazarAdi);
                            Console.WriteLine("Fiyat: " + kitap.Fiyat);
                            Console.WriteLine();
                        }
                    }


                }
                Console.Write("Ana menüye dönmek için ESC tuşuna basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);





        }
    }
}