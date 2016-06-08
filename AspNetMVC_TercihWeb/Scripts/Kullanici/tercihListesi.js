(function () {
    window.onload = function () {
        $.ajax({
            type: "GET",
            url: "/API/Tercih/Tercihler/" + document.getElementById("id").value,
            contentType: "application/json",
            success: function (data) {

                var kayitlar = document.getElementById("kayitlar");
                kayitlar.innerHTML = "";
                var i = 0;
                for (i; i < data.length; i++) {
                    var tr = document.createElement("tr");
                    tr.id = (i + 1);
                    var tdBolumKodu = document.createElement("td");
                    tdBolumKodu.appendChild(document.createTextNode(data[i].BolumKodu));
                    tr.appendChild(tdBolumKodu);

                    var tdUniversiteAdi = document.createElement("td");
                    tdUniversiteAdi.appendChild(document.createTextNode(data[i].UniversiteAdi));
                    tr.appendChild(tdUniversiteAdi);

                    var tdFakulteAdi = document.createElement("td");
                    tdFakulteAdi.appendChild(document.createTextNode(data[i].FakulteAdi));
                    tr.appendChild(tdFakulteAdi);

                    var tdBolumAdi = document.createElement("td");
                    tdBolumAdi.appendChild(document.createTextNode(data[i].BolumAdi));
                    tr.appendChild(tdBolumAdi);

                    var tdPuanTuru = document.createElement("td");
                    tdPuanTuru.appendChild(document.createTextNode(data[i].PuanTuru));
                    tr.appendChild(tdPuanTuru);

                    var tdYerlesen = document.createElement("td");
                    tdYerlesen.appendChild(document.createTextNode(data[i].Yerlesen));
                    tr.appendChild(tdYerlesen);

                    var tdKontenjan = document.createElement("td");
                    tdKontenjan.appendChild(document.createTextNode(data[i].Kontenjan));
                    tr.appendChild(tdKontenjan);

                    var tdoEnYuksek = document.createElement("td");
                    tdoEnYuksek.appendChild(document.createTextNode(Math.round(data[i].OkulEnYuksekPuan * 100) / 100));
                    tr.appendChild(tdoEnYuksek);

                    var tdoEnDusuk = document.createElement("td");
                    tdoEnDusuk.appendChild(document.createTextNode(Math.round(data[i].OkulEnDusukPuan * 100) / 100));
                    tr.appendChild(tdoEnDusuk);

                    var tdEnYuksek = document.createElement("td");
                    tdEnYuksek.appendChild(document.createTextNode(Math.round(data[i].EnYuksekPuan * 100) / 100));
                    tr.appendChild(tdEnYuksek);

                    var tdEnDusuk = document.createElement("td");
                    tdEnDusuk.appendChild(document.createTextNode(Math.round(data[i].EnDusukPuan * 100) / 100));
                    tr.appendChild(tdEnDusuk);

                    var tdCikar = document.createElement("td");
                    var buton = document.createElement("input");
                    buton.value = "Çıkar";
                    buton.type = "button";
                    buton.id = data[i].BolumKodu;
                    buton.classList.add("form-control");
                    buton.addEventListener("click", fnc_OgrencidenCikar);
                    tdCikar.appendChild(buton);
                    tr.appendChild(tdCikar);

                    kayitlar.appendChild(tr);
                }

            }
        });
    }
    function fnc_OgrencidenCikar() {
        var bolumKodu = this.id;
        var id = document.getElementById("id").value;
        $.ajax({
            type: "GET",
            url: "/API/Tercih/TercihCikar/" + id + "/" + bolumKodu,
            contentType: "application/json",
            success: function () {
                alert("Listeden Çıkarıldı.");
            }
        });

        var elem = document.getElementById(this.parentNode.parentNode.id)
        elem.parentNode.removeChild(elem);
    }
})();