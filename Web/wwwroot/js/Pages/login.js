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
        console.log("teste");
        var model = $('#form-login').serializeObject();
        console.log(model);
        $.post(configs.urls.log, model).done(function() {
            location.href = configs.urls.home;
            console.log("passando"); // Updated this line
            console.log(model);
        });
    };

    return {
        init: init,
        login: login
    };
})()

