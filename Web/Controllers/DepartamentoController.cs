using Core.Interfaces.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("Departamento")]
    public class DepartamentoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(ApplicationDbContext dbContext, IDepartamentoService departamentoService)
        {
            _dbContext = dbContext;
            _departamentoService = departamentoService;
        }
        public IActionResult Index() => View(_dbContext.Departamentos.ToList());

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar() => View();

        [HttpPost("CadastrarAction")]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> CadastrarAction(Departamento departamento)
        {
            System.Console.WriteLine(departamento.Nome);
            if (ModelState.IsValid)
            {
                await _departamentoService.CadastrarAsync(new Departamento {
                    Nome = departamento.Nome
                });
                
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        public async Task<IActionResult> Detalhes(int? id, DepartamentoViewModel departamentoViewModel)
        {
            if (id == null || _dbContext.Departamentos == null)
                return NotFound();

            var departamento = await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (departamento == null)
                return NotFound();
            return View(new DepartamentoViewModel(departamento));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            var obj = await _dbContext.Departamentos.FindAsync(id.Value);
            
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var departamento = await _dbContext.Departamentos.FindAsync(id);
            _dbContext.Departamentos.Remove(departamento);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var obj = await _dbContext.Departamentos.FindAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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