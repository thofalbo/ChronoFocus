// namespace Web.Controllers;
// [Route("opcao-tela-usuario")]
// public class OpcaoTelaUsuarioController : AuthenticatedController
// {
//     private readonly IOpcaoTelaUsuarioRepository _opcaoTelaUsuarioRepository;
//     public OpcaoTelaUsuarioController(
//         IOpcaoTelaUsuarioRepository opcaoTelaUsuarioRepository
//     )
//     {
//         _opcaoTelaUsuarioRepository = opcaoTelaUsuarioRepository;
//     }
//     [HttpGet("inicio")]
//     public IActionResult Index() => View();

//     [HttpPost("cadastrar")]
//     public async Task CadastrarOpcaoTelaUsuario(OpcaoTelaUsuario opcaoTelaUsuario) => await _opcaoTelaUsuarioRepository.CadastrarAsync(opcaoTelaUsuario);
// }

// namespace Web.Controllers;
// [Route("opcao-tela-usuario")]
// public class OpcaoTelaUsuarioController : AuthenticatedController
// {
//     private readonly IOpcaoTelaUsuarioRepository _opcaoTelaUsuarioRepository;
//     private readonly IOpcaoRepository _opcaoRepository;
//     private readonly ITelaRepository _telaRepository;
//     private readonly IUsuarioRepository _usuarioRepository;
    
//     public OpcaoTelaUsuarioController(
//         IOpcaoTelaUsuarioRepository opcaoTelaUsuarioRepository,
//         IOpcaoRepository opcaoRepository,
//         ITelaRepository telaRepository,
//         IUsuarioRepository usuarioRepository
//     )
//     {
//         _opcaoTelaUsuarioRepository = opcaoTelaUsuarioRepository;
//         _opcaoRepository = opcaoRepository;
//         _telaRepository = telaRepository;
//         _usuarioRepository = usuarioRepository;
//     }
    
//     [HttpGet("inicio")]
//     public async Task<IActionResult> Index()
//     {
//         var viewModel = new OpcaoTelaUsuarioViewModel
//         {
//             OpcoesTelaUsuario = await _opcaoTelaUsuarioRepository.ListarAsync(),
//             Opcoes = await _opcaoRepository.ListarAsync(),
//             Telas = await _telaRepository.ListarAsync(),
//             Usuarios = await _usuarioRepository.ListarAsync()
//         };
        
//         return View(viewModel);
//     }

//     [HttpPost("cadastrar")]
//     public async Task<IActionResult> CadastrarOpcaoTelaUsuario(OpcaoTelaUsuarioViewModel viewModel)
//     {
//         if (ModelState.IsValid)
//         {
//             await _opcaoTelaUsuarioRepository.CadastrarAsync(viewModel.OpcaoTelaUsuario);
//             return RedirectToAction("Index");
//         }
        
//         viewModel.Opcoes = await _opcaoRepository.ListarAsync();
//         viewModel.Telas = await _telaRepository.ListarAsync();
//         viewModel.Usuarios = await _usuarioRepository.ListarAsync();
        
//         return View("Index", viewModel);
//     }
// }