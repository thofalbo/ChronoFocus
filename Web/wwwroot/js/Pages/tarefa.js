var tarefa = (function () {
    var configs = {
        urls: {
            index: '',
            cadastrar: '',
            excluir: ''
        }
    };

    let tempoInicio = null;
    let contadorTempo;
    let isPaused = false;
    let tempoPausado = 0;

    var init = function ($configs) {
        configs = $configs;
    };

    var getCadastrar = function () {
        $.get(configs.urls.cadastrar).done((html) => {
            $('#formCadastro').html(html);
        });
    };
    // var hideCadastrar = function () {
    //     $.get(configs.urls.cadastrar).done(() => {
    //         $('#formCadastro').html('');
    //     });
    // };
    var hideCadastrar = function () {
        $('#formCadastro').toggle(); // Toggle the visibility of the formCadastro element
        $('#tabelaTarefas').toggle();
    };
    // var hideCadastrar = function () {
    //     $('#formCadastro').hide(); // Hide the formCadastro element
    //     console.log("formCadastro hidden");
    // };


    var getExcluir = function () {
        location.href = configs.urls.excluir;
    };

    var cadastrar = function () {
        $('#tempoTarefa').val($('#relogio').text());
        var model = $('#visorForm').serializeObject();
        $.post(configs.urls.cadastrar, model).done(() => {
            clearInterval(contadorTempo);
            location.reload();
        });
    };

    var excluir = function () {
        var model = $('formExcluir').serializeObject();
        $.post(configs.urls.cadastrar, model).done(() => {
            location.href = configs.urls.index;
        });
    };

    const fnVisor = segundos => {
        const tempo = new Date(segundos);
        return tempo.toLocaleTimeString('pt-BR', {
            hour12: false,
            timeZone: 'UTC'
        });
    };

    const fnContador = () => {
        tempoInicio = new Date();

        contadorTempo = setInterval(() => {
            if (!isPaused) {
                let tempoAtual = new Date();
                let intervaloTempo = Math.floor((tempoAtual - tempoInicio) + tempoPausado);

                $('#relogio').text(fnVisor(intervaloTempo));
            }
        }, 1000);
    };

    const playPause = () => {
        if (!isPaused) {
            isPaused = true;
            clearInterval(contadorTempo);
            tempoPausado += Math.floor((new Date() - tempoInicio));
        } else {
            isPaused = false;
            tempoInicio = new Date();
            fnContador();
        }
    };

    return {
        init: init,
        cadastrar: cadastrar,
        getCadastrar: getCadastrar,
        getExcluir: getExcluir,
        excluir: excluir,
        fnContador: fnContador,
        playPause: playPause,
        hideCadastrar: hideCadastrar
    };
})();