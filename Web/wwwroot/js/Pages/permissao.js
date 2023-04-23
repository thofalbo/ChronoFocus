var permissao = (() => {
    var configs = {
        urls: {
            index: "",
        },
    };

    var init = ($configs) => {
        configs = $configs;
    };

    var fnSubmit = (form, url) => {
        var model = $(`#${form}`).serializeObject();
        console.log(model);
        if (!model.isEmpty) {
            $.post(configs.urls[url], model).done((html) => {
                $("#tabelaPermissoes").html(html);
            });
        } else {
            $.get(configs.urls.buscar).done((html) => {
                $("#tabelaPermissoes").html(html);
            });
        }
    };

        

    return {
        init: init,
        fnSubmit: fnSubmit,
    };
})();
