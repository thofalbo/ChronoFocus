namespace Core.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IVendedorRepository _vendedorRepository;

        public DepartamentoService(
            IDepartamentoRepository departamentoRepository,
            IVendedorRepository vendedorRepository
        )
        {
            _departamentoRepository = departamentoRepository;
            _vendedorRepository = vendedorRepository;
        }

        public async Task ExcluirAsync(int id)
        {
            var filtro = await _vendedorRepository.BuscarVendedorDepartamento(id);
            if (filtro == null)
            {
                await _departamentoRepository.ExcluirAsync(id);
            }
        }
    }
}