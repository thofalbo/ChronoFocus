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
            ViewBag.IdUsuarioLogado = IdUsuarioLogado;
            return View(_tarefaService.MostrarTarefas(IdUsuarioLogado));
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() => View();

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Tarefa tarefa) => await _tarefaService.CadastrarAsync(tarefa, IdUsuarioLogado);

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id) => View(await _dbContext.Tarefas.FindAsync(id.Value));

        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _tarefaService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}