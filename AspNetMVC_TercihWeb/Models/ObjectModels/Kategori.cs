using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMVC_TercihWeb.Models.ObjectModels
{
    public class Kategori
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KategoriNo { get; set; }

        [Display(Name="Kategori Adı")]
        public string KategoriAdi { get; set; }
    }
}