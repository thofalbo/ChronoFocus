namespace Data.Repositories
{
    public class TelaRepository : ITelaRepository
    {
        private readonly AppDbContext _dbContext;

        public TelaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tela>> ListarAsync() => await _dbContext.Telas.ToListAsync();
        public async Task<Tela> ObterPorIdAsync(int id) => await _dbContext.Telas.FindAsync(id);
        public async Task<Tela> ObterPorNomeAsync(string tela) => await _dbContext.Telas.SingleOrDefaultAsync(x => x.Rota == tela);

        public async Task CadastrarAsync(Tela tela)
        {
            _dbContext.Telas.Add(tela);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tela tela)
        {
            _dbContext.Telas.Update(tela);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Tela tela)
        {
            _dbContext.Telas.Remove(tela);
            await _dbContext.SaveChangesAsync();
        }
    }
}