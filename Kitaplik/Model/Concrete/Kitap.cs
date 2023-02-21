using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitaplik.Model.Abstract;

namespace Kitaplik.Model.Concrete
{
    public class Kitap :BaseClass
    {
        [Required(ErrorMessage = " Lütfen kitap adı giriniz.")]
        [StringLength(100)]
        public string KitapAdi { get; set; }
        [Required(ErrorMessage = " Lütfen yazar adı giriniz.")]
        [StringLength(100)]
        public string YazarAdi { get; set; }

        [Range(0, 10000, ErrorMessage = "Lütfen 0 ile 10000 arasında bir değer giriniz.")]
        public decimal Fiyat { get; set; }

        public int TurId { get; set; }
        [ForeignKey("TurId")]
        public virtual Tur Tur { get; set; }
    }
}
