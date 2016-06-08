(function () {
    window.onload = function () {
        $.ajax({
            type: "GET",
            url: "/API/Hesap/TumKullanicilar",
            contentType: "application/json",
            success: function (data) {
                var i = 0;
                var kayitlar = document.getElementById("kullanicilar");
                for (i; i < data.length; i++) {
                    var tr = document.createElement("tr");
                    tr.id = (i + 1);

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
                    btnSil.addEventListener("click", fnc_kullaniciSil);
                    btnSil.classList.add("form-control");
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
                alert("Kullanici Silindi");
                var tr = this.parentNode.parentNode;
                document.getElementById(tr.id).parentNode.removeChild(tr);
            }
        });
    }
})();