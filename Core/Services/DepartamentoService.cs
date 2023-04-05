using Core.Dto.Departamento;

namespace Core.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        
        public async Task CadastrarAsync(Departamento departamento)
        {
            await _departamentoRepository.CadastrarAsync(new DepartamentoCadastroDto{
                Nome = departamento.Nome
            });
        }
    }
}