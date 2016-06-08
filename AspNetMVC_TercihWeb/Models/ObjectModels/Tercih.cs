using AspNetMVC_TercihWeb.Models.MembershipModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Tercih
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TercihNo { get; set; }
        public int TercihSirasi { get; set; }
        public virtual AppKullanici Kullanici { get; set; }
        public virtual Bolum Bolum { get; set; }
    }
}