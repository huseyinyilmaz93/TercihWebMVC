"use strict";
(function () {
    var uniNo = 0;
    var fakNo = 0;
    var bolKodu = "";
    var KayitSayisi = 15;
    var TopKayit = 0;
    var SayfaSayisi = 1;
    window.onload = function () {
        document.getElementById("aramaKelime").onchange = function () {
            SayfaSayisi = 1;
            fnc_IstekYap();
        };
        document.getElementById("enYuksek").onchange = function () {
            SayfaSayisi = 1;
            fnc_IstekYap();
        };
        document.getElementById("enDusuk").onchange = function () {
            SayfaSayisi = 1;
            fnc_IstekYap();
        };
        document.getElementById("kayitSayisi").onchange = function () {
            SayfaSayisi = 1;
            fnc_IstekYap();
        };
        $.ajax({
            type: "GET",
            url: "/API/UniversitePuan/TumUniversiteler",
            contentType: "application/json",
            success: function (data) {
                var i = 0;
                var uniDropDown = document.getElementById("universiteler");
                var seciniz = document.createElement("option");
                seciniz.value = 0;
                seciniz.appendChild(document.createTextNode("---SEÇİNİZ---"));
                uniDropDown.appendChild(seciniz);
                for (i; i < data.length; i++) {
                    var option = document.createElement("option");
                    option.appendChild(document.createTextNode(data[i].UniversiteAdi));
                    option.value = data[i].UniversiteNo;
                    uniDropDown.appendChild(option);
                    
                }
                SayfaSayisi = 1;
                fnc_IstekYap();
                uniDropDown.addEventListener("change", fnc_FakulteGetir);
            }
        });
    }
    function fnc_FakulteGetir() {
        if (this.value == 0) return;
        uniNo = this.value;
        fakNo = 0;
        bolKodu = "";
        $.ajax({
            type: "GET",
            url: "/API/UniversitePuan/Fakulteler/" + uniNo,
            contentType: "application/json",
            success: function (data) {
                var i = 0;
                var fakulteDropDown = document.createElement("select");
                fakulteDropDown.id = "fakulteler";
                var seciniz = document.createElement("option");
                seciniz.value = 0;
                seciniz.appendChild(document.createTextNode("---SEÇİNİZ---"));
                fakulteDropDown.appendChild(seciniz);
                for (i; i < data.length; i++) {
                    var option = document.createElement("option");
                    option.appendChild(document.createTextNode(data[i].FakulteAdi));
                    option.value = data[i].FakulteNo;
                    fakulteDropDown.appendChild(option);
                }
                fakulteDropDown.addEventListener("change", fnc_BolumGetir);
                var divFak = document.getElementById("divFak");
                divFak.innerHTML = "";
                var label = document.createElement("label");
                label.appendChild(document.createTextNode("Fakülteler : "));
                divFak.appendChild(label);
                divFak.appendChild(fakulteDropDown);
                SayfaSayisi = 1;
                fnc_IstekYap();
            }
        });
    }
    function fnc_BolumGetir() {
        if (this.value == 0) return;
        fakNo = this.value;
        bolKodu = "";
        $.ajax({
            type: "GET",
            url: "/API/UniversitePuan/Bolumler/" + uniNo + "/" + fakNo,
            contentType: "application/json",
            success: function (data) {
                var i = 0;
                var bolumlerDropDown = document.createElement("select");
                bolumlerDropDown.id = "bolumler";
                var seciniz = document.createElement("option");
                seciniz.value = 0;
                seciniz.appendChild(document.createTextNode("---SEÇİNİZ---"));
                bolumlerDropDown.appendChild(seciniz);
                for (i; i < data.length; i++) {
                    var option = document.createElement("option");
                    option.appendChild(document.createTextNode(data[i].BolumAdi));
                    option.value = data[i].BolumKodu;
                    bolumlerDropDown.appendChild(option);
                }
                var divBol = document.getElementById("divBol");
                bolumlerDropDown.addEventListener("change", function () {
                    bolKodu = this.value;
                    SayfaSayisi = 1;
                    fnc_IstekYap();
                });
                divBol.innerHTML = "";
                var label = document.createElement("label");
                label.appendChild(document.createTextNode("Bölümler : "));
                divBol.appendChild(label);
                divBol.appendChild(bolumlerDropDown);
                SayfaSayisi = 1;
                fnc_IstekYap();
            }
        });

    }
    function fnc_KayitSayisi() {
        KayitSayisi = parseInt(this.value);
        fnc_IstekYap();
    }

    function fnc_IstekYap() {
        var AramaKelime = document.getElementById("aramaKelime").value;
        var EnDusukPuan = (document.getElementById("enDusuk").value == "") ? 0.0 : document.getElementById("enDusuk").value;
        var EnYuksekPuan = (document.getElementById("enYuksek").value == "") ? 0.0 : document.getElementById("enYuksek").value;
        var reg = new RegExp("^[0-9]*$");
        if ((!reg.test(EnYuksekPuan)) || (!reg.test(EnDusukPuan))) {
            alert("EnYüksek veya EnDüşük puan alanları sadece sayısal karakterler içerebilir.");
            return;
        }

            var model = {
                UniversiteNo: uniNo, FakulteNo: fakNo, BolumKodu: bolKodu, AramaKelime: AramaKelime,
                EnDusukPuan: EnDusukPuan, EnYuksekPuan: EnYuksekPuan,
                SayfaSayisi: SayfaSayisi, KayitSayisi: KayitSayisi
            }

            $.ajax({
                type: "POST",
                url: "/API/UniversitePuan/BolumFiltrele",
                contentType: "application/json",
                data: JSON.stringify(model),
                success: function (data) {
                    var kayitlar = document.getElementById("kayitlar");
                    kayitlar.innerHTML = "";
                    TopKayit = data[data.length-1].EnYuksekPuan;
                    var i = 0;
                    for (i; i < data.length - 1; i++) {
                        var tr = document.createElement("tr");

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

                        kayitlar.appendChild(tr);
                    }
                    var tr = document.createElement("tr");
                    var td = document.createElement("td");
                    td.colSpan = 10;
                    var label = document.createElement("label");
                    label.appendChild(document.createTextNode(" / " + (parseInt(TopKayit / KayitSayisi) + 1)));
                    var input = document.createElement("input");
                    input.type = "text";
                    input.id = "txt_SayfaSayisi";
                    input.size = 6;
                    input.value = SayfaSayisi;
                    input.addEventListener("change", function () {
                        var reg = new RegExp("^[0-9]*$");
                        if ((!reg.test(EnYuksekPuan)) || (!reg.test(EnDusukPuan))) {
                            alert("Sayısal karakterlerin dışında değer girilemez!");
                            return;
                        }

                        SayfaSayisi = document.getElementById("txt_SayfaSayisi").value;
                        fnc_IstekYap();

                    });
                    tr.appendChild(td);
                    td.appendChild(input);
                    td.appendChild(label);
                    tr.classList.add("textCenter");
                    kayitlar.appendChild(tr);

                }

            });
    }

        //public int UniversiteNo { get; set; } // 0 if empty
        //    public int FakulteNo { get; set; } // 0 if empty
        //    public string BolumKodu { get; set; } // "" if null
        //    public string AramaKelime { get; set; } //isim ile arama yapılırsa kullanılacak.
        //    public double EnDusukPuan { get; set; } //0.0 if empty
        //    public double EnYuksekPuan { get; set; } //0.0 if empty
        //    public int SayfaSayisi { get; set; } // default 1 if empty
        //    public int KayitSayisi { get; set; } //default 15 if empty
    }

)();