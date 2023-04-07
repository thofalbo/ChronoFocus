var departamento = (function () {
    var configs = {
        urls: {
            cadastrar: '',
            excluir: '',
            index: '',
            editar: ''
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
            location.href = (configs.urls.index)
        })
    };

    var editar = function () {
        console.log(configs.urls.editar);
        var model = $('#formEditar').serializeObject();
        console.log(model);
        $.post(configs.urls.editar, model).done(() => {
            location.href = (configs.urls.index)
        })
    };

    return {
        init: init,
        cadastrar: cadastrar,
        excluir: excluir,
        editar: editar
    };
})()