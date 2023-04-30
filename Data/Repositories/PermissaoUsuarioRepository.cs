namespace Data.Repositories
{
    public class PermissaoUsuarioRepository : IPermissaoUsuarioRepository
    {
        private readonly AppDbContext _dbContext;

        public PermissaoUsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PermissaoUsuario>> ListarAsync()
        {
            return await _dbContext.PermissoesUsuarios
                .Include(p => p.Usuario)
                .Include(p => p.Permissao)
                .ToListAsync();
        }
        public async Task<IEnumerable<PermissaoUsuario>> ListarPorFuncionarioAsync(string nome)
        {
            return await _dbContext.PermissoesUsuarios
                .Include(p => p.Usuario)
                .Include(p => p.Permissao)
                .Where(p => p.Usuario.Nome.Contains(nome))
                .ToListAsync();
        }
        public async Task<bool> ListarAcoesUsuariosAsync(int idPermissao, int idUsuario)
        {
            return await _dbContext.PermissoesUsuarios
                .Where(p => p.IdPermissao == idPermissao && p.IdUsuario == idUsuario)
                .AnyAsync();
        }
        public async Task ExcluirPermissaoAsync(PermissaoUsuario permissao)
        {
            _dbContext.PermissoesUsuarios.Remove(permissao);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AdicionarPermissaoAsync(PermissaoUsuario permissao)
        {
            await _dbContext.PermissoesUsuarios.AddAsync(permissao);
            await _dbContext.SaveChangesAsync();
        }
    }
}
