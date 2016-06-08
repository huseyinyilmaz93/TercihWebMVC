"use strict";
(function () {
window.onload = function () {
    document.getElementById("btn_temizle").onclick = Temizle;
    document.getElementById("btn_hesapla").onclick = Hesapla;
    document.getElementById("txt_okulPuani").onchange = OkulPuaniChanged;

    document.getElementById("txt_turkceDogru").onchange = TurkceChanged;
    document.getElementById("txt_turkceYanlis").onchange = TurkceChanged;
    document.getElementById("txt_turkceNet").onchange = TurkceNet;

    document.getElementById("txt_matematikDogru").onchange = MatematikChanged;
    document.getElementById("txt_matematikYanlis").onchange = MatematikChanged;
    document.getElementById("txt_matematikNet").onchange = MatematikNet;

    document.getElementById("txt_sosyalDogru").onchange = SosyalChanged;
    document.getElementById("txt_sosyalYanlis").onchange = SosyalChanged;
    document.getElementById("txt_sosyalNet").onchange = SosyalNet;

    document.getElementById("txt_fenDogru").onchange = FenChanged;
    document.getElementById("txt_fenYanlis").onchange = FenChanged;
    document.getElementById("txt_fenNet").onchange = FenNet;


    document.getElementById("txt_mat2Dogru").onchange = Mat2Changed;
    document.getElementById("txt_mat2Yanlis").onchange = Mat2Changed;
    document.getElementById("txt_mat2Net").onchange = Mat2Net;

    document.getElementById("txt_geometriDogru").onchange = GeometriChanged;
    document.getElementById("txt_geometriYanlis").onchange = GeometriChanged;
    document.getElementById("txt_geometriNet").onchange = GeometriNet;

    document.getElementById("txt_fizikDogru").onchange = FizikChanged;
    document.getElementById("txt_fizikYanlis").onchange = FizikChanged;
    document.getElementById("txt_fizikNet").onchange = FizikNet;

    document.getElementById("txt_kimyaDogru").onchange = KimyaChanged;
    document.getElementById("txt_kimyaYanlis").onchange = KimyaChanged;
    document.getElementById("txt_kimyaNet").onchange = KimyaNet;

    document.getElementById("txt_biyolojiDogru").onchange = BiyolojiChanged;
    document.getElementById("txt_biyolojiYanlis").onchange = BiyolojiChanged;
    document.getElementById("txt_biyolojiNet").onchange = BiyolojiNet;

    document.getElementById("txt_edebiyatDogru").onchange = EdebiyatChanged;
    document.getElementById("txt_edebiyatYanlis").onchange = EdebiyatChanged;
    document.getElementById("txt_edebiyatNet").onchange = EdebiyatNet;

    document.getElementById("txt_cografya1Dogru").onchange = Cografya1Changed;
    document.getElementById("txt_cografya1Yanlis").onchange = Cografya1Changed;
    document.getElementById("txt_cografya1Net").onchange = Cografya1Net;

    document.getElementById("txt_tarihDogru").onchange = TarihChanged;
    document.getElementById("txt_tarihYanlis").onchange = TarihChanged;
    document.getElementById("txt_tarihNet").onchange = TarihNet;

    document.getElementById("txt_cografya2Dogru").onchange = Cografya2Changed;
    document.getElementById("txt_cografya2Yanlis").onchange = Cografya2Changed;
    document.getElementById("txt_cografya2Net").onchange = Cografya2Net;

    document.getElementById("txt_felsefeDogru").onchange = FelsefeChanged;
    document.getElementById("txt_felsefeYanlis").onchange = FelsefeChanged;
    document.getElementById("txt_felsefeNet").onchange = FelsefeNet;

    document.getElementById("txt_dilDogru").onchange = DilChanged;
    document.getElementById("txt_dilYanlis").onchange = DilChanged;
    document.getElementById("txt_dilNet").onchange = DilNet;




}

function OkulPuaniChanged() {
    var deger = document.getElementById("txt_okulPuani").value;
    if (deger >= 500) document.getElementById("txt_okulPuani").value = 500;
    else if (deger <= 250) document.getElementById("txt_okulPuani").value = 250;
    else document.getElementById("txt_okulPuani").value = deger;
}

function Kontrol(deger, soruSayisi) {

    //var pattern = "/^\d{1-2}$/";
    //if(pattern.match(deger)) {
    if (deger >= soruSayisi) return soruSayisi;
    else if (deger <= 0) return 0;
    else if (deger == "") return 0;
    else return deger;
    //}
    //else return 0;
}

function TurkceChanged() {
    var dogru = Kontrol(document.getElementById("txt_turkceDogru").value, 40);
    document.getElementById("txt_turkceDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_turkceYanlis").value, 40);
    document.getElementById("txt_turkceYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 40) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_turkceDogru").value = "";
        document.getElementById("txt_turkceYanlis").value = "";
        document.getElementById("txt_turkceNet").value = "";
    }
    else document.getElementById("txt_turkceNet").value = dogru - (0.25) * yanlis;
}

