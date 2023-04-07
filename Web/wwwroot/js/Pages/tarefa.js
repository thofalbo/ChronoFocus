var tarefa = (function () {
    var configs = {
        urls: {
            index: '',
            cadastrar: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var cadastrar = function () {
        console.log(configs.urls.cadastrar);
        var model = $('#visorForm').serializeObject();
        console.log(model);
        $.post(configs.urls.cadastrar, model).done(() => {
            location.href = (configs.urls.index)
        })
    };

    return {
        init: init,
        cadastrar: cadastrar
    };
})()