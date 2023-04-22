var opcaoTelaUsuario = (() => {
    var configs = {
        urls: {
            cadastrar: ''
        }
    };

    var init = ($configs) => {
        configs = $configs;
    };

    // var cadastrar = () => {
    //     var model = $('#formOpcaoTelaUsuario').serializeObject();
    //     $.post(configs.urls.cadastrar, model).done(
    //     );
    // };
    
    var cadastrar = () => {
        var model = $('#formCadastro').serialize();
        console.log(model);
        // $.post('@Url.Action("Cadastrar", "ControllerName")', model).done(
        //     function (data) {
        //         console.log('Success:', data);
        //     }
        // ).fail(
        //     function (xhr, textStatus, errorThrown) {
        //         console.log('Error:', xhr.responseText);
        //     }
        // );
    };

    return {
        init: init,
        cadastrar: cadastrar
    };
})();