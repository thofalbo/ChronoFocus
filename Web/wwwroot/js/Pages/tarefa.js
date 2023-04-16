var tarefa = (function () {
    var configs = {
        urls: {
            index: '',
            cadastrar: '',
            excluir: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var getCadastrar = function () {
        $.get(configs.urls.cadastrar).done((html) => {
            $('#formCadastro').html(html);
        })
    };

    var getExcluir = function () {
        location.href = (configs.urls.excluir)
    };

    var cadastrar = function () {
        $('#tempoTarefa').val($('#relogio').text());
        var model = $('#visorForm').serializeObject();
        console.log(model)
        $.post(configs.urls.cadastrar, model).done(() => {
            clearInterval(contadorTempo); // Stop the elapsed time interval
            location.reload();
        })
    };

    var excluir = function () {
        var model = $('formExcluir').serializeObject();
        console.log(model)
        $.post(configs.urls.cadastrar, model).done(() => {
            location.href = (configs.urls.index)
        })
    };

    let tempoInicio = null;
    let contadorTempo;

    const fnVisor = segundos => {
        const tempo = new Date(segundos * 1000)
        return tempo.toLocaleTimeString('pt-BR', {
            hour12: false,
            timeZone: 'UTC'
        })
    };

    const fnContador = () => {
        tempoInicio = new Date();

        contadorTempo = setInterval(() => {
            let tempoAtual = new Date();
            let intervaloTempo = Math.floor((tempoAtual - tempoInicio) / 1000);

            $('#relogio').text(fnVisor(intervaloTempo));
        }, 1000);
    };

    return {
        init: init,
        cadastrar: cadastrar,
        getCadastrar: getCadastrar,
        getExcluir: getExcluir,
        excluir: excluir,
        fnContador: fnContador
    };
})();