using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Universite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniversiteNo { get; set; }
        [Display(Name="Üniversite Adı")]
        public string UniversiteAdi { get; set; }
        [Display(Name="İl")]
        public string Il { get; set; }
        [Display(Name="Üniversite Türü")]
        public string UniTuru { get; set; }
        [Display(Name="Web Adresi")]
        public string WebAdresi { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<Fakulte> Fakulteler { get; set; }
    }
}