namespace Core.Interfaces.Repositories
{
    public interface IDepartamentoRepository
    {
        Task CadastrarAsync(DepartamentoCadastroDto departamentoCadastroDto);
        Task ExcluirAsync(int id);
    }
}