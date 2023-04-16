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
        public IActionResult Index()
        {
            var jwtToken = Request.Cookies["JwtToken"];

            if (jwtToken != null)
            {
                var usuarioLogado = TokenService.UsuarioLogado(jwtToken);
                var tarefas = _tarefaService.MostrarTarefas(usuarioLogado);
                return View(tarefas);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var jwtToken = Request.Cookies["JwtToken"];

            if (jwtToken != null)
            {
                return View();
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost("cadastrar")]
        public async Task Cadastrar(Tarefa tarefa)
        {
            await _tarefaService.CadastrarAsync(tarefa, TokenService.UsuarioLogado(Request.Cookies["JwtToken"]));
        }

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id)
        {
            var jwtToken = Request.Cookies["JwtToken"];

            if (jwtToken != null)
            {
                var obj = await _dbContext.Tarefas.FindAsync(id.Value);

                return View(obj);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _tarefaService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}