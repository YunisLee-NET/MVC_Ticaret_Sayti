using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticaret.Models.Sinifler
{
    public class Musteriler
    {
        [Key]
        public int MusteriID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(20, ErrorMessage ="20 simvoldan artıq daxil etməyin!")]
        public string MusteriAd { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(20)]
        [Required(ErrorMessage ="Bu hissə boş olmamalıdır!")]
        public string MusteriSoyad { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string MusteriSeher { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string MusteriMail { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string MusteriSifre { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(2000)]
        public string MusteriFoto { get; set; }

        public ICollection<SatisHereket> SatisHerekets { get; set; }
        public ICollection<Karqo> Karqos { get; set; }
    }
}