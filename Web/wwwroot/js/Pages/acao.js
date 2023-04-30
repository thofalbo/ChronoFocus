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

    // var fnSubmitar = (form, url) => {
    //     var model = $(`#${form}`).serializeObject();
    //     console.log(model);
    //         $.post(configs.urls[url], model).done(() => {
    //         });
    // };
    
    var fnSubmitar = (form, url) => {
        $.post(configs.urls[url], {
            permitidos: permitidos
        }).done(() => {
            location.href = configs.urls.index;
        });
    };

    var permitidos = [];

    function addPermissao(idAcao, idUsuario, isChecked) {
        var permissao = {
            IdAcao: idAcao,
            IdUsuario: idUsuario,
            TemPermissao: isChecked,
        };
        var index = permitidos.findIndex((p) => p.Id == idAcao);
        if (index > -1) {
            permitidos.splice(index, 1);
        }
        permitidos.push(permissao);
        console.log(permitidos)
    }

    return {
        init: init,
        fnSubmit: fnSubmit,
        fnSubmitar: fnSubmitar,
        addPermissao: addPermissao
    };
})();