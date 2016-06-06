"use strict";

(function () {
    window.onload = function () {
        document.getElementById("btn_sifremiUnuttum").onclick = fnc_sifremiUnuttum;
    }

    function fnc_sifremiUnuttum() {
        var hata = document.getElementById("hata");
        hata.innerText = "";
        var KullaniciAdi = document.getElementById("KullaniciAdi").value;
        var Email = document.getElementById("Email").value;

        var model = {
            KullaniciAdi: KullaniciAdi, Email: Email
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/API/Hesap/SifremiUnuttum",
            contentType: "application/json",
            success: function (data) {
                alert("Email adresinize şifre sıfırlama isteği gönderildi. Lütfen kontrol edin..");
                window.location.replace("/Site/Index");
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
        })
    }

})();