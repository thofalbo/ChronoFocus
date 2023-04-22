namespace Core.Services;
public class TelaService : ITelaService
{
    private readonly ITelaRepository _telaRepository;

    public TelaService(ITelaRepository telaRepository) => _telaRepository = telaRepository;

    public async Task<IEnumerable<Tela>> ListarAsync() => await _telaRepository.ListarAsync();

    public async Task<Tela> ObterPorIdAsync(int id) => await _telaRepository.ObterPorIdAsync(id);

    public async Task CadastrarAsync(Tela tela) 
    {
        // Example of additional business logic: ensure tela.Nome is unique
        var telaExistente = await _telaRepository.ObterPorNomeAsync(tela.Rota);
        if (telaExistente != null)
        {
            throw new InvalidOperationException("Já existe uma opção com esse nome.");
        }

        await _telaRepository.CadastrarAsync(tela);
    }

    public async Task AtualizarAsync(Tela tela)
    {
        // Example of additional business logic: ensure tela.Nome is unique
        var telaExistente = await _telaRepository.ObterPorNomeAsync(tela.Rota);
        if (telaExistente != null && telaExistente.Id != tela.Id)
        {
            throw new InvalidOperationException("Já existe uma opção com esse nome.");
        }

        await _telaRepository.AtualizarAsync(tela);
    }
}