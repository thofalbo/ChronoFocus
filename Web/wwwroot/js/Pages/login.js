var login = (function () {
    var configs = {
        urls: {
            index: '',
            log: '',
            home: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };
    
    var login = function () {
        var model = $('#form-login').serializeObject();
        $.post(configs.urls.log, model).done(function() {
            location.href = configs.urls.home;
        });
    };

    return {
        init: init,
        login: login
    };
})()