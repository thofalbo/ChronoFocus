namespace Web.Controllers
{
    [Route("tarefa")]
    public class TarefaController : AuthenticatedController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaService _tarefaService;
        private readonly IUsuarioRepository _usuarioRepository;
        public TarefaController(
            ApplicationDbContext dbContext,
            ITarefaRepository tarefaRepository,
            ITarefaService tarefaService,
            IUsuarioRepository usuarioRepository
        )
        {
            _dbContext = dbContext;
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
            _tarefaService = tarefaService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            var tarefas = _tarefaService.MostrarTarefas(IdUsuarioLogado);
            return View(tarefas);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Tarefa tarefa)
        {
            await _tarefaService.CadastrarAsync(tarefa, TokenService.UsuarioLogado(Request.Cookies["JwtToken"]));
        }

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id)
        {
            var tarefa = await _dbContext.Tarefas.FindAsync(id.Value);
            return View(tarefa);
        }

        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _tarefaService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}