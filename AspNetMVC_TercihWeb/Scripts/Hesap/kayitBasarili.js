"use strict";
(function () {
    window.onload = function () {
        var id = document.getElementById("id").value;
        console.log("123");
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

        console.log("aaaaaaa");
    }
}
)();
