function ajaxFormButton() {

    $('button[ajax-form-call="yes"]').click(function () {

        var button = $(this);
        var form = button.parents('form');

        form.submit(function (e) {

            e.preventDefault();

            var url = form.attr('ajax-url');
            var resultId = form.attr('ajax-result');
            var beginClass = `.${form.attr('ajax-begin')}`;

            var result = form.serialize()
                + '&'
                + encodeURI(button.attr('name'))
                + '='
                + encodeURI(button.attr('value'));

            $.ajax({
                type: 'POST',
                url: url,
                data: result,
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: function (result) {
                    if (resultId !== '') {
                        $(`#${resultId}`).html(result);

                    }
                },
                beforeSend: function (xhr) {
                    xhr.overrideMimeType('application/x-www-form-urlencoded; charset=UTF-8');
                    $(beginClass).val('');
                }
            });

        })
    }).attr('ajax-form-call', 'set');
}

function DodajAjaxEvente() {
    $("button[ajax-poziv='da']").click(function (event) {


        //$(this).attr("ajax-poziv", "dodan");

        event.preventDefault();
        var urlZaPoziv = $(this).attr("ajax-url");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        $.get(urlZaPoziv, function (data, status) {
            $("#" + divZaRezultat).html(data);
        });
    }).attr("ajax-poziv", "dodan");

    $("a[ajax-poziv='da']").click(function (event) {
        //$(this).attr("ajax-poziv", "dodan");
        event.preventDefault();
        var urlZaPoziv1 = $(this).attr("ajax-url");
        var urlZaPoziv2 = $(this).attr("href");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        var urlZaPoziv;

        if (urlZaPoziv1 instanceof String)
            urlZaPoziv = urlZaPoziv1;
        else
            urlZaPoziv = urlZaPoziv2;

        $.get(urlZaPoziv, function (data, status) {
            $("#" + divZaRezultat).html(data);
        });
    }).attr("ajax-poziv", "dodan");

    $("form[ajax-poziv='da']").submit(function (event) {
        //$(this).attr("ajax-poziv", "dodan");
        event.preventDefault();
        var urlZaPoziv1 = $(this).attr("ajax-url");
        var urlZaPoziv2 = $(this).attr("action");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        var urlZaPoziv;
        if (urlZaPoziv1 instanceof String)
            urlZaPoziv = urlZaPoziv1;
        else
            urlZaPoziv = urlZaPoziv2;

        var form = $(this);

        $.ajax({
            type: "POST",
            url: urlZaPoziv,
            data: form.serialize(),
            success: function (data) {
                $("#" + divZaRezultat).html(data);
            }
        });
    }).attr("ajax-poziv", "dodan");
}
$(document).ready(function () {
    // izvršava nakon što glavni html dokument bude generisan
    DodajAjaxEvente();
    ajaxFormButton();

});

$(document).ajaxComplete(function () {
    // izvršava nakon bilo kojeg ajax poziva
    DodajAjaxEvente();
    ajaxFormButton();
});
