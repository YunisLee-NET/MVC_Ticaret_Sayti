using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class KarqoDetallar
    {
        [Key]
        public int DetalID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(10)]
        public string KarqoSeriya { get; set; }
        [Column(TypeName = "Nvarchar")]
        public string Hereket { get; set; }
        public DateTime Tarix { get; set; }
    }
}