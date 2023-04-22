namespace Core.Services;
public class OpcaoService : IOpcaoService
{
    private readonly IOpcaoRepository _opcaoRepository;
    private readonly ITelaRepository _telaRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public OpcaoService(
        IOpcaoRepository opcaoRepository,
        ITelaRepository telaRepository,
        IUsuarioRepository usuarioRepository
    )
    {
        _opcaoRepository = opcaoRepository;
        _telaRepository = telaRepository;
        _usuarioRepository = usuarioRepository;
    }
    public async Task<IEnumerable<Opcao>> ListarAsync() => await _opcaoRepository.ListarAsync();

    public async Task<Opcao> ObterPorIdAsync(int id) => await _opcaoRepository.ObterPorIdAsync(id);

    public async Task CadastrarAsync(Opcao opcao) 
    {
        var opcaoExistente = await _opcaoRepository.ObterPorNomeAsync(opcao.Rota);
        if (opcaoExistente != null)
        {
            throw new InvalidOperationException("Já existe uma opção com esse nome.");
        }

        await _opcaoRepository.CadastrarAsync(opcao);
    }

    public async Task AtualizarAsync(Opcao opcao)
    {
        var opcaoExistente = await _opcaoRepository.ObterPorNomeAsync(opcao.Rota);
        if (opcaoExistente != null && opcaoExistente.Id != opcao.Id)
        {
            throw new InvalidOperationException("Já existe uma opção com esse nome.");
        }

        await _opcaoRepository.AtualizarAsync(opcao);
    }
}