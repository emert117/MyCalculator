$(document).ready(function () {
    $("form").submit(function (event) {
        var operands = [];
        operands.push(Number($("#firstOperand").val()));
        operands.push(Number($("#secondOperand").val()));

        var formData = {
            Operands: operands,
            Operator: $("#operator").val()
        };

        $.ajax({
            type: "POST",
            url: "https://localhost:7000/operator/calculate",
            data: JSON.stringify(formData),
            contentType: "application/json",
            encode: true,
        }).done(function (data) {
            console.log(data);
            if (data.isSuccessful) {
                $("#result").val(data.result);
            } else {
                $("#result").val("Error");
                alert("An error occurred");
            }
        }).fail(function (xhr, status, error) {
            $("#result").val("Error");
            alert("An error occurred");
        });

        event.preventDefault();
    });
});