using Kitaplik.Model.Abstract;
using Kitaplik.Model.Concrete;
using Kitaplik.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kitaplik.Model.AnaMenu
{
    internal class YoneticiPaneli
    {
        internal static void YoneticiMenu(string baslik)
        {
            
            ConsoleKey cevap;
            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                Console.WriteLine("\r        1- Kitap Ekle" +
                    "\r\n        2- Kitap Sil" +
                    "\r\n        3- Kitap Listele" +
                    "\r\n        4- Kitap Fiyatı Güncelle" +
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
                     KitapEkle("KİTAP EKLE");
                    break;
                case ConsoleKey.D2:
                    KitapSil("KİTAP SİL");
                    break;
                case ConsoleKey.D3:
                    KitapListele("KİTAP LİSTELE");
                    break;
                case ConsoleKey.D4:
                    KitapFiyatGuncelle("FİYAT GÜNCELLE");
                    break;
            }
        }

        private static void KitapFiyatGuncelle(string baslik)
        {
            ConsoleKey exit;
            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                Console.Write("Fiyatını güncellemek istediğiniz kitabın ID'sini giriniz: ");
                int kitapId = int.Parse(Console.ReadLine());
                Console.Write("Yeni Fiyat giriniz: ");
                decimal kitapFiyatDegis = decimal.Parse(Console.ReadLine());
                using (var db = new BookDbContext())
                {
                    var kitapFiyat = db.Kitaplar.Find(kitapId);
                    kitapFiyat.Fiyat = kitapFiyatDegis;
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine($"{kitapFiyat.KitapAdi} kitabının fiyatı başarı ile güncellendi.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Hata Mesajı: " + e.Message);
                    }
                }
                Console.Write("Ana menüye dönmek için ESC tuşuna basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);
        }

        private static void KitapSil(string baslik)
        {
            ConsoleKey exit;
            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                Console.Write("Silmek istediğiniz kitabın ID'sini giriniz: ");
                int kitapId = int.Parse(Console.ReadLine());
                using (var db = new BookDbContext())
                {
                    var kitapSil = db.Kitaplar.Find(kitapId);
                    
                    kitapSil.IsDeleted = true;
                    kitapSil.DeletedDate = DateTime.Now;
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine($"{kitapSil.KitapAdi} kitabı başarı ile silindi.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Hata Mesajı: " + e.Message);
                    }
                }
                Console.Write("Ana menüye dönmek için ESC tuşuna basınız: ");
                exit = Console.ReadKey().Key;
            } while (exit != ConsoleKey.Escape);
        }

        private static void KitapListele(string baslik)
        {
            ConsoleKey exit;

            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                using (var db = new BookDbContext())
                {
                    var kategoriler = db.Kitaplar.Where(w=> w.IsDeleted == false).GroupBy(g => g.KitapAdi);

                    foreach (var kategori in kategoriler)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Kitap adı: " + kategori.Key);
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

        private static void KitapEkle(string baslik)
        {

            string exit = string.Empty;
            do
            {
                Baslik_Cikis.BaslikYazdir(baslik);
                using (var db = new BookDbContext())
                {
                    List<Kitap> kitaplar = new List<Kitap>();
                    Console.Write("Kitap Adı: ");
                    string _kitapAdi = Console.ReadLine();
                    int _turId = KitapTuru("Kitap türü seçiniz: ");
                    Console.Write("Yazar Adı: ");
                    string _yazarAdi = Console.ReadLine();
                    Console.Write("Kitap Fiyatı: ");
                    decimal _fiyat = decimal.Parse(Console.ReadLine());
                    kitaplar.Add(new Kitap
                    {
                        KitapAdi = _kitapAdi,
                        YazarAdi = _yazarAdi,
                        Fiyat = _fiyat,
                        TurId = _turId,
                        Status = StatuType.Active
                    });
                    db.Kitaplar.AddRange(kitaplar);


                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Kitap başarıyla eklendi.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Hata : " + e.Message);
                    }
                }

                Console.Write("Tekrar Kitap eklemek ister misiniz?(E/e): ");
                exit = Console.ReadLine();
            } while (exit == "E" || exit == "e");



        }

        private static int KitapTuru(string metin)
        {
            int turId = 0;
            string kitapTuru = string.Empty;


            BookDbContext db = new BookDbContext();

            // "Çocuk"Yemek"Masal

            Console.WriteLine("***** Kitap Türleri *****" +
                "\n1- Aşk" +
                "\n2- Bilim Kurgu" +
                "\n3- Roman" +
                "\n4- Psikoloji" +
                "\n5- Din" +
                "\n6- Polisiye" +
                "\n7- Çocuk" +
                "\n8- Kişisel Gelişim" +
                "\n9- Korku - Gerilim" +
                "\n10- Dram" +
                "\n11- Yemek" +
                "\n12- Masal" +
                "\n13- Tarih" +
                "\n");
            Console.Write(metin);
            turId = int.Parse(Console.ReadLine());


            switch (turId)
            {
                case 1:
                    kitapTuru = "Aşk";
                    break;
                case 2:
                    kitapTuru = "Bilim Kurgu";
                    break;
                case 3:
                    kitapTuru = "Roman";
                    break;
                case 4:
                    kitapTuru = "Psikoloji";
                    break;
                case 5:
                    kitapTuru = "Din";
                    break;
                case 6:
                    kitapTuru = "Polisiye";
                    break;
                case 7:
                    kitapTuru = "Çocuk";
                    break;
                case 8:
                    kitapTuru = "Kişisel Gelişim";
                    break;
                case 9:
                    kitapTuru = "Korku - Gerilim";
                    break;
                case 10:
                    kitapTuru = "Dram";
                    break;
                case 11:
                    kitapTuru = "Yemek";
                    break;
                case 12:
                    kitapTuru = "Masal";
                    break;
                case 13:
                    kitapTuru = "Tarih";
                    break;

                default:
                    Console.WriteLine("Lütfen belirtilen değerleri giriniz.");
                    break;
            }
            return turId;
        }
    }
}