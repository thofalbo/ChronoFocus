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
    public IActionResult CadastrarGet()
    {
        // if (!AcoesProibidas)
        //     return RedirectToAction("");

        return View("_cadastrar");
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarPost(Tarefa tarefa)
    {
        // if (AcoesProibidas)
        //     return RedirectToAction("/");
        await _tarefaService.CadastrarAsync(tarefa, IdUsuarioLogado);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id}")]
    public async Task<IActionResult> ExcluirGet(int id)
    {
        // if (AcoesProibidas)
        //     return RedirectToAction("/");

        var tarefa = await _tarefaRepository.BuscarPorIdAsync(id);
        if (tarefa == null)
            return NotFound();

        return View("_excluir", tarefa);
    }

    [HttpPost("excluir/{id:int}")]
    public async Task<IActionResult> ExcluirPost(int id)
    {
        // if (AcoesProibidas)
        //     return RedirectToAction("/");

        await _tarefaRepository.ExcluirAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:int}")]
    public async Task<IActionResult> EditarGet(int id)
    {
        // if (AcoesProibidas)
        //     return RedirectToAction("/");

        var opcao = await _tarefaRepository.BuscarPorIdAsync(id);

        if (opcao == null)
            return NotFound();

        return View("_editar");
    }
}