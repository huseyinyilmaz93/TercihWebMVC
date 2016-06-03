using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Il
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IlNo { get; set; }
        [Display(Name="İl Adı")]
        public string IlAdi { get; set; }

    }
}