namespace Web.Controllers
{
    public class VendedorController : Controller
    {
        private readonly BaseDbContext _dbContext;
        public VendedorController(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<Departamento> Index() => View(_dbContext.Vendedores.ToList());
    }
}