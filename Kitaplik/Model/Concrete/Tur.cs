using Kitaplik.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kitaplik.Model.Concrete
{
    public class Tur : BaseClass
    {
        [Required(ErrorMessage = "Lütfen tür bilgisi giriniz.")]
        [StringLength(100)]
        public string Turu { get; set; }

        public virtual ICollection<Kitap> Kitaplar { get; set; }
        internal void Yazdır()
        {
            Console.WriteLine($"Adı: {Turu}" +
                $"\nOluşturma tarihi: {CreateDate.ToString("dd.MM.yyyy HH:mm:ss")}");
        }
    }
}
