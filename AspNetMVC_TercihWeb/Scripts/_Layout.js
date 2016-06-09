
window.onload = function () {
        document.getElementById("btn_giris").onclick = fnc_girisYap;
        var id = document.getElementById("id").value;
        $.ajax({
            type: "GET",
            url: "/API/Hesap/KullaniciBilgi/" + id,
            contentType: "application/json",
            success: function (data) {
                if (data.Ad == null && data.Soyad == null)
                    document.getElementById("kullanici").innerText = "ADMİN";
                else
                    document.getElementById("kullanici").innerText = data.Ad + " " + data.Soyad;
            }
        });
    };
    function fnc_girisYap() {
        var hataGiris = document.getElementById("hataGiris");
        hataGiris.innerText = "";

        var KullaniciAdi = document.getElementById("KullaniciAdi").value;
        var Sifre = document.getElementById("Sifre").value;
        var BeniHatirla = document.getElementById("BeniHatirla").value;

        //alert(KullaniciAdi + Sifre);
        var model = {
            KullaniciAdi: KullaniciAdi, Sifre: Sifre, BeniHatirla: BeniHatirla
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/API/Hesap/GirisYap",
            contentType: "application/json",
            success: function (data) {
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
                    hataGiris.appendChild(ul);
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
                    hataGiris.appendChild(ul);
                }

            }
        });

    }
