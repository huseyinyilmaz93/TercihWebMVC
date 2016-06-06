"use strict";
(function () {
    window.onload = function () {
        document.getElementById("btn_kayit").onclick = fnc_kayit;
    }

    function fnc_kayit() {
        var hata = document.getElementById("hata");
        hata.innerText = "";
        
        var Ad = document.getElementById("Ad").value;
        var Soyad = document.getElementById("Soyad").value;
        var KullaniciAdi = document.getElementById("KullaniciAdi").value;
        var Email = document.getElementById("Email").value;
        var Sifre = document.getElementById("Sifre").value;
        var SifreTekrar = document.getElementById("SifreTekrar").value;

        var model = {
            Ad:Ad,Soyad:Soyad,KullaniciAdi:KullaniciAdi,Email:Email,Sifre:Sifre,SifreTekrar:SifreTekrar
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/API/Hesap/Kayit",
            contentType: "application/json",
            success: function (data) {
                var id = data;
                $.ajax({
                    type: "GET",
                    url: "/API/Hesap/KayitOnaylama/" + id,
                    contentType: "application/json",
                    success: function () {
                        window.location.replace("/Hesap/KayitOnaylama/" + id);
                    },
                    error: function (data) {
                        alert("Email gönderilemedi! Lütfen yönlendirildiğiniz sayfada tekrar mail gönder butonuna tıklayın.");
                        window.location.replace("/Hesap/KayitOnaylama/" + id);
                    }
                });
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
}
)();