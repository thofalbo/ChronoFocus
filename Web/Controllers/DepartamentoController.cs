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
    }
}