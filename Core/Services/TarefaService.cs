namespace Core.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TarefaService(
            ITarefaRepository tarefaRepository,
            IUsuarioRepository usuarioRepository
        )
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
        }
        
        public IEnumerable<Tarefa> MostrarTarefas(int idUsuario)
        {
            var tarefas = _tarefaRepository.MostrarTarefas(idUsuario);
            
            return tarefas;
        }
        
        public async Task CadastrarAsync(Tarefa tarefa, int usuarioLogado)
        {
            if (tarefa.TempoTarefa == default)
            {
                return;
            }

            var tarefas = _tarefaRepository.MostrarTarefas(usuarioLogado);

            var tarefaRepetida = tarefas.FirstOrDefault(x =>
                x.Atividade?.ToLower() == tarefa.Atividade?.ToLower() &&
                x.TipoAtividade?.ToLower() == tarefa.TipoAtividade?.ToLower() &&
                x.Plataforma?.ToLower() == tarefa.Plataforma?.ToLower()
            );

            if (tarefaRepetida != null)
            {
                tarefaRepetida.TempoTarefa = tarefaRepetida.TempoTarefa.Add(tarefa.TempoTarefa);
                await _tarefaRepository.AtualizarAsync(tarefaRepetida);
            }
            else
            {
                await _tarefaRepository.CadastrarAsync(new Tarefa
                {
                    IdUsuario = usuarioLogado,
                    Atividade = tarefa.Atividade,
                    TipoAtividade = tarefa.TipoAtividade,
                    Plataforma = tarefa.Plataforma,
                    TempoTarefa = tarefa.TempoTarefa,
                    DataCadastro = tarefa.DataCadastro.ToUniversalTime()
                });
            }
        }
        public async Task ExcluirAsync(int id)
        {
                await _tarefaRepository.ExcluirAsync(id);
        }        
    }
}