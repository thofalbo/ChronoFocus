namespace Web.Controllers
{
    [Route("tarefa")]
    public class TarefaController : Controller
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
        public IActionResult Index() => View(_tarefaService.MostrarTarefas(TokenService.UsuarioLogado(HttpContext.Session.GetString("JwtToken"))));

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() => View();
        
        [HttpPost("cadastrar")]
        public async Task Cadastrar(Tarefa tarefa)
        {
            await _tarefaService.CadastrarAsync(tarefa, TokenService.UsuarioLogado(HttpContext.Session.GetString("JwtToken")));
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