$(document).ready(function () {
    $('#btnConvert').click(function () {


        alert("Hello");
        var name = $('#name').val();
        var value = $('#price').val();
        doAjax(name, value);


    });

    var doAjax = function (name, value) {

        $.ajax({
            url: 'http://localhost:53647/api/transform', // .asp?
            type: 'POST',
            data: JSON.stringify({ "name": name, "value": value }),
            contentType: 'application/json',
            responseType: 'application/json',
            dataType: 'json',
            success: function (response) {
                var a = response.name;
                var b = response.value;
                alert(a + b);

            }
        });
    };
});
