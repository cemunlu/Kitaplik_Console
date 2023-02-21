using Kitaplik.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Model.Context
{
    public class BookDbContext : DbContext
    {
        public BookDbContext() : base("myConnectionString")
        {

        }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
    }
}
