using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Lise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LiseNo { get; set; }
        [Display(Name="Lise Adı")]
        public string LiseAdi { get; set; }
        [Display(Name="Taban Puanı")]
        public double TabanPuani { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual Il Il { get; set; }
        public virtual Ilce Ilce { get; set; }

        public virtual LiseTuru LiseTuru { get; set; }
        public virtual YabanciDil YabanciDil { get; set; }
    }
}