var acao = (() => {
    var configs = {
        urls: {
            index: '',
            cadastrar: ''
        },
    };

    var init = ($configs) => {
        configs = $configs;
    };

    // var permitidos = [];

    var fnSubmit = (form, url) => {
        // var model = $(`#${form}`).serializeObject();
        // console.log(model);
        // if (!model.isEmpty) {
        //     $.post(configs.urls[url], model).done((html) => {
        //         $("#tabelaPermissoes").html(html);
        //     });
        // } else {
            $.get(configs.urls[url]).done((html) => {
                $(`#${form}`).html(html);
            });
        // }
    };

    var fnSubmitar = (form, url) => {
        var model = $(`#${form}`).serializeObject();
        console.log(model);
            $.post(configs.urls[url], model).done(() => {
            });
    };

    // function addPermissao(id, idUsuario, idControlador, idAcao, isChecked) {
    //     var permissao = {
    //         Id: id,
    //         IdUsuario: idUsuario,
    //         IdControlador: idControlador,
    //         IdAcao: idAcao,
    //         Acesso: isChecked,
    //     };
    //     var index = permitidos.findIndex((p) => p.Id == id);
    //     if (index > -1) {
    //         permitidos.splice(index, 1);
    //     }
    //     permitidos.push(permissao);

    // }

    return {
        init: init,
        fnSubmit: fnSubmit,
        fnSubmitar: fnSubmitar,
        // addPermissao: addPermissao
    };
})();