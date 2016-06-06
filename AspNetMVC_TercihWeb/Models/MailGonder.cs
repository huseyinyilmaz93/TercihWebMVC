using AspNetMVC_TercihWeb.Models.AccountModels;
using AspNetMVC_TercihWeb.Models.MembershipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AspNetMVC_TercihWeb.Models
{
    public class MailGonder
    {
        private static MailAddress gonderici = new MailAddress("tercihweb2016@gmail.com", "TercihWeb Admin");
        private static string sifre = "tercihweb";
        private static string MesajBasligi;
        private static string MesajGovde;

        public static void SifremiUnuttum(AppKullanici kullanici)
        {
            MailAddress alici = new MailAddress(kullanici.Email,string.Concat(kullanici.Ad," ",kullanici.Soyad));
            MesajBasligi = "TercihWeb Şifre Sıfırlama İsteği";
            MesajGovde = string.Concat("<h2> MERHABA, ", alici.DisplayName, "</h2><br />",
            "<p>Sizden şifre sıfırlama isteği aldık. Bu <a href='http://localhost:52276/Hesap/SifremiUnuttumOnay/" + kullanici.Id + "'>linke</a> tıklayarak,",
            " şifrenizi yenileyebilirsiniz. </p>",
            "<p>Uyarı, 3 saat içinde link zaman aşımına uğrayacaktır. Şifrenizi bu mail aldıktan sonra 3 saat içinde değiştirmelisiniz!</p>",
            "<p>Bu değişiklik sizden gelmiyorsa lütfen bildirin </p><br />",
            "<h3>TercihWeb ekibi</h3>");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(gonderici.Address, sifre),
                Timeout = 20000
            };
            using (var message = new MailMessage(gonderici, alici)
            {
                IsBodyHtml = true,
                Subject = MesajBasligi,
                Body = MesajGovde
            })
            {
                smtp.Send(message);
            }


        }
        public static void EMailOnaylama(AppKullanici kullanici)
        {
            MailAddress alici = new MailAddress(kullanici.Email, string.Concat(kullanici.Ad, " ", kullanici.Soyad));
            MesajBasligi = "TercihWeb Email Onaylama";
            MesajGovde = string.Concat("<h2> MERHABA, ", alici.DisplayName, "</h2><br />",
            "<p>Email adresinizi onaylamak için verilen <a href='http://localhost:52276/Hesap/KayitBasarili/" + kullanici.Id + "'>linke</a> tıklayınız.",
            " </p> <h3>TercihWeb ekibi</h3>");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(gonderici.Address, sifre),
                Timeout = 20000
            };
            using (var message = new MailMessage(gonderici, alici)
            {
                IsBodyHtml = true,
                Subject = MesajBasligi,
                Body = MesajGovde
            })
            {
                smtp.Send(message);
            }

        }
    }
}