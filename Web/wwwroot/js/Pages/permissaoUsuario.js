var permissaoUsuario = (() => {
    var configs = {
        urls: {
            index: '',
            cadastrar: ''
        },
    };

    var init = ($configs) => {
        configs = $configs;
    };

    var permitidos = [];

    var fnBuscar = (form, url) => {
        if ($('#nomeUsuario').val()) {
            var model = $('#nomeUsuario').val();

            $.get(configs.urls[url], {nome: model}).done((html) => {
                $(`#${form}`).html(html);
            });
        }
    };

    var fnBuscarGet = (form, url) => {
        $.get(configs.urls[url]).done((html) => {
            $(`#${form}`).html(html);
        });
    };

    var fnSubmitar = (form, url) => {
        var model = {
            permitidos: permitidos
        };
        $.post(configs.urls[url], model).done(() => {
            location.href = configs.urls.index;
        });
    };

    function addPermissao(idPermissao, idUsuario, isChecked) {
        var permissao = {
            IdPermissao: idPermissao,
            IdUsuario: idUsuario,
            TemPermissao: isChecked,
        };
        var index = permitidos.findIndex((p) => p.IdPermissao == idPermissao && p.IdUsuario == idUsuario);
        if (index > -1) {
            permitidos.splice(index, 1);
        }
        permitidos.push(permissao);
    }

    var fnDandara = (form, url) => {
        if ($('#nomeUsuario').val()) {
            var model = $('#formBuscaUsuario').serializeObject();
            console.log(model)
            $.get(configs.urls[url], model).done((html) => {
                $(`#${form}`).html(html);
            });
        }
    };

    return {
        init: init,
        fnBuscarGet: fnBuscarGet,
        fnSubmitar: fnSubmitar,
        addPermissao: addPermissao,
        fnDandara: fnDandara,
        fnBuscar: fnBuscar
    };
})();
