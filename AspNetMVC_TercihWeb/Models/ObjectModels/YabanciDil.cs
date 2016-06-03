using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class YabanciDil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DilNo { get; set; }
        [Display(Name="Yabanci Dil Adı")]
        public string DilAdi { get; set; }
    }
}