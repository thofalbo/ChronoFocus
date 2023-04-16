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
    
    var hideCadastrar = function () {
        $('#formCadastro').toggle();
        $('#tabelaTarefas').toggle();
        $('.botoes-relogio').toggle();
    };

    var hideBotoes = () => {
        $('#formCadastro').toggle();
        $('#tabelaTarefas').toggle();
    }

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
        if ($('#cadastroAtividade').val()) {
            if (!isPaused) {
                isPaused = true;
                clearInterval(contadorTempo);
                tempoPausado += Math.floor((new Date() - tempoInicio));
            } else {
                isPaused = false;
                tempoInicio = new Date();
                fnContador();
            }
            $('.botao-relogio').toggle();
            $('#botaoInicio').toggle();
        }
        else {
            hideCadastrar();
        }
    };

    const fnCadastrarAtividade = () => {
        if ($('#cadastroAtividade').val()) {
            hideCadastrar();
        }
        else {
            $('.botoes-relogio').toggle();
            hideCadastrar();
        };
    };

    
    const fnFinalizarAtividade = () => {        
        if ($('#cadastroAtividade').val()) {
            $('.botoes-relogio').toggle();
            $('#botaoInicio').toggle();
            fnContador();
        }
        hideCadastrar();
    };

    return {
        init: init,
        cadastrar: cadastrar,
        getCadastrar: getCadastrar,
        getExcluir: getExcluir,
        excluir: excluir,
        fnContador: fnContador,
        playPause: playPause,
        hideCadastrar: hideCadastrar,
        fnCadastrarAtividade: fnCadastrarAtividade,
        fnFinalizarAtividade: fnFinalizarAtividade
    };
})();