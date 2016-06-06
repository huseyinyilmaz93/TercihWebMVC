"use strict";
(function () {
    window.onload = function () {
        var flag = true;
        var id = document.getElementById("id").value;
        $.ajax({
            type: "GET",
            url: "/API/Hesap/SifremiUnuttumSure/" + id,
            contentType: "application/json",
            async:false,
            success: function (data) {
                flag = false;
            },
            error: function () { }
        });
        if (flag == true) {
            document.getElementById("form").innerHTML = "<label style='color:red'>İstek zaman aşımına uğradı. Tekrar Deneyin ..</label>";
        } else {
            document.getElementById("btn_sifremiUnuttumOnay").onclick = fnc_sifremiUnuttumOnay;
        }
    }

    function fnc_sifremiUnuttumOnay() {
        var id = document.getElementById("id").value;
        var YeniSifre = document.getElementById("YeniSifre").value;
        var YeniSifreTekrar = document.getElementById("YeniSifreTekrar").value;
        var model = {
            YeniSifre:YeniSifre,YeniSifreTekrar:YeniSifreTekrar
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(model),
            url: "/API/Hesap/SifremiUnuttumOnay/" + id,
            contentType: "application/json",
            success: function (data) {
                alert('Şifre başarıyla değiştirildi.');
            },
            error: function (data) {
                var status = data.status;
                if (status == 0) alert("Şifre başarıyla değiştirildi.");
                else alert(' Bir hata oluştu tekrar deneyiniz.');
            }
        });

        window.location.replace("/Site/Index");
    }
})();