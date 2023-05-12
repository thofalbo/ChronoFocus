﻿var site = (function () {
    var config = {
    };

    var init = function ($config) {
        config = $config;
    }
    var toast = (function () {
        function show(type) {
            return function (message, timeout, position) {
                function showToast($message, $timeout, $position) {
                    if (!$message || typeof $message !== 'string')
                        return;

                    if ($message.indexOf('<') === 0) {
                        var htmlTitle = $($message).filter('title').html();
                        if (htmlTitle && htmlTitle.length) {
                            var knownStatus = {
                                '524': 'A requisição levou muito tempo para ser processada'
                            };

                            var status = htmlTitle.match(/\d{3}/g)[0];
                            $message = status && knownStatus[status] ? knownStatus[status] : htmlTitle;
                        }
                    }

                    iziToast[type]({
                        message: $message,
                        timeout: $timeout || 10000,
                        position: $position || 'bottomCenter',
                        displayMode: 'replace'
                    });
                }

                var keys = Object.keys(message || {});
                if (keys && keys.length && (message.responseText || message.xhr)) {
                    if (message.xhr)
                        message.responseText = message.xhr.responseText || 'Limite de upload excedido';
                    if (!message.responseText)
                        return;

                    if (message[0] !== '{' && message[0] !== '[') {
                        showToast(message.responseText);
                        return;
                    }

                    var content = JSON.parse(message);
                    if (content.messages && content.messages.length)
                        content.messages.forEach(showToast);

                    return;
                }

                showToast(message, timeout, position);
            };
        }

        function question(message, callbackYes, callbackNo) {
            iziToast.show({
                message: message,
                id: 'toastQuestion',
                close: false,
                overlay: true,
                timeout: 0,
                displayMode: 'replace',
                toastOnce: true,
                icon: 'fa fa-question-circle',
                position: 'center',
                drag: false,
                buttons: [
                    [
                        '<button>Sim</button>',
                        function (instance, toast) {
                            if (typeof callbackYes == 'function')
                                callbackYes();
                            instance.hide({ transitionOut: 'fadeOutUp' }, toast, 'buttonName');
                        },
                        true
                    ],
                    [
                        '<button>Não</button>',
                        function (instance, toast) {
                            if (typeof callbackNo == 'function')
                                callbackNo();
                            instance.hide({ transitionOut: 'fadeOutUp' }, toast, 'buttonName');
                        }
                    ]
                ]
            });
        }

        function noResults(message) {
            iziToast.show({
                message: 'Nenhum resultado encontrado!',
                color: '#D9D9D940',
                position: 'center',
                timeout: 5000,
                overlay: true,
                displayMode: 'once',
                drag: false,
                messageSize: 19,
                messageLineHeight: 40,
                messageColor: '#FFFFFF'
            });
        }

        return {
            info: show('info'),
            success: show('success'),
            warning: show('warning'),
            error: show('error'),
            question: question,
            noResults: noResults,
            clear: function () { iziToast.destroy(); },
        };
    })();

    $(function () {
        $(document).on('submit', 'form', function (e) {
            e.preventDefault();
            return false;
        });
    });

    (function () {
        $.fn.serializeObject = function (extraValidations) {
            var form = $(this),
                array = this.serializeArray(),
                obj = {};

            $.each(array, function () {
                if (!obj[this.name]) {
                    obj[this.name] = this.value;
                    return;
                }

                if (!Array.isArray(obj[this.name]))
                    obj[this.name] = [obj[this.name]];

                obj[this.name].push(this.value);
            });

            form.find('.uk-form-controls, .uk-inline').find('input, select, textarea').trigger('input');

            obj.isValid = !form.find('.uk-form-controls.error, .uk-inline.error').length;
            if (obj.isValid && typeof extraValidations === 'function')
                obj.isValid = extraValidations(form, obj);

            obj.isEmpty = true;
            for (var prop in obj)
                if (typeof obj[prop] === 'string' && obj[prop].trim()) {
                    obj.isEmpty = false;
                    break;
                }

            return obj;
        };
    })();

    return {
        init: init,
        toast: toast
    };
})();