namespace Web.Controllers
{
    [Route("tarefa")]
    public class TarefaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public TarefaController()
        {
        }

        [HttpGet("index")]
        public IActionResult Index() => View();
    }
}