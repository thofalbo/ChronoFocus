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

    var fnSubmit = (form, url) => {
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

    return {
        init: init,
        fnSubmit: fnSubmit,
        fnSubmitar: fnSubmitar,
        addPermissao: addPermissao
    };
})();
