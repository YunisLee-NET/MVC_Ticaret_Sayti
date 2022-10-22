using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class KarqoIsciler
    {
        [Key]
        public int TeslimatciID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Mail { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Sifre { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(1000)]
        public string Foto { get; set; }

        public ICollection<Karqo> Karqos { get; set; }
    }
}