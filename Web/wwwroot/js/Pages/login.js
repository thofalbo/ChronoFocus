var login = (function () {
    var configs = {
        urls: {
            index: '',
            excluir: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };
    
    var excluir = function () {
        var model = $('formLogin').serializeObject();
        console.log(model)
        $.post(configs.urls.cadastrar, model).done(() => {
        })
    };

    return {
        init: init,
        excluir: excluir
    };
})()