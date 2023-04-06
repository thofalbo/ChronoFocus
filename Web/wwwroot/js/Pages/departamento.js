var departamento = (function () {
    var configs = {
        urls: {
            cadastrar: '',
            excluir: '',
            index: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var cadastrar = function () {
        var model = $('#formCadastrar').serializeObject();
        $.post(configs.urls.cadastrar, model).done(() => {      
            location.href = (configs.urls.index)
        });
    };

    var excluir = function () {
        console.log(configs.urls.excluir);
        var model = $('#formExcluir').serializeObject();
        console.log(model);
        $.post(configs.urls.excluir, model).done(() => {       
        })
    };

    return {
        init: init,
        cadastrar: cadastrar,
        excluir: excluir
    };
})()