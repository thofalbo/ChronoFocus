var departamento = (function () {
    var configs = {
        urls: {
            cadastrar: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var cadastrar = function () {
        console.log(configs.urls.cadastrar);
        var model = $('#formCadastrar').serializeObject();
        console.log(model);
        $.post(configs.urls.cadastrar, model).done(() => {            
        })
    };

    return {
        init: init,
        cadastrar: cadastrar
    };
})()