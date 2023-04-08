namespace Web.Controllers
{
    [Route("tarefa")]
    public class TarefaController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet("index")]
        public IActionResult Index() => View();
        
        [HttpPost("cadastrar")]
        public async Task Cadastrar(Tarefa tarefa)
        {
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
    }
}