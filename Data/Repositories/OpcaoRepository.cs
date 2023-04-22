namespace Data.Repositories
{
    public class OpcaoRepository : IOpcaoRepository
    {
        private readonly AppDbContext _dbContext;

        public OpcaoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Opcao>> ListarAsync() => await _dbContext.Opcoes.ToListAsync();
        public async Task<Opcao> ObterPorIdAsync(int id) => await _dbContext.Opcoes.FindAsync(id);
        public async Task<Opcao> ObterPorNomeAsync(string opcao) => await _dbContext.Opcoes.SingleOrDefaultAsync(x => x.Rota == opcao);

        public async Task CadastrarAsync(Opcao opcao)
        {
            _dbContext.Opcoes.Add(opcao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Opcao opcao)
        {
            _dbContext.Opcoes.Update(opcao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Opcao opcao)
        {
            _dbContext.Opcoes.Remove(opcao);
            await _dbContext.SaveChangesAsync();
        }
    }
}