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

        public async Task CadastrarAsync(Tarefa tarefa)
        {
            if (tarefa.TempoTarefa == default)
            {
                return;
            }
            await _tarefaRepository.CadastrarAsync(new Tarefa
            {
                IdUsuario = 1,
                Atividade = tarefa.Atividade,
                TipoAtividade = tarefa.TipoAtividade,
                Plataforma = tarefa.Plataforma,
                TempoTarefa = tarefa.TempoTarefa.ToUniversalTime(),
                DataCadastro = tarefa.DataCadastro.ToUniversalTime()
            });
        }

        public async Task ExcluirAsync(int id)
        {
                await _tarefaRepository.ExcluirAsync(id);
        }        
    }
}