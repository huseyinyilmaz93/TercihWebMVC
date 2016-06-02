using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Ilce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IlceNo { get; set; }
        [Display(Name="İlçe Adı")]
        public string IlceAdi { get; set; }
    }
}