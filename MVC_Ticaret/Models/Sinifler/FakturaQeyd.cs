using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class FakturaQeyd
    {
        [Key]
        public int FQID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(100)]
        public string Aciqlama { get; set; }
        public int Miqdar { get; set; }
        public decimal VahidQiymet { get; set; }
        public decimal UmumiMebleg { get; set; }
        public Faktura Faktura { get; set; }
    }
}