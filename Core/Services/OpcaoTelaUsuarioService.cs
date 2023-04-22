namespace Core.Services;
public class OpcaoTelaUsuarioService : IOpcaoTelaUsuarioService
{
    private readonly IOpcaoTelaUsuarioRepository _opcaoTelaUsuarioRepository;
    private readonly IOpcaoRepository _opcaoRepository;
    private readonly ITelaRepository _telaRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public OpcaoTelaUsuarioService(
        IOpcaoTelaUsuarioRepository opcaoTelaUsuarioRepository,
        IOpcaoRepository opcao,
        ITelaRepository tela,
        IUsuarioRepository usuarioRepository
    )
    {
        _opcaoTelaUsuarioRepository = opcaoTelaUsuarioRepository;
        _opcaoRepository = opcao;
        _telaRepository = tela;
        _usuarioRepository = usuarioRepository;
    }
    public async Task<IEnumerable<OpcaoTelaUsuario>> ListarAsync() => await _opcaoTelaUsuarioRepository.ListarAsync();
    
    public async Task<OpcaoTelaUsuarioDto> MostrarOpcaoTelaUsuarioDtoAsync()
    {
        var dto = new OpcaoTelaUsuarioDto();
        dto.Opcoes = await _opcaoRepository.ListarAsync();
        dto.Telas = await _telaRepository.ListarAsync();
        dto.Usuarios = await _usuarioRepository.ListarAsync();

        return dto;
    }

    // public async Task<OpcaoTelaUsuario> ObterPorIdAsync(int id) => await _opcaoTelaUsuarioRepository.ObterPorIdAsync(id);

    public async Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario) 
    // {
    //     var opcaoTelaUsuarioExistente = await _opcaoTelaUsuarioRepository.ObterPorNomeAsync(opcaoTelaUsuario.Rota);
    //     if (opcaoTelaUsuarioExistente != null)
    //     {
    //         throw new InvalidOperationException("Já existe uma opção com esse nome.");
    //     }

    //     await _opcaoTelaUsuarioRepository.CadastrarAsync(opcaoTelaUsuario);
    // }
    {
        // var opcao = await _opcaoRepository.ObterPorIdAsync(opcaoTelaUsuarioDto.IdOpcao);
        // var tela = await _telaRepository.ObterPorIdAsync(opcaoTelaUsuarioDto.IdTela);
        // var usuario = await _usuarioRepository.ObterPorIdAsync(opcaoTelaUsuarioDto.IdUsuario);

        // var opcaoTelaUsuario = new OpcaoTelaUsuario
        // {
        //     Opcao = opcao,
        //     Tela = tela,
        //     Usuario = usuario
        // };

        await _opcaoTelaUsuarioRepository.CadastrarAsync(opcaoTelaUsuario);
    }

    // public async Task AtualizarAsync(OpcaoTelaUsuario opcaoTelaUsuario)
    // {
    //     var opcaoTelaUsuarioExistente = await _opcaoTelaUsuarioRepository.ObterPorNomeAsync(opcaoTelaUsuario.Rota);
    //     if (opcaoTelaUsuarioExistente != null && opcaoTelaUsuarioExistente.Id != opcaoTelaUsuario.Id)
    //     {
    //         throw new InvalidOperationException("Já existe uma opção com esse nome.");
    //     }

    //     await _opcaoTelaUsuarioRepository.AtualizarAsync(opcaoTelaUsuario);
    // }
}