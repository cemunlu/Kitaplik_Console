using Kitaplik.Model.Abstract;
using Kitaplik.Model.AnaMenu;
using Kitaplik.Model.Concrete;
using Kitaplik.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            ConsoleKey cevap, sonKarar;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("***** KÜTÜPHANE UYGULAMASI *****");
                    /*   Console.WriteLine("--------------------------------" +
                           "\r\n        1- Kitap ekle" +
                           "\r\n        2- Türe Göre Kitap Listele" +
                           "\r\n        3- Yazara Göre Kitap Listele" +
                           "\r\n        4- Kitap Ara" +
                           "\r\n        5- Kitap Sil" +
                           "\r\n        6- Kitap Fiyatı Güncelle" +
                           "\r\n        7- Kişi Ara" +
                           "\r\n        8- Kişi Sil" +
                           "\r\n        9- Kitap Emanet Et" +
                           "\r\n        0- Kitap İade Et" +
                           "\r\n        ESC- Programdan Çık");

                       
                       //TurEkle();
                      */
                    Console.WriteLine("--------------------------------" +
                           "\r\n        1- Kullanıcı Paneli" +
                           "\r\n        2- Yönetici Paneli");
                    Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                    cevap = Console.ReadKey().Key;
                    AnaMenu.Menu(cevap);
                    //Menu(cevap);
                } while (cevap != ConsoleKey.Escape);

                Console.WriteLine();
                Console.Write("Programı kapatmak istediğinizden emin misiniz?(e): ");
                sonKarar = Console.ReadKey().Key;

                Console.WriteLine();

            } while (sonKarar != ConsoleKey.E);



        }
        
        private static void TurEkle()
        {/*
            using (var db = new BookDbContext())
            {
                List<Tur> turler = new List<Tur>();
                turler.Add(new Tur() { Turu = "Aşk", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Bilim Kurgu", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Roman", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Psikoloji", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Din", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Polisiye", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Çocuk", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Kişisel Gelişim", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Korku-Gerilim", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Dram", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Yemek", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Masal", Status = StatuType.Active });
                turler.Add(new Tur() { Turu = "Tarih", Status = StatuType.Active });

                db.Turler.AddRange(turler);

                db.SaveChanges();
            
            }

            */
        }
        
        
    }
}
