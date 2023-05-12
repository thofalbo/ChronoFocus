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

    var mostrarPermissoesUsuario = (model, url, partialView) => {
            $.get(configs.urls[url], $(`#${model}`).serializeObject()).done((html) => {
                $(`#${partialView}`).html(html);
                site.toast.success('Acoes encontradas com sucesso');
            }).fail((msg) => {
                site.toast.error(msg);
            });
    };

    var alterarPermissoesUsuario = (url) => {
        var model = {
            permitidos: permitidos
        };

        $.post(configs.urls[url], model).done(() => {
            location.reload();
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

    return {
        init: init,
        alterarPermissoesUsuario: alterarPermissoesUsuario,
        addPermissao: addPermissao,
        mostrarPermissoesUsuario: mostrarPermissoesUsuario
    };
})();
