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
        public async Task<IActionResult> Cadastrar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var model = new TarefaViewModel{
                    IdUsuario = 1,
                    Atividade = tarefa.Atividade,
                    TipoAtividade = tarefa.TipoAtividade,
                    Plataforma = tarefa.Plataforma,
                    TempoTarefa = new DateTime(1990, 04, 07, 0, 0, 0, 0, 0).ToUniversalTime(),
                    DataCadastro = new DateTime(2023, 04, 07, 0, 0, 0, 0, 0).ToUniversalTime()
                };
                await _tarefaRepository.CadastrarAsync(tarefa);
            }
            return Ok("Cadastro efetuado");
        }
    }
}