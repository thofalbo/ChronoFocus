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
        location.href = (configs.urls.cadastrar)
    };

    var getExcluir = function () {
        location.href = (configs.urls.excluir)
    };

    var cadastrar = function () {
        $('#tempoTarefa').val($('#relogio').text());
        var model = $('#visorForm').serializeObject();
        console.log(model)
        $.post(configs.urls.cadastrar, model).done(() => {
            clearInterval(contadorSegundos);
            location.href = (configs.urls.index)
        })
    };
    
    var excluir = function () {
        var model = $('formExcluir').serializeObject();
        console.log(model)
        $.post(configs.urls.cadastrar, model).done(() => {
            location.href = (configs.urls.index)
        })
    };

    let segundos = 0;
    const fnVisor = segundos => {
        const tempo = new Date(segundos * 1000)
        return tempo.toLocaleTimeString('pt-BR', {
          hour12: false,
          timeZone: 'UTC'
        })
      }
    const fnContador = () => {
        contadorSegundos = setInterval(() => {
            segundos++
            $('#relogio').text(fnVisor(segundos))
        }, 1000)
    }

    return {
        init: init,
        cadastrar: cadastrar,
        fnContador: fnContador,
        getCadastrar: getCadastrar,
        getExcluir: getExcluir,
        excluir: excluir
    };
})()