function TurkceNet() {
    var sorusayisi = 40;
    var net = document.getElementById("txt_turkceNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_turkceNet").value = temp;
}

function MatematikChanged() {
    var dogru = Kontrol(document.getElementById("txt_matematikDogru").value, 40);
    document.getElementById("txt_matematikDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_matematikYanlis").value, 40);
    document.getElementById("txt_matematikYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 40) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_matematikDogru").value = "";
        document.getElementById("txt_matematikYanlis").value = "";
        document.getElementById("txt_matematikNet").value = "";
    }
    else document.getElementById("txt_matematikNet").value = dogru - (0.25) * yanlis;
}

function MatematikNet() {
    var sarusayisi = 40;
    var net = document.getElementById("txt_matematikNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_matematikNet").value = temp;
}


function FenChanged() {
    var dogru = Kontrol(document.getElementById("txt_fenDogru").value, 40);
    document.getElementById("txt_fenDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_fenYanlis").value, 40);
    document.getElementById("txt_fenYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 40) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_fenDogru").value = "";
        document.getElementById("txt_fenYanlis").value = "";
        document.getElementById("txt_fenNet").value = "";
    }
    else document.getElementById("txt_fenNet").value = dogru - (0.25) * yanlis;
}

function FenNet() {
    var sorusayisi = 40;
    var net = document.getElementById("txt_fenNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_fenNet").value = temp;
}


function SosyalChanged() {
    var dogru = Kontrol(document.getElementById("txt_sosyalDogru").value, 40);
    document.getElementById("txt_sosyalDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_sosyalYanlis").value, 40);
    document.getElementById("txt_sosyalYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 40) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_sosyalDogru").value = "";
        document.getElementById("txt_sosyalYanlis").value = "";
        document.getElementById("txt_sosyalNet").value = "";
    }
    else document.getElementById("txt_sosyalNet").value = dogru - (0.25) * yanlis;
}

function SosyalNet() {
    var sorusayisi = 40;
    var net = document.getElementById("txt_sosyalNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_sosyalNet").value = temp;
}

function Mat2Changed() {
    var dogru = Kontrol(document.getElementById("txt_mat2Dogru").value, 50);
    document.getElementById("txt_mat2Dogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_mat2Yanlis").value, 50);
    document.getElementById("txt_mat2Yanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 50) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_mat2Dogru").value = "";
        document.getElementById("txt_mat2Yanlis").value = "";
        document.getElementById("txt_mat2Net").value = "";
    }
    else document.getElementById("txt_mat2Net").value = dogru - (0.25) * yanlis;
}

function Mat2Net() {
    var soruSayisi = 50;
    var net = document.getElementById("txt_mat2Net").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_mat2Net").value = temp;
}


function GeometriChanged() {
    var dogru = Kontrol(document.getElementById("txt_geometriDogru").value, 30);
    document.getElementById("txt_geometriDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_geometriYanlis").value, 30);
    document.getElementById("txt_geometriYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 30) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_geometriDogru").value = "";
        document.getElementById("txt_geometriYanlis").value = "";
        document.getElementById("txt_geometriNet").value = "";
    }
    else document.getElementById("txt_geometriNet").value = dogru - (0.25) * yanlis;
}

