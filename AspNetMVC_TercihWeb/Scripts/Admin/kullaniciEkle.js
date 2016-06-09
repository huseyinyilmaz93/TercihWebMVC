(function () {
    window.onload = function () {
        document.getElementById("btn_kaydet").onclick = fnc_kaydet;
    }

    function fnc_kaydet() {
        var hata = document.getElementById("hata");
        hata.innerText = "";

        var MailGonder = (document.getElementById("secim1").checked == true) ? "false" : "true";

        var Ad = document.getElementById("Ad").value;
        var Soyad = document.getElementById("Soyad").value;
        var KullaniciAdi = document.getElementById("KullaniciAdi").value;
        var Email = document.getElementById("Email").value;
        var Sifre = document.getElementById("Sifre").value;
        var SifreTekrar = document.getElementById("SifreTekrar").value;

        var model = {
            Ad: Ad, Soyad: Soyad, KullaniciAdi: KullaniciAdi, Email: Email, Sifre: Sifre, SifreTekrar: SifreTekrar
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/API/Hesap/KullaniciEkle/" + MailGonder,
            contentType: "application/json",
            success: function (data) {
                alert("Kullanıcı eklendi!");
                window.location.replace("/Admin/Index");
            },
            error: function (data) {
                var status = data.status;
                var d = JSON.parse(data.responseText);
                if (status == 405) {
                    var ul = document.createElement("ul");
                    var li = document.createElement("li");
                    li.appendChild(document.createTextNode(d.ModelState.Hata[0]));
                    ul.appendChild(li);
                    hata.appendChild(ul);
                } else if (status == 400) {
                    var arr = [];
                    for (var x in d.ModelState) {
                        arr.push(d.ModelState[x]);
                    } //OBJECT TO ARRAY

                    var ul = document.createElement("ul");
                    for (var x in arr) {
                        var li = document.createElement("li");
                        li.appendChild(document.createTextNode(arr[x][0]));
                        ul.appendChild(li);
                    }
                    hata.appendChild(ul);
                }
            }
        });
    }
})();