"use strict";
(function () {
    window.onload = function () {
        document.getElementById("mailGonder").onclick = fnc_mailGonder;
    }

    function fnc_mailGonder() {
        var id = document.getElementById("id").value;
        $.ajax({
            type: "GET",
            url: "/API/Hesap/KayitOnaylama/" + id,
            contentType: "application/json",
            success: function () {
                alert("Mail tekrar gönderildi. Lütfen eposta adresinizi kontrol edin.");
            },
            error: function (data) {
                alert("Mail gönderilemedi lütfen tekrar göndermeyi deneyiniz.");
            }
        });
    }

}
)();
