namespace Web.Controllers
{
    [Route("tarefa")]
    public class TarefaController : Controller
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
        public IActionResult Index() => View(_tarefaService.MostrarTarefas(1));

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() => View();
        
        [HttpPost("cadastrar")]
        public async Task Cadastrar(Tarefa tarefa)
        {
            await _tarefaService.CadastrarAsync(tarefa);
        }

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id)
        {
            var obj = await _dbContext.Tarefas.FindAsync(id.Value);
            
            return View(obj);
        }
        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _tarefaService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}