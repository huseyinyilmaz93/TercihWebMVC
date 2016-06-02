using System.ComponentModel.DataAnnotations;

namespace AspNetMVC_TercihWeb.Models.AccountModels
{
    public class Kayit
    {
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        [Display(Name="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name="Şifre")]
        public string Sifre { get; set; }
        [Required]
        [Display(Name="Şifre Tekrar")]
        [Compare("Sifre",ErrorMessage="Şifreler Uyuşmuyor")]
        public string SifreTekrar { get; set; }
    }
}