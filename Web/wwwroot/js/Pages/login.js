var login = (function () {
    var configs = {
        urls: {
            index: '',
            log: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };
    
    var login = function () {
        var model = $('formLogin').serializeObject();
        console.log(model)
        $.post(configs.urls.log, model).done(() => {
        })
    };

    return {
        init: init,
        login: login
    };
})()