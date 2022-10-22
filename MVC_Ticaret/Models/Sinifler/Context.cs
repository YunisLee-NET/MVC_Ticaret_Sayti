using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Faktura> Fakturas { get; set; }
        public DbSet<FakturaQeyd> FakturaQeyds { get; set; }
        public DbSet<Xercler> Xerclers { get; set; }
        public DbSet<Isciler> Iscilers { get; set; }
        public DbSet<Kateqoriya> Kateqoriyas { get; set; }
        public DbSet<Mehsullar> Mehsullars { get; set; }
        public DbSet<Musteriler> Musterilers { get; set; }
        public DbSet<SatisHereket> SatisHerekets { get; set; }
        public DbSet<Sobeler> Sobelers { get; set; }
        public DbSet<Karqo> Karqos { get; set; }
        public DbSet<KarqoDetallar> KarqoDetallars { get; set; }
        public DbSet<KarqoIsciler> KarqoIscilers { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
    }
}