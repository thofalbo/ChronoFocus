namespace Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VendedorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Vendedor> BuscarVendedorDepartamento(int idDepartamento)
        {
            return await _dbContext.Vendedores
                .Where(x => x.IdDepartamento == idDepartamento)
                .Select(x => new Vendedor{Id = x.Id})
                .FirstOrDefaultAsync();
        }
        
    }
}