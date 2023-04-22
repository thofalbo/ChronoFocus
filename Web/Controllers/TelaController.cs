namespace Web.Controllers;
[Route("tela")]
public class TelaController : AuthenticatedController
{
    private readonly ITelaService _telaService;
    private readonly ITelaRepository _telaRepository;
    private readonly AppDbContext _dbContext;

    public TelaController
    (
        ITelaService telaService,
        ITelaRepository telaRepository,
        AppDbContext dbContext
    )
    {
        _telaService = telaService;
        _telaRepository = telaRepository;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var telas = await _telaService.ListarAsync();
        return View(telas);
    }

    [HttpGet("cadastrar")]
    public IActionResult CadastrarGet() => View("_cadastrar");

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar(TelaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View("_cadastrar", viewModel);

        await _telaService.CadastrarAsync(viewModel.Tela);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:int}")]
    public async Task<IActionResult> EditarGet(int id)
    {
        var tela = await _telaService.ObterPorIdAsync(id);

        if (tela == null)
            return NotFound();

        var viewModel = new TelaViewModel { Tela = tela };

        return View("_editar", viewModel);
    }

    [HttpPost("editar")]
    public async Task<IActionResult> EditarPost(TelaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View("_editar", viewModel);

        var telaExistente = await _telaService.ObterPorIdAsync(viewModel.Tela.Id);

        if (telaExistente == null)
            return NotFound();

        await _telaService.AtualizarAsync(viewModel.Tela);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:int}")]
    public async Task<IActionResult> ExcluirGet(int id)
    {
        var tela = await _telaService.ObterPorIdAsync(id);

        if (tela == null)
            return NotFound();

        var viewModel = new TelaViewModel { Tela = tela };

        return View("_excluir", viewModel);
    }

    [HttpPost("excluir")]
    public async Task<IActionResult> ExcluirPost(TelaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View("_excluir", viewModel);

        var telaExistente = await _telaService.ObterPorIdAsync(viewModel.Tela.Id);

        if (telaExistente == null)
            return NotFound();

        await _telaRepository.ExcluirAsync(telaExistente);

        return RedirectToAction(nameof(Index));
    }
}