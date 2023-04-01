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
    }
}