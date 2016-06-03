using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Fakulte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FakulteNo { get; set; }
        [Display(Name="Fakülte Adı")]
        public string FakulteAdi { get; set; }

        public virtual ICollection<Universite> Universiteler { get; set; }
        public virtual ICollection<Bolum> Bolumler { get; set; }


    }
}