function GeometriNet() {
    var soruSayisi = 30;
    var net = document.getElementById("txt_geometriNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_geometriNet").value = temp;
}

function FizikChanged() {
    var dogru = Kontrol(document.getElementById("txt_fizikDogru").value, 30);
    document.getElementById("txt_fizikDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_fizikYanlis").value, 30);
    document.getElementById("txt_fizikYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 30) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_fizikDogru").value = "";
        document.getElementById("txt_fizikYanlis").value = "";
        document.getElementById("txt_fizikNet").value = "";
    }
    else document.getElementById("txt_fizikNet").value = dogru - (0.25) * yanlis;
}

function FizikNet() {
    var soruSayisi = 30;
    var net = document.getElementById("txt_fizikNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_fizikNet").value = temp;
}

function KimyaChanged() {
    var dogru = Kontrol(document.getElementById("txt_kimyaDogru").value, 30);
    document.getElementById("txt_kimyaDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_kimyaYanlis").value, 30);
    document.getElementById("txt_kimyaYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 30) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_kimyaDogru").value = "";
        document.getElementById("txt_kimyaYanlis").value = "";
        document.getElementById("txt_kimyaNet").value = "";
    }
    else document.getElementById("txt_kimyaNet").value = dogru - (0.25) * yanlis;
}

function KimyaNet() {
    var soruSayisi = 30;
    var net = document.getElementById("txt_kimyaNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_kimyaNet").value = temp;
}

function BiyolojiChanged() {
    var dogru = Kontrol(document.getElementById("txt_biyolojiDogru").value, 30);
    document.getElementById("txt_biyolojiDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_biyolojiYanlis").value, 30);
    document.getElementById("txt_biyolojiYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 30) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_biyolojiDogru").value = "";
        document.getElementById("txt_biyolojiYanlis").value = "";
        document.getElementById("txt_biyolojiNet").value = "";
    }
    else document.getElementById("txt_biyolojiNet").value = dogru - (0.25) * yanlis;
}

function BiyolojiNet() {
    var soruSayisi = 30;
    var net = document.getElementById("txt_biyolojiNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_biyolojiNet").value = temp;
}

function FelsefeChanged() {
    var dogru = Kontrol(document.getElementById("txt_felsefeDogru").value, 30);
    document.getElementById("txt_felsefeDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_felsefeYanlis").value, 30);
    document.getElementById("txt_felsefeYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 30) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_felsefeDogru").value = "";
        document.getElementById("txt_felsefeYanlis").value = "";
        document.getElementById("txt_felsefeNet").value = "";
    }
    else document.getElementById("txt_felsefeNet").value = dogru - (0.25) * yanlis;
}

function FelsefeNet() {
    var soruSayisi = 30;
    var net = document.getElementById("txt_felsefeNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_felsefeNet").value = temp;
}

function DilChanged() {
    var dogru = Kontrol(document.getElementById("txt_dilDogru").value, 80);
    document.getElementById("txt_dilDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_dilYanlis").value, 80);
    document.getElementById("txt_dilYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 80) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_dilDogru").value = "";
        document.getElementById("txt_dilYanlis").value = "";
        document.getElementById("txt_dilNet").value = "";
    }
    else document.getElementById("txt_dilNet").value = dogru - (0.25) * yanlis;
}

function DilNet() {
    var soruSayisi = 80;
    var net = document.getElementById("txt_dilNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_dilNet").value = temp;
}

function Cografya1Changed() {
    var dogru = Kontrol(document.getElementById("txt_cografya1Dogru").value, 24);
    document.getElementById("txt_cografya1Dogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_cografya1Yanlis").value, 24);
    document.getElementById("txt_cografya1Yanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 24) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_cografya1Dogru").value = "";
        document.getElementById("txt_cografya1Yanlis").value = "";
        document.getElementById("txt_cografya1Net").value = "";
    }
    else document.getElementById("txt_cografya1Net").value = dogru - (0.25) * yanlis;
}

