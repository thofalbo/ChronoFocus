using Core.Dto.Departamento;
using Core.Interfaces.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("Departamento")]
    public class DepartamentoController : Controller
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

        [HttpGet("Index")]
        public IActionResult Index() => View(_dbContext.Departamentos.ToList());

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar() => View();

        [HttpPost("CadastrarAction")]
        public async Task<IActionResult> CadastrarAction(Departamento departamento)
        {
            System.Console.WriteLine(departamento.Nome);
            if (ModelState.IsValid)
            {
                await _departamentoRepository.CadastrarAsync(new DepartamentoCadastroDto {
                    Nome = departamento.Nome
                });
                
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        [HttpGet("Detalhes")]
        public async Task<IActionResult> Detalhes(DepartamentoViewModel departamentoViewModel)
        {
            if (departamentoViewModel.Id == null || _dbContext.Departamentos == null)
                return NotFound();

            var departamento = await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == departamentoViewModel.Id);
            if (departamento == null)
                return NotFound();
            return View(new DepartamentoViewModel(departamento));
        }

        [HttpGet("Excluir")]
        public async Task<IActionResult> Excluir(int? id)
        {
            var obj = await _dbContext.Departamentos.FindAsync(id.Value);
            
            return View(obj);
        }
        [HttpPost("ExcluirAction")]
        public async Task<IActionResult> ExcluirAction(int id)
        {
            await _departamentoService.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Editar")]
        public async Task<IActionResult> Editar(int? id)
        {
            var obj = await _dbContext.Departamentos.FindAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost("EditarAction")]
        public async Task<IActionResult> EditarAction(Departamento departamento)
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