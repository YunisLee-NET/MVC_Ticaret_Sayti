using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }

        [Column(TypeName ="Nvarchar")]
        [StringLength(50)]
        public string Gonderen { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Alan { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(100)]
        public string Movzu { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(2000)]
        public string Mezmun { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Tarix { get; set; }
    }
}