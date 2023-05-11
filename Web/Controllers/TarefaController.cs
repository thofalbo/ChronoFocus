namespace Web.Controllers;
[Route("tarefa")]
public class TarefaController : AuthenticatedController
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ITarefaService _tarefaService;
    public TarefaController(ITarefaRepository tarefaRepository, ITarefaService tarefaService)
    {
        _tarefaRepository = tarefaRepository;
        _tarefaService = tarefaService;
    }

    [HttpGet("inicio")]
    public async Task<IActionResult> Index() => View(await _tarefaRepository.BuscarTarefasAsync(IdUsuarioLogado));

    [HttpGet("cadastrar")]
    public IActionResult CadastrarGet()
    {
        return View("_cadastrar");
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarPost(Tarefa tarefa)
    {
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
