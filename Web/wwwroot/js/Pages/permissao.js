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
            $.get(configs.urls[url]).done((html) => {
                $("#tabelaPermissoes").html(html);
            });
        }
    };

    var fnSubmitar = (form, url) => {
        var model = $(`#${form}`).serializeObject();
        console.log(model);
    };

    var permitidos = [];
    var proibidos = [];

    function addPermissao(id, idUsuario, idControlador, idAcao, isChecked) {
        var permissao = {
            Id: id,
            IdUsuario: idUsuario,
            IdControlador: idControlador,
            IdAcao: idAcao,
            Acesso: isChecked,
        };
        if (isChecked) {
            permitidos.push(permissao);
            var index = proibidos.findIndex((p) => p.Id == id);
            if (index > -1) {
                proibidos.splice(index, 1);
            }
        } else {
            proibidos.push(permissao);
            var index = permitidos.findIndex((p) => p.Id == id);
            if (index > -1) {
                permitidos.splice(index, 1);
            }
        }
        console.log(permitidos);
        console.log(proibidos);
        
    }

    return {
        init: init,
        fnSubmit: fnSubmit,
        fnSubmitar: fnSubmitar,
        addPermissao: addPermissao
    };
})();