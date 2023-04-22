namespace Web.Controllers;
[Route("tarefa")]
public class TarefaController : AuthenticatedController
{
    private readonly AppDbContext _dbContext;
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ITarefaService _tarefaService;
    public TarefaController(
        AppDbContext dbContext,
        ITarefaRepository tarefaRepository,
        ITarefaService tarefaService
    )
    {
        _dbContext = dbContext;
        _tarefaRepository = tarefaRepository;
        _tarefaService = tarefaService;
    }

    [HttpGet("inicio")]
    public IActionResult Index() => View(_tarefaService.MostrarTarefas(IdUsuarioLogado));

    [HttpGet("cadastrar")]
    public IActionResult CadastrarGet() => View("_cadastrar");

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarPost(Tarefa tarefa)
    {
        if (!ModelState.IsValid)
            return View("_cadastrar", tarefa);

        await _tarefaService.CadastrarAsync(tarefa, IdUsuarioLogado);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id}")]
    public async Task<IActionResult> ExcluirGet(int id)
    {
        var tarefa = await _tarefaRepository.BuscarPorIdAsync(id);
        if (tarefa == null)
            return NotFound();

        return View("_excluir", tarefa);
    }

    [HttpPost("excluir/{id:int}")]
    public async Task<IActionResult> ExcluirPost(int id)
    {
        await _tarefaRepository.ExcluirAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:int}")]
    public async Task<IActionResult> EditarGet(int id)
    {
        var opcao = await _tarefaRepository.BuscarPorIdAsync(id);

        if (opcao == null)
            return NotFound();

        return View("_editar");
    }
}

//     View("_excluir", await _dbContext.Tarefas.FindAsync(id));