"use strict";
(function () {
    window.onload = function () {
        document.getElementById("btn_giris").onclick = fnc_girisYap;
    }

    function fnc_girisYap() {

        var hata = document.getElementById("hata");
        hata.innerText = "";

        var KullaniciAdi = document.getElementById("KullaniciAdi").value;
        var Sifre = document.getElementById("Sifre").value;
        var BeniHatirla = document.getElementById("BeniHatirla").value;


        var model = {
            KullaniciAdi: KullaniciAdi, Sifre: Sifre, BeniHatirla: BeniHatirla
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/API/Hesap/GirisYap",
            contentType: "application/json",
            success: function (data) {
                alert("123");
                var url = "";
                var kullaniciTipi = data;
                if (data == "ADMIN")
                    url = "/Admin/Giris";
                else
                    url = "/Kullanici/Giris"

                $.ajax({
                    type: "POST",
                    data: JSON.stringify(model),
                    url: url,
                    contentType: "application/json",
                    success: function () {
                        if (kullaniciTipi == "ADMIN")
                            window.location.replace("/Admin/Index");
                        else
                            window.location.replace("/Kullanici/Index");
                    }
                })

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