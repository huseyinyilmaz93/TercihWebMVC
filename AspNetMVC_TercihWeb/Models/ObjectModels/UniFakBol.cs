using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class UniFakBol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Universite Universite { get; set; }
        public virtual Fakulte Fakulte { get; set; }
        public virtual Bolum Bolum { get; set; }
    }
}