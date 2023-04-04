namespace Web.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartamentoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() => View(_dbContext.Departamentos.ToList());

        public IActionResult Cadastrar() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Departamentos.Add(departamento);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null || _dbContext.Departamentos == null)
                return NotFound();

            var departmento = await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (departmento == null)
                return NotFound();

            return View(departmento);
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