var tela = (() => {
    var configs = {
        urls: {
            index: '',
            buscar: '',
            cadastrar: '',
            excluir: '',
            editar: ''
        },
    };

    var init = ($configs) => {
        configs = $configs;
    };

    var registrar = (form, url) => {
        var model = $(`#${form}`).serializeObject();

        $.post(configs.urls[url], model).done(() => {
            location.href = configs.urls.index;
        });
    };

    return {
        init: init,
        registrar: registrar
    };
})();
