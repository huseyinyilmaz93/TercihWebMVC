(function () {
    window.onload = function () {
        document.getElementById("btn_sifreDegistir").onclick = fnc_sifreDegistir;
    }

    function fnc_sifreDegistir() {
        var hata = document.getElementById("hata");
        hata.innerText = "";
        
        var id = document.getElementById("id").value;
        var KullaniciAdi = document.getElementById("KullaniciAdi").value;
        var EskiSifre = document.getElementById("EskiSifre").value;
        var YeniSifre = document.getElementById("YeniSifre").value;
        var YeniSifreTekrar = document.getElementById("YeniSifreTekrar").value;
        
        var model = {
            KullaniciAdi : KullaniciAdi, EskiSifre :EskiSifre, YeniSifre : YeniSifre, YeniSifreTekrar:YeniSifreTekrar
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/API/Hesap/SifreDegistir/" + id,
            contentType: "application/json",
            success: function (data) {
                alert("Şifre başarıyla değiştirildi ...");
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
        });
    }
})();