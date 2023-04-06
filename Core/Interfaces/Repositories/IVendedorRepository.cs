namespace Core.Interfaces.Repositories
{
    public interface IVendedorRepository
    {
        Task<Vendedor> BuscarVendedorDepartamento(int idDepartamento);
    }
}