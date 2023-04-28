namespace Web.Controllers;

[Route("acao")]
public class AcaoController : AuthenticatedController
{
    private readonly AppDbContext _dbContext;
    // private readonly IAcaoService _acaoService;
    private readonly IAcaoRepository _acaoRepository;
    public AcaoController(
        AppDbContext dbContext,
        // IAcaoService acaoService,
        IAcaoRepository acaoRepository
    )
    {
        _dbContext = dbContext;
        // _acaoService = acaoService;
        _acaoRepository = acaoRepository;
    }

    [HttpGet("inicio")]
    public IActionResult Index() => View();

    [HttpGet("cadastrar")]
    public async Task<IActionResult> CadastrarGet()
    {
        var acoes = await _acaoRepository.ListarAsync();
        return View("_cadastrar", acoes);
    }

    // [HttpPost("cadastrar")]
    // public async Task<IActionResult> CadastrarPost(Tarefa tarefa)
    // {
    //     // if (AcoesProibidas)
    //     //     return RedirectToAction("/");
    //     await _tarefaService.CadastrarAsync(tarefa, IdUsuarioLogado);
    //     return RedirectToAction(nameof(Index));
    // }

    // [HttpGet("excluir/{id}")]
    // public async Task<IActionResult> ExcluirGet(int id)
    // {
    //     // if (AcoesProibidas)
    //     //     return RedirectToAction("/");

    //     var tarefa = await _tarefaRepository.BuscarPorIdAsync(id);
    //     if (tarefa == null)
    //         return NotFound();

    //     return View("_excluir", tarefa);
    // }

    // [HttpPost("excluir/{id:int}")]
    // public async Task<IActionResult> ExcluirPost(int id)
    // {
    //     // if (AcoesProibidas)
    //     //     return RedirectToAction("/");

    //     await _tarefaRepository.ExcluirAsync(id);
    //     return RedirectToAction(nameof(Index));
    // }

    // [HttpGet("editar/{id:int}")]
    // public async Task<IActionResult> EditarGet(int id)
    // {
    //     // if (AcoesProibidas)
    //     //     return RedirectToAction("/");

    //     var opcao = await _tarefaRepository.BuscarPorIdAsync(id);

    //     if (opcao == null)
    //         return NotFound();

    //     return View("_editar");
    // }
}