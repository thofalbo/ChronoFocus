namespace Web.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly BaseDbContext _dbContext;
        public DepartamentoController(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<Departamento> Index() => View(_dbContext.Departamentos.ToList());
        
        public ActionResult<Departamento> Create() => View();

        [HttpPost]
        public IActionResult Create(Departamento departamento)
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