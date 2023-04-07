namespace Data.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartamentoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CadastrarAsync(DepartamentoCadastroDto departamentoCadastroDto)
        {
            await _dbContext.Departamentos.AddAsync(new Departamento{
                Nome = departamentoCadastroDto.Nome
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            await _dbContext.Database.ExecuteSqlRawAsync(
                $@"DELETE FROM dbo.departamento WHERE id = {id};");
        }

        public async Task EditarAsync(DepartamentoCadastroDto departamentoCadastroDto)
        {
            _dbContext.Departamentos.Update(new Departamento{
                Nome = departamentoCadastroDto.Nome
            });
            await _dbContext.SaveChangesAsync();
        }

    }
}