namespace Web.Controllers;
[Route("opcao-tela-usuario")]
public class OpcaoTelaUsuarioController : AuthenticatedController
{
    private readonly IOpcaoTelaUsuarioService _opcaoTelaUsuarioService;
    private readonly IOpcaoTelaUsuarioRepository _opcaoTelaUsuarioRepository;
    private readonly IOpcaoRepository _opcaoRepository;
    private readonly ITelaRepository _telaRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly AppDbContext _dbContext;

    public OpcaoTelaUsuarioController
    (
        IOpcaoTelaUsuarioService opcaoTelaUsuarioService,
        IOpcaoTelaUsuarioRepository opcaoTelaUsuarioRepository,
        AppDbContext dbContext
    )
    {
        _opcaoTelaUsuarioService = opcaoTelaUsuarioService;
        _opcaoTelaUsuarioRepository = opcaoTelaUsuarioRepository;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _opcaoTelaUsuarioRepository.ListarAsync());
    }

    [HttpGet("cadastrar")]
    public async Task<IActionResult> CadastrarGet() => View("_cadastrar", await _opcaoTelaUsuarioService.MostrarOpcaoTelaUsuarioDtoAsync());

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarPost(OpcaoTelaUsuarioDto dto)
    {
        if (ModelState.IsValid)
        {
            var opcaoTelaUsuarioDto = new OpcaoTelaUsuario
            {
                IdOpcao = dto.OpcaoTelaUsuario.IdOpcao,
                IdTela = dto.OpcaoTelaUsuario.IdTela,
                IdUsuario = dto.OpcaoTelaUsuario.IdUsuario
            };

            var opcaoTelaUsuario = new OpcaoTelaUsuario {
                IdOpcao = opcaoTelaUsuarioDto.IdOpcao,
                IdTela = opcaoTelaUsuarioDto.IdTela,
                IdUsuario = opcaoTelaUsuarioDto.IdUsuario
            };

            await _opcaoTelaUsuarioRepository.CadastrarAsync(opcaoTelaUsuario);
            
            return RedirectToAction("Index");
    }

    // If the model state is invalid, return the view with the original DTO to display validation errors
    return View("_cadastrar", dto);
    }

    // [HttpGet("editar/{id:int}")]
    // public async Task<IActionResult> EditarGet(int id)
    // {
    //     var opcaoTelaUsuario = await _opcaoTelaUsuarioService.ObterPorIdAsync(id);

    //     if (opcaoTelaUsuario == null)
    //         return NotFound();

    //     var viewModel = new OpcaoTelaUsuarioViewModel { OpcaoTelaUsuario = opcaoTelaUsuario };

    //     return View("_editar", viewModel);
    // }

    // [HttpPost("editar")]
    // public async Task<IActionResult> EditarPost(OpcaoTelaUsuarioViewModel viewModel)
    // {
    //     if (!ModelState.IsValid)
    //         return View("_editar", viewModel);

    //     var opcaoTelaUsuarioExistente = await _opcaoTelaUsuarioService.ObterPorIdAsync(viewModel.OpcaoTelaUsuario);

    //     if (opcaoTelaUsuarioExistente == null)
    //         return NotFound();

    //     await _opcaoTelaUsuarioService.AtualizarAsync(viewModel.OpcaoTelaUsuario);

    //     return RedirectToAction(nameof(Index));
    // }

    // [HttpGet("excluir/{id:int}")]
    // public async Task<IActionResult> ExcluirGet(int id)
    // {
    //     var opcaoTelaUsuario = await _opcaoTelaUsuarioService.ObterPorIdAsync(id);

    //     if (opcaoTelaUsuario == null)
    //         return NotFound();

    //     var viewModel = new OpcaoTelaUsuarioViewModel { OpcaoTelaUsuario = opcaoTelaUsuario };

    //     return View("_excluir", viewModel);
    // }

    // [HttpPost("excluir")]
    // public async Task<IActionResult> ExcluirPost(OpcaoTelaUsuarioViewModel viewModel)
    // {
    //     if (!ModelState.IsValid)
    //         return View("_excluir", viewModel);

    //     var opcaoTelaUsuarioExistente = await _opcaoTelaUsuarioService.ObterPorIdAsync(viewModel.OpcaoTelaUsuario.Id);

    //     if (opcaoTelaUsuarioExistente == null)
    //         return NotFound();

    //     await _opcaoTelaUsuarioRepository.ExcluirAsync(opcaoTelaUsuarioExistente);

    //     return RedirectToAction(nameof(Index));
    // }
}