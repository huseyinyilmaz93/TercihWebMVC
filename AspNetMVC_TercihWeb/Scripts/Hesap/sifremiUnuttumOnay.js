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
            error: function (data) {
                
            }
        });
        if (flag == true) {
            document.getElementById("form").innerHTML = "";
            var label = document.createElement("label");
            label.appendChild(document.createTextNode("İstek zaman aşımına uğradı. Tekrar Deneyin .."));
            document.getElementById("form").appendChild(label);
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
                window.location.replace("/Site/Index");
            },
            error: function (data) {

                var status = data.status;
                if (status == 0) {
                    alert("Şifre başarıyla değiştirildi.");
                    window.location.replace("/Site/Index");
                }
                var status = data.status;
                var d = JSON.parse(data.responseText);
                var hata = document.getElementById("hata");
                hata.innerHTML = "";
                if (status == 405) {
                    var ul = document.createElement("ul");
                    var li = document.createElement("li");
                    li.appendChild(document.createTextNode(d.ModelState.Hata[0]));
                    ul.appendChild(li);
                    hata.appendChild(ul);
                } else if (status == 400) {
                    var arr = [];
                    for (var x in d.ModelState) {
                        arr.push(d.ModelState[x]);
                    } //OBJECT TO ARRAY

                    var ul = document.createElement("ul");
                    for (var x in arr) {
                        var li = document.createElement("li");
                        li.appendChild(document.createTextNode(arr[x][0]));
                        ul.appendChild(li);
                    }
                    hata.appendChild(ul);
                }
            }
        });

    }
})();