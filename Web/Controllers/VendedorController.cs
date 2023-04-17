namespace Web.Controllers
{
    [Route("vendedor")]
    public class VendedorController : AuthenticatedController
    {
        private readonly ApplicationDbContext _dbContext;
        public VendedorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<Departamento> Index() => View(_dbContext.Vendedores.ToList());
    }
}