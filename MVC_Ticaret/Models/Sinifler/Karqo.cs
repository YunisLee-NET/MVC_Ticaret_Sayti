using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class Karqo
    {
        [Key]
        public int KarqoID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(1000)]
        public string Aciqlama { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(10)]
        public string KarqoSeriya { get; set; }
        public int TeslimatciID { get; set; }
        public virtual KarqoIsciler KarqoIsciler { get; set; }
        public int MusteriID { get; set; }
        public virtual Musteriler Musteriler { get; set; }
        public DateTime Tarix { get; set; }
        public bool YesNo { get; set; }
    }
}