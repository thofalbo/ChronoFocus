var login = (function () {
    var configs = {
        urls: {
            logar: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };
    
    var login = function () {
        var model = $('#form-login').serializeObject();
        $.post(configs.urls.logar, model).done(function() {
            location.href = "/home";
        });
    };

    return {
        init: init,
        login: login
    };
})()