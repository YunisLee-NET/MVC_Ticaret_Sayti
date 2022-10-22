﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class Sobeler
    {
        [Key]
        public int SobeID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string SobeAd { get; set; }
        public bool SobeVeziyyet { get; set; }
        public ICollection<Isciler> Iscilers { get; set; }
    }
}