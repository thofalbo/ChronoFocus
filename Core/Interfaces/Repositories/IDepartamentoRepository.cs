using Core.Dto.Departamento;

namespace Core.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task CadastrarAsync(DepartamentoCadastroDto departamentoCadastroDto);
    }
}