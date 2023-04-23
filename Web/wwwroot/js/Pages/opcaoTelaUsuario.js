var opcaoTelaUsuario = (() => {
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
        console.log(model)

        $.post(configs.urls[url], model).done(() => {
            console.log(model)
            location.href = configs.urls.index;
            
            console.log(model)
        });
    };

    return {
        init: init,
        registrar: registrar
    };
})();
