var tarefa = (() => {
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

    var init = ($configs) => {
        configs = $configs;
    };

    var getCadastrar = () => {
        $.get(configs.urls.cadastrar).done((html) => {
            $('#formCadastro').html(html);
            hideCadastrar();
        });
    };
    
    var hideCadastrar = () => {
        $('#formCadastro').toggle();
        $('#tabelaTarefas').toggle();
        $('.botoes-relogio').toggle();
    };

    var getExcluir = () => {
        location.href = configs.urls.excluir;
    };

    var cadastrar = () => {
        if ($('#cadastroAtividade').val()) {
            $('#tempoTarefa').val($('#relogio').text());
            var model = $('#visorForm').serializeObject();
            $.post(configs.urls.cadastrar, model).done(() => {
                clearInterval(contadorTempo);
                location.reload();
            });
        }
        else {
            hideCadastrar();
        }
    };

    var excluir = () => {
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
    
    const ordenarTabela = (prop) => {
        const tabela = $(".tabelaTarefas");
        const linhas = tabela.find(".linha").toArray();
        const cabecalho = $(`th[ordenar="${prop}"]`);
        const ordem = cabecalho.hasClass("asc") ? -1 : 1;
        
        cabecalho.toggleClass("asc desc");
    
        linhas.sort((a, b) => {
            const linhaA = $(a).find(`td[ordenado="${prop}"]`).text().trim().toLowerCase();
            const linhaB = $(b).find(`td[ordenado="${prop}"]`).text().trim().toLowerCase();
            return ordem * linhaA.localeCompare(linhaB);
        });
    
        tabela.find(".corpo-tabela-tarefas").empty().append(linhas);
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
        fnFinalizarAtividade: fnFinalizarAtividade,
        ordenarTabela: ordenarTabela
    };
})();