function Cografya1Net() {
    var soruSayisi = 24;
    var net = document.getElementById("txt_cografya1Net").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_cografya1Net").value = temp;
}

function TarihChanged() {
    var dogru = Kontrol(document.getElementById("txt_tarihDogru").value, 44);
    document.getElementById("txt_tarihDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_tarihYanlis").value, 44);
    document.getElementById("txt_tarihYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 44) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_tarihDogru").value = "";
        document.getElementById("txt_tarihYanlis").value = "";
        document.getElementById("txt_tarihNet").value = "";
    }
    else document.getElementById("txt_tarihNet").value = dogru - (0.25) * yanlis;
}

function TarihNet() {
    var soruSayisi = 44;
    var net = document.getElementById("txt_tarihNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_tarihNet").value = temp;
}

function EdebiyatChanged() {
    var dogru = Kontrol(document.getElementById("txt_edebiyatDogru").value, 56);
    document.getElementById("txt_edebiyatDogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_edebiyatYanlis").value, 56);
    document.getElementById("txt_edebiyatYanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 56) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_edebiyatDogru").value = "";
        document.getElementById("txt_edebiyatYanlis").value = "";
        document.getElementById("txt_edebiyatNet").value = "";
    }
    else document.getElementById("txt_edebiyatNet").value = dogru - (0.25) * yanlis;
}

function EdebiyatNet() {
    var soruSayisi = 56;
    var net = document.getElementById("txt_edebiyatNet").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_edebiyatNet").value = temp;
}

function Cografya2Changed() {
    var dogru = Kontrol(document.getElementById("txt_cografya2Dogru").value, 16);
    document.getElementById("txt_cografya2Dogru").value = dogru;
    var yanlis = Kontrol(document.getElementById("txt_cografya2Yanlis").value, 16);
    document.getElementById("txt_cografya2Yanlis").value = yanlis;
    var toplamSoru = parseInt(dogru) + parseInt(yanlis);

    if (toplamSoru > 16) {
        alert("Doğru ve yanlış soru sayısı toplamı, toplam soru sayısından fazla olamaz!");
        document.getElementById("txt_cografya2Dogru").value = "";
        document.getElementById("txt_cografya2Yanlis").value = "";
        document.getElementById("txt_cografya2Net").value = "";
    }
    else document.getElementById("txt_cografya2Net").value = dogru - (0.25) * yanlis;
}

function Cografya2Net() {
    var soruSayisi = 16;
    var net = document.getElementById("txt_cografya2Net").value
    var temp;
    if (net > soruSayisi) temp = soruSayisi;
    else if (net < 0) temp = 0;
    else temp = net;
    document.getElementById("txt_cografya2Net").value = temp;
}


function Temizle() {
    document.getElementById("txt_okulPuani").value = "";
    document.getElementById("txt_turkceDogru").value = "";
    document.getElementById("txt_turkceYanlis").value = "";
    document.getElementById("txt_turkceNet").value = "";
    document.getElementById("txt_matematikDogru").value = "";
    document.getElementById("txt_matematikYanlis").value = "";
    document.getElementById("txt_matematikNet").value = "";
    document.getElementById("txt_fenDogru").value = "";
    document.getElementById("txt_fenYanlis").value = "";
    document.getElementById("txt_fenNet").value = "";
    document.getElementById("txt_sosyalDogru").value = "";
    document.getElementById("txt_sosyalYanlis").value = "";
    document.getElementById("txt_sosyalNet").value = "";
    document.getElementById("txt_mat2Dogru").value = "";
    document.getElementById("txt_mat2Yanlis").value = "";
    document.getElementById("txt_mat2Net").value = "";
    document.getElementById("txt_geometriDogru").value = "";
    document.getElementById("txt_geometriYanlis").value = "";
    document.getElementById("txt_geometriNet").value = "";
    document.getElementById("txt_fizikDogru").value = "";
    document.getElementById("txt_fizikYanlis").value = "";
    document.getElementById("txt_fizikNet").value = "";
    document.getElementById("txt_kimyaDogru").value = "";
    document.getElementById("txt_kimyaYanlis").value = "";
    document.getElementById("txt_kimyaNet").value = "";
    document.getElementById("txt_biyolojiDogru").value = "";
    document.getElementById("txt_biyolojiYanlis").value = "";
    document.getElementById("txt_biyolojiNet").value = "";
    document.getElementById("txt_felsefeDogru").value = "";
    document.getElementById("txt_felsefeYanlis").value = "";
    document.getElementById("txt_felsefeNet").value = "";
    document.getElementById("txt_dilDogru").value = "";
    document.getElementById("txt_dilYanlis").value = "";
    document.getElementById("txt_dilNet").value = "";
    document.getElementById("txt_cografya1Dogru").value = "";
    document.getElementById("txt_cografya1Yanlis").value = "";
    document.getElementById("txt_cografya1Net").value = "";
    document.getElementById("txt_tarihDogru").value = "";
    document.getElementById("txt_tarihYanlis").value = "";
    document.getElementById("txt_tarihNet").value = "";
    document.getElementById("txt_edebiyatDogru").value = "";
    document.getElementById("txt_edebiyatYanlis").value = "";
    document.getElementById("txt_edebiyatNet").value = "";
    document.getElementById("txt_cografya2Dogru").value = "";
    document.getElementById("txt_cografya2Yanlis").value = "";
    document.getElementById("txt_cografya2Net").value = "";

    document.getElementById("Puanlar").innerHTML = "";
}

function Hesapla() {

    var ekPuan = (document.getElementById("txt_okulPuani").value == "") ? 0 : document.getElementById("txt_okulPuani").value;
    ekPuan = (parseFloat(ekPuan) * 0.12).toString();
    var turkceNet = (document.getElementById("txt_turkceNet").value) == "" ? 0 : document.getElementById("txt_turkceNet").value;
    var matematikNet = (document.getElementById("txt_matematikNet").value) == "" ? 0 : document.getElementById("txt_matematikNet").value;
    var sosyalNet = (document.getElementById("txt_sosyalNet").value) == "" ? 0 : document.getElementById("txt_sosyalNet").value;
    var fenNet = (document.getElementById("txt_fenNet").value) == "" ? 0 : document.getElementById("txt_fenNet").value;

    var mat2Net = (document.getElementById("txt_mat2Net").value) == "" ? 0 : document.getElementById("txt_mat2Net").value;
    var geometriNet = (document.getElementById("txt_geometriNet").value) == "" ? 0 : document.getElementById("txt_geometriNet").value;
    var fizikNet = (document.getElementById("txt_fizikNet").value) == "" ? 0 : document.getElementById("txt_fizikNet").value;
    var kimyaNet = (document.getElementById("txt_kimyaNet").value) == "" ? 0 : document.getElementById("txt_kimyaNet").value;
    var biyolojiNet = (document.getElementById("txt_biyolojiNet").value) == "" ? 0 : document.getElementById("txt_biyolojiNet").value;
    var edebiyatNet = (document.getElementById("txt_edebiyatNet").value) == "" ? 0 : document.getElementById("txt_edebiyatNet").value;
    var cografya1Net = (document.getElementById("txt_cografya1Net").value) == "" ? 0 : document.getElementById("txt_cografya1Net").value;
    var tarihNet = (document.getElementById("txt_tarihNet").value) == "" ? 0 : document.getElementById("txt_tarihNet").value;
    var cografya2Net = (document.getElementById("txt_cografya2Net").value) == "" ? 0 : document.getElementById("txt_cografya2Net").value;
    var felsefeNet = (document.getElementById("txt_felsefeNet").value) == "" ? 0 : document.getElementById("txt_felsefeNet").value;
    var dilNet = (document.getElementById("txt_dilNet").value) == "" ? 0 : document.getElementById("txt_dilNet").value;

    var ygs1Taban = 98.416; var ygs2Taban = 98.430; var ygs3Taban = 96.367; var ygs4Taban = 96.344; var ygs5Taban = 97.010; var ygs6Taban = 97.764;
    var mf1Taban = 100.110; var mf2Taban = 100.210; var mf3Taban = 100.110; var mf4Taban = 100.170;
    var tmTaban = 100.000; //t1Taban=tm2Taban=tm3Taban
    var ts1Taban = 119.600; var ts2Taban = 115.000;
    var dilTaban = 100.000; //dil1Taban=dil2Taban_dil3Taban

    var ygs1 = (1.995 * turkceNet + 1.173 * sosyalNet + 3.773 * matematikNet + 3.099 * fenNet) + ygs1Taban;
    var ygs2 = (1.977 * turkceNet + 1.162 * sosyalNet + 2.804 * matematikNet + 4.095 * fenNet) + ygs2Taban;
    var ygs3 = (3.861 * turkceNet + 3.404 * sosyalNet + 1.826 * matematikNet + 1.000 * fenNet) + ygs3Taban;
    var ygs4 = (2.848 * turkceNet + 4.465 * sosyalNet + 1.796 * matematikNet + 0.983 * fenNet) + ygs4Taban;
    var ygs5 = (3.660 * turkceNet + 2.321 * sosyalNet + 3.072 * matematikNet + 1.022 * fenNet) + ygs5Taban;
    var ygs6 = (3.295 * turkceNet + 1.177 * sosyalNet + 3.510 * matematikNet + 2.074 * fenNet) + ygs6Taban;


    var mf1 = (1.122 * turkceNet + 1.632 * matematikNet + 0.510 * sosyalNet + 0.816 * fenNet + 2.653 * mat2Net + 1.326 * geometriNet + 1.020 * fizikNet + 0.612 * kimyaNet + 0.510 * biyolojiNet) + mf1Taban;
    var mf2 = (1.182 * turkceNet + 1.182 * matematikNet + 0.537 * sosyalNet + 1.397 * fenNet + 1.720 * mat2Net + 0.752 * geometriNet + 1.197 * fizikNet + 1.290 * kimyaNet + 1.290 * biyolojiNet) + mf2Taban;
    var mf3 = (1.202 * turkceNet + 1.202 * matematikNet + 0.765 * sosyalNet + 1.202 * fenNet + 1.420 * mat2Net + 0.546 * geometriNet + 1.420 * fizikNet + 1.530 * kimyaNet + 1.639 * biyolojiNet) + mf3Taban;
    var mf4 = (1.145 * turkceNet + 1.458 * matematikNet + 0.625 * sosyalNet + 0.937 * fenNet + 2.291 * mat2Net + 1.145 * geometriNet + 1.354 * fizikNet + 0.937 * kimyaNet + 0.520 * biyolojiNet) + mf4Taban;

    var tm1 = (1.294 * turkceNet + 1.479 * matematikNet + 0.462 * sosyalNet + 0.462 * fenNet + 2.312 * mat2Net + 0.925 * geometriNet + 1.664 * edebiyatNet + 0.647 * cografya1Net) + tmTaban;
    var tm2 = (1.283 * turkceNet + 1.283 * matematikNet + 0.642 * sosyalNet + 0.458 * fenNet + 2.016 * mat2Net + 0.733 * geometriNet + 1.016 * edebiyatNet + 0.733 * cografya1Net) + tmTaban;
    var tm3 = (1.379 * turkceNet + 0.920 * matematikNet + 0.920 * sosyalNet + 0.460 * fenNet + 1.655 * mat2Net + 0.644 * geometriNet + 2.229 * edebiyatNet + 0.920 * cografya1Net) + tmTaban;

    var ts1 = (1.283 * turkceNet + 0.987 * matematikNet + 1.184 * sosyalNet + 0.494 * fenNet + 1.481 * edebiyatNet + 0.790 * cografya1Net + 1.481 * tarihNet + 0.691 * cografya2Net + 1.481 * felsefeNet) + ts1Taban;
    var ts2 = (1.666 * turkceNet + 0.555 * matematikNet + 1.018 * sosyalNet + 0.463 * fenNet + 2.314 * edebiyatNet + 0.463 * cografya1Net + 1.388 * tarihNet + 0.463 * cografya2Net + 0.925 * felsefeNet) + ts2Taban;

    var dil1 = (1.500 * turkceNet + 0.600 * matematikNet + 0.900 * sosyalNet + 0.500 * fenNet + 3.250 * dilNet) + dilTaban;
    var dil2 = (2.500 * turkceNet + 0.700 * matematikNet + 1.300 * sosyalNet + 0.500 * fenNet + 2.500 * dilNet) + dilTaban;
    var dil3 = (4.800 * turkceNet + 0.700 * matematikNet + 2.000 * sosyalNet + 0.500 * fenNet + 1.000 * dilNet) + dilTaban;



    var table = document.createElement("table");
    table.setAttribute('text-align', 'center');
    var tbody = document.createElement("tbody");
    tbody.setAttribute('text-align', 'left');
    var tr = document.createElement("tr");

    var td1 = document.createElement("th");

    td1.appendChild(document.createTextNode("Puan Türü"));
    tr.appendChild(td1);
    var td2 = document.createElement("th");

    td2.appendChild(document.createTextNode("Ham Puan"));
    tr.appendChild(td2);
    var td3 = document.createElement("th");

    td3.appendChild(document.createTextNode("Yerleştirme Puanı"));
    tr.appendChild(td3);
    tbody.appendChild(tr);
    table.appendChild(tbody);

    var puanTuru = ["YGS-1", "YGS-2", "YGS-3", "YGS-4", "YGS-5", "YGS-6", "MF-1", "MF-2", "MF-3", "MF-4", "TM-1", "TM-2", "TM-3", "TS-1", "TS-2", "DİL-1", "DİL-2", "DİL-3"];
    var hamPuanlar = [ygs1, ygs2, ygs3, ygs4, ygs5, ygs6, mf1, mf2, mf3, mf4, tm1, tm2, tm3, ts1, ts2, dil1, dil2, dil3];
    var yerlestirmePuanlar = new Array(hamPuanlar.length);

    for (var i = 0; i < yerlestirmePuanlar.length; i++) {
        yerlestirmePuanlar[i] = (parseFloat(hamPuanlar[i]) + parseFloat(ekPuan)).toString();
    }

    for (var i = 0; i < puanTuru.length; i++) {
        hamPuanlar[i] = Dogrula(hamPuanlar[i]);
        yerlestirmePuanlar[i] = Dogrula(yerlestirmePuanlar[i]);
        var tr = document.createElement("tr");
        var td1 = document.createElement("td");
        td1.className = 'tablePuan';
        td1.appendChild(document.createTextNode(puanTuru[i]));
        td1.style.fontWeight = "bold";
        var td2 = document.createElement("td");
        td2.className = 'tablePuan';

        td2.setAttribute('text-align', 'center');
        td2.appendChild(document.createTextNode(hamPuanlar[i]));
        var td3 = document.createElement("td");
        td3.className = 'tablePuan';
        td3.setAttribute('text-align', 'center');
        td3.appendChild(document.createTextNode(yerlestirmePuanlar[i]));
        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        table.appendChild(tr);
    }

    document.getElementById("Puanlar").innerHTML = "";
    document.getElementById("Puanlar").appendChild(table);
    if (document.getElementById("txt_okulPuani").value == "") alert("Okul puanı alanını boş bıraktınız. Daha doğru bir sonuç için lütfen değer girin!")
}
function Dogrula(puan) {
    if (puan < 180) return "---";
    if (puan.toString().length == 3) puan = puan + '.';
    if (puan.toString().length > 10) return puan.toString().substring(0, 9);
    else if (puan.toString().length < 10) {
        puan = puan.toString();
        var eksik = 9 - puan.toString().length;
        for (var i = 0; i < eksik; i++) {
            puan = puan + '0';
        }
        return puan;
    }
    else return puan.toString();
}

}

)();