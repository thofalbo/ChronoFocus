var usuario = (function () {
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
        var model = $('#formCadastrarUsuario').serializeObject();
        $.post(configs.urls.cadastrar, model).done(() => {
            location.href = (configs.urls.index)
        });
    };

    var excluir = function () {
        var model = $('#formExcluirUsuario').serializeObject();
        $.post(configs.urls.excluir, model).done(() => {
            location.href = (configs.urls.index)
        })
    };

    var editar = function () {
        var model = $('#formEditarUsuario').serializeObject();
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