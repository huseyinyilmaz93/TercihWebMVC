(function () {
    window.onload = function () {
        fnc_kullanicilariAl();
    }
    function fnc_kullanicilariAl() {
        $.ajax({
            type: "GET",
            url: "/API/Hesap/TumKullanicilar",
            contentType: "application/json",
            success: function (data) {
                var i = 0;
                var kayitlar = document.getElementById("kullanicilar");
                kayitlar.innerHTML = "";
                for (i; i < data.length; i++) {
                    var tr = document.createElement("tr");
                    tr.id = (i + 1);

                    var tdResim = document.createElement("td");
                    var resim = document.createElement("img");
                    resim.src = "/Content/images/user.png";
                    resim.classList.add("img-responsive");
                    resim.classList.add("img-circle");
                    resim.classList.add("wdthgt80");
                    resim.alt = "user image" + (i + 1);
                    tdResim.appendChild(resim);
                    tr.appendChild(tdResim);

                    var tdAd = document.createElement("td");
                    tdAd.appendChild(document.createTextNode(data[i].Ad));
                    tr.appendChild(tdAd);

                    var tdSoyad = document.createElement("td");
                    tdSoyad.appendChild(document.createTextNode(data[i].Soyad));
                    tr.appendChild(tdSoyad);

                    var tdKullaniciAdi = document.createElement("td");
                    tdKullaniciAdi.appendChild(document.createTextNode(data[i].UserName));
                    tr.appendChild(tdKullaniciAdi);

                    var tdEmail = document.createElement("td");
                    tdEmail.appendChild(document.createTextNode(data[i].Email));
                    tr.appendChild(tdEmail);

                    var tdSil = document.createElement("td");
                    var btnSil = document.createElement("input");
                    btnSil.id = data[i].Id;
                    btnSil.value = "Sil";
                    btnSil.name = (i + 1);
                    btnSil.type = "button";
                    btnSil.addEventListener("click", fnc_kullaniciSil);
                    btnSil.classList.add("form-control");
                    tdSil.appendChild(btnSil);
                    tr.appendChild(tdSil);

                    kayitlar.appendChild(tr);
                }
            },
            error: function (data) {

            }
        });
    }

    function fnc_kullaniciSil() {
        var id = this.id;
        $.ajax({
            type: "GET",
            url: "/API/Hesap/KullaniciSil/" + id,
            contentType: "application/json",
            success: function () {
                fnc_kullanicilariAl();
                alert("Kullanici Silindi");
            }
        });
    }
})();