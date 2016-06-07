(function () {
    window.onload = function () {
        document.getElementById("btn_temizle").onclick = Temizle;
        document.getElementById("btn_hesapla").onclick = Hesapla;

        document.getElementById("txt_sinif6").onchange = Sinif6Changed;
        document.getElementById("txt_sinif7").onchange = Sinif7Changed;
        document.getElementById("txt_sinif8").onchange = Sinif8Changed;

        document.getElementById("txt_turkce").onchange = TurkceChanged;
        document.getElementById("txt_turkce2").onchange = Turkce2Changed;

        document.getElementById("txt_matematik").onchange = MatematikChanged;
        document.getElementById("txt_matematik2").onchange = Matematik2Changed;

        document.getElementById("txt_fen").onchange = FenChanged;
        document.getElementById("txt_fen2").onchange = Fen2Changed;

        document.getElementById("txt_inkilap").onchange = InkilapChanged;
        document.getElementById("txt_inkilap2").onchange = Inkilap2Changed;

        document.getElementById("txt_din").onchange = DinChanged;
        document.getElementById("txt_din2").onchange = Din2Changed;

        document.getElementById("txt_yabanciDil").onchange = YabanciDilChanged;
        document.getElementById("txt_yabanciDil2").onchange = YabanciDil2Changed;

    }

    function Sinif6Changed() {
        var deger = document.getElementById("txt_sinif6").value;
        if (deger >= 100) document.getElementById("txt_sinif6").value = 100;
        else if (deger <= 0) document.getElementById("txt_sinif6").value = 0;
    }

    function Sinif7Changed() {
        var deger = document.getElementById("txt_sinif7").value;
        if (deger >= 100) document.getElementById("txt_sinif7").value = 100;
        else if (deger <= 0) document.getElementById("txt_sinif7").value = 0;
    }

    function Sinif8Changed() {
        var deger = document.getElementById("txt_sinif8").value;
        if (deger >= 100) document.getElementById("txt_sinif8").value = 100;
        else if (deger <= 0) document.getElementById("txt_sinif8").value = 0;
    }

    function TurkceChanged() {
        var turkceDogru = document.getElementById("txt_turkce").value;
        if (turkceDogru >= 20) document.getElementById("txt_turkce").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_turkce").value = 0;
    }

    function MatematikChanged() {
        var turkceDogru = document.getElementById("txt_matematik").value;
        if (turkceDogru >= 20) document.getElementById("txt_matematik").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_matematik").value = 0;
    }

    function FenChanged() {
        var turkceDogru = document.getElementById("txt_fen").value;
        if (turkceDogru >= 20) document.getElementById("txt_fen").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_fen").value = 0;
    }

    function InkilapChanged() {
        var turkceDogru = document.getElementById("txt_inkilap").value;
        if (turkceDogru >= 20) document.getElementById("txt_inkilap").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_inkilap").value = 0;
    }

    function YabanciDilChanged() {
        var turkceDogru = document.getElementById("txt_yabanciDil").value;
        if (turkceDogru >= 20) document.getElementById("txt_yabanciDil").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_yabanciDil").value = 0;
    }

    function DinChanged() {
        var turkceDogru = document.getElementById("txt_din").value;
        if (turkceDogru >= 20) document.getElementById("txt_din").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_din").value = 0;
    }

    function Turkce2Changed() {
        var turkceDogru = document.getElementById("txt_turkce2").value;
        if (turkceDogru >= 20) document.getElementById("txt_turkce2").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_turkce2").value = 0;
    }

    function Matematik2Changed() {
        var turkceDogru = document.getElementById("txt_matematik2").value;
        if (turkceDogru >= 20) document.getElementById("txt_matematik2").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_matematik2").value = 0;
    }

    function Fen2Changed() {
        var turkceDogru = document.getElementById("txt_fen2").value;
        if (turkceDogru >= 20) document.getElementById("txt_fen2").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_fen2").value = 0;
    }

    function Inkilap2Changed() {
        var turkceDogru = document.getElementById("txt_inkilap2").value;
        if (turkceDogru >= 20) document.getElementById("txt_inkilap2").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_inkilap2").value = 0;
    }

    function YabanciDil2Changed() {
        var turkceDogru = document.getElementById("txt_yabanciDil2").value;
        if (turkceDogru >= 20) document.getElementById("txt_yabanciDil2").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_yabanciDil2").value = 0;
    }

    function Din2Changed() {
        var turkceDogru = document.getElementById("txt_din2").value;
        if (turkceDogru >= 20) document.getElementById("txt_din2").value = 20;
        else if (turkceDogru <= 0) document.getElementById("txt_din2").value = 0;
    }

    function Temizle() {

        document.getElementById("txt_sinif6").value = "";
        document.getElementById("txt_sinif7").value = "";
        document.getElementById("txt_sinif8").value = "";

        document.getElementById("txt_turkce").value = "";
        document.getElementById("txt_matematik").value = "";
        document.getElementById("txt_fen").value = "";
        document.getElementById("txt_inkilap").value = "";
        document.getElementById("txt_yabanciDil").value = "";
        document.getElementById("txt_din").value = "";

        document.getElementById("txt_turkce2").value = "";
        document.getElementById("txt_matematik2").value = "";
        document.getElementById("txt_fen2").value = "";
        document.getElementById("txt_inkilap2").value = "";
        document.getElementById("txt_yabanciDil2").value = "";
        document.getElementById("txt_din2").value = "";
    }
    function Hesapla() {

        var sinif6 = document.getElementById("txt_sinif6").value == "" ? 0 : document.getElementById("txt_sinif6").value;
        var sinif7 = document.getElementById("txt_sinif7").value == "" ? 0 : document.getElementById("txt_sinif7").value;
        var sinif8 = document.getElementById("txt_sinif8").value == "" ? 0 : document.getElementById("txt_sinif8").value;

        var turkce = (document.getElementById("txt_turkce").value == "") ? 0 : parseFloat(document.getElementById("txt_turkce").value);
        var matematik = (document.getElementById("txt_matematik").value == "") ? 0 : parseFloat(document.getElementById("txt_matematik").value);
        var fen = (document.getElementById("txt_fen").value == "") ? 0 : parseFloat(document.getElementById("txt_fen").value);
        var inkilap = (document.getElementById("txt_inkilap").value == "") ? 0 : parseFloat(document.getElementById("txt_inkilap").value);
        var yabanciDil = (document.getElementById("txt_yabanciDil").value == "") ? 0 : parseFloat(document.getElementById("txt_yabanciDil").value);
        var din = (document.getElementById("txt_din").value == "") ? 0 : parseFloat(document.getElementById("txt_din").value);

        var turkce2 = (document.getElementById("txt_turkce2").value == "") ? 0 : parseFloat(document.getElementById("txt_turkce2").value);
        var matematik2 = (document.getElementById("txt_matematik2").value == "") ? 0 : parseFloat(document.getElementById("txt_matematik2").value);
        var fen2 = (document.getElementById("txt_fen2").value == "") ? 0 : parseFloat(document.getElementById("txt_fen2").value);
        var inkilap2 = (document.getElementById("txt_inkilap2").value == "") ? 0 : parseFloat(document.getElementById("txt_inkilap2").value);
        var yabanciDil2 = (document.getElementById("txt_yabanciDil2").value == "") ? 0 : parseFloat(document.getElementById("txt_yabanciDil2").value);
        var din2 = (document.getElementById("txt_din2").value == "") ? 0 : parseFloat(document.getElementById("txt_din2").value);

        var osp1 = ((((turkce * 5) * 4 + (matematik * 5) * 4 + (fen * 5) * 4 + (inkilap * 5) * 2 + (yabanciDil * 5) * 4 + (din * 5) * 4) / 18) / 100) * 700;
        var osp2 = ((((turkce2 * 5) * 4 + (matematik2 * 5) * 4 + (fen2 * 5) * 4 + (inkilap2 * 5) * 2 + (yabanciDil2 * 5) * 4 + (din2 * 5) * 4) / 18) / 100) * 700;
        var aosp = (osp1 + osp2) / 2;
        var yep = (parseFloat(sinif6) + parseFloat(sinif7) + parseFloat(sinif8) + parseFloat(aosp)) / 2;

        var aciklama = ["6.Sınıf Yılsonu Başarı Puanı", "7.Sınıf Yılsonu Başarı Puanı", "8.Sınıf Yılsonu Başarı Puanı", "Ağırlıklandırılmış Ortak Sınav Puanı", "Yerleştirme Esas Puan (YEP)"];
        var puanlar = [sinif6, sinif7, sinif8, Dogrula(aosp), Dogrula(yep)];

        var table = document.createElement("table");

        for (var i = 0; i < puanlar.length; i++) {
            var tr = document.createElement("tr");
            var td1 = document.createElement("td");
            td1.appendChild(document.createTextNode(aciklama[i]));
            td1.className = "sonuc";
            td1.style.fontWeight = "bold";
            td1.style.width = "250px";
            var td2 = document.createElement("td");
            td2.appendChild(document.createTextNode(puanlar[i]));
            tr.appendChild(td1);
            tr.appendChild(td2);
            table.appendChild(tr);
        }

        document.getElementById("Puanlar").innerHTML = "";
        document.getElementById("Puanlar").appendChild(table);

    }

    function Dogrula(puan) {
        if (puan.toString().length == 3) puan = puan + '.';
        if (puan.toString().length > 8) return puan.toString().substring(0, 7);
        else if (puan.toString().length < 10) {
            puan = puan.toString();
            var eksik = 7 - puan.toString().length;
            for (var i = 0; i < eksik; i++) {
                puan = puan + '0';
            }
            return puan;
        }
        else return puan.toString();
    }

}


)();
