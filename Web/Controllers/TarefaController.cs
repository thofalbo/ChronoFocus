namespace Web.Controllers
{
    [Route("tarefa")]
    public class TarefaController : AuthenticatedController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaService _tarefaService;
        public TarefaController(
            ApplicationDbContext dbContext,
            ITarefaRepository tarefaRepository,
            ITarefaService tarefaService
        )
        {
            _dbContext = dbContext;
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View(_tarefaService.MostrarTarefas(IdUsuarioLogado));
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() {
            return View("_cadastrar");
        }

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Tarefa tarefa) => await _tarefaService.CadastrarAsync(tarefa, IdUsuarioLogado);

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int id) => View("_excluir", await _dbContext.Tarefas.FindAsync(id));

        [HttpPost("excluir")]
        public async Task<IActionResult> ExcluirTarefa(int id)
        {
            await _tarefaService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}