namespace Data.Repositories
{
    public class PermissaoUsuarioRepository : IPermissaoUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Notification _notification;

        public PermissaoUsuarioRepository(ApplicationDbContext dbContext, Notification notification)
        {
            _dbContext = dbContext;
            _notification = notification;
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

        public async Task EditarPermissoesAsync(IEnumerable<PermissaoDto> permitidos)
        {
            var permissoesUsuario = await _dbContext.PermissoesUsuarios.ToListAsync();

            var AdicionarPermissoesAsync = permitidos
                .Where(permissao => permissao.TemPermissao && !permissoesUsuario
                    .Any(x => x.IdUsuario == permissao.IdUsuario && x.IdPermissao == permissao.IdPermissao))
                .Select(permissao => new PermissaoUsuario
                {
                    IdPermissao = permissao.IdPermissao,
                    IdUsuario = permissao.IdUsuario
                })
                .ToList();

            var RemoverPermissoesAsync = permitidos
                .Where(permissao => !permissao.TemPermissao && permissoesUsuario
                    .Any(x => x.IdUsuario == permissao.IdUsuario && x.IdPermissao == permissao.IdPermissao))
                .Select(permissao => new PermissaoUsuario
                {
                    IdPermissao = permissao.IdPermissao,
                    IdUsuario = permissao.IdUsuario
                })
                .ToList();

            if (!RemoverPermissoesAsync.Any() && !AdicionarPermissoesAsync.Any())
            {
                _notification.Add("Nenhuma alteração feita");
                return;
            }

            _dbContext.PermissoesUsuarios.RemoveRange(RemoverPermissoesAsync);
            await _dbContext.PermissoesUsuarios.AddRangeAsync(AdicionarPermissoesAsync);

            await _dbContext.SaveChangesAsync();
            _notification.Add("Permissões editadas com sucesso");
        }
    }
}
