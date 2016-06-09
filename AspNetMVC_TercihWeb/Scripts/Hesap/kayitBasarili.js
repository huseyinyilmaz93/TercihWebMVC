"use strict";
(function () {
    window.onload = function () {
        var id = document.getElementById("kId").value;
        console.log(id);
        $.ajax({
            type: "GET",
            url: "/API/Hesap/KayitBasarili/" + id,
            contentType: "application/json",
            success: function () {
                document.getElementById("sonuc").innerText = "Email adresi onaylandı!";
            },
            error: function () {
                document.getElementById("sonuc").innerText = "Hata oluştu lütfen tekrar deneyin!";
            }
        });

    }
}
)();
