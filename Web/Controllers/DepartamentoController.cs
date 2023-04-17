namespace Web.Controllers
{
    [Route("departamento")]
    public class DepartamentoController : AuthenticatedController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDepartamentoService _departamentoService;
        private readonly IDepartamentoRepository _departamentoRepository;
        public DepartamentoController(
            ApplicationDbContext dbContext,
            IDepartamentoService departamentoService,
            IDepartamentoRepository departamentoRepository
        )
        {
            _dbContext = dbContext;
            _departamentoService = departamentoService;
            _departamentoRepository = departamentoRepository;
        }

        [HttpGet("index")]
        public IActionResult Index() => View(_dbContext.Departamentos.ToList());

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar() => View();

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                await _departamentoRepository.CadastrarAsync(new DepartamentoCadastroDto {
                    Nome = departamento.Nome
                });
            }
            return Ok("Cadastro efetuado");
        }

        [HttpGet("detalhes")]
        public async Task<IActionResult> Detalhes(DepartamentoViewModel departamentoViewModel)
        {
            if (departamentoViewModel.Id == default || _dbContext.Departamentos == default)
                return NotFound();

            var departamento = await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == departamentoViewModel.Id);
            if (departamento == null)
                return NotFound();
            return View(new DepartamentoViewModel(departamento));
        }

        [HttpGet("excluir")]
        public async Task<IActionResult> Excluir(int? id)
        {
            var obj = await _dbContext.Departamentos.FindAsync(id.Value);
            
            return View(obj);
        }
        [HttpPost("excluir")]
        public async Task<IActionResult> Excluir(int id)
        {
            await _departamentoService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar")]
        public async Task<IActionResult> Editar(int? id)
        {
            var obj = await _dbContext.Departamentos.FindAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost("editar")]
        public async Task<IActionResult> Editar(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return View(departamento);
            }

            _dbContext.Departamentos.Update(departamento);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}