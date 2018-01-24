
function makeAJAXCall(methodType, url, params, successcallback, personSendingFailure, contentType) {

    console.log("Ajax call in progress... ");

    var request = new XMLHttpRequest();
    request.open(methodType, url, true);

    request.onreadystatechange = function () {
        console.log("State: " + request.readyState);
        if (request.readyState == XMLHttpRequest.DONE) {
            console.log("Http status: " + request.status);
            if (request.status == 200 || request.status == 204) {
                successcallback(request.response);
            } else {
                personSendingFailure();
            }
        }
    }

    request.setRequestHeader("Content-Type", contentType);
    request.send(params);

    console.log("Ajax request has just been sent to the server. ");
}



function Transaction(Id, ExchangeRate, CurrencyCode, Quantity) {
    this.Id = Id;
    this.ExchangeRate = ExchangeRate;
    this.CurrencyCode = CurrencyCode;
    this.Quantity = Quantity;
}


function refreshFunction() {


    makeAJAXCall("GET", "api/Transaction", null,
        function (data) {
            var list = $("#ulList");
            list.children().remove();
            var table = JSON.parse(data);
            for (var i in table) {
                var tran = table[i];
                var li = document.createElement("li");
                li.innerText = tran.exchangeRate + " - " + tran.currencyCode + " - " + tran.quantity;
                list.append(li);
            }
        },
        function () {
            console.log("failed: " + strTran);
        }, "application/json");


    ;
}

$(document).ready(function () {
    $("#odswiez").click(refreshFunction);

    $("#zapisz").click(function () {
        var kod = $("#kod").val();
        var kurs = $("#kurs").val();
        var ilosc = $("#ilosc").val();

        var tran = new Transaction(1, kurs, kod, ilosc);
        var strTran = JSON.stringify(tran);

        makeAJAXCall("POST", "api/Transaction", strTran,
            function () {
                console.log("sent: " + strTran);
            },
            function () {
                console.log("sent: " + strTran);
            }, "application/json");

        refreshFunction();
    });

    $("#usun").click(function () {
        var promise;
        makeAJAXCall("DELETE", "api/Transaction", null,
            function () {
                promise = new Promise(function (resolve, reject) {

                });

                console.log("sent: " + strTran);
            },
            function () {
                console.log("sent: " + strTran);
            });
        refreshFunction();
    });




    

})