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

        public async Task EditarPermissoesAsync(IEnumerable<PermissaoUsuario> permitidos, IEnumerable<PermissaoUsuario> negados)
        {
            var AdicionarPermissoesAsync = new List<PermissaoUsuario>();
            var RemoverPermissoesAsync = new List<PermissaoUsuario>();

            var permissoesUsuario = await _dbContext.PermissoesUsuarios
                .Where(x => x.IdUsuario == permitidos.Select(x => x.IdUsuario).FirstOrDefault()
                    || x.IdUsuario == negados.Select(x => x.IdUsuario).FirstOrDefault())
                .ToListAsync();

            foreach (var permissao in negados)
                if (permissoesUsuario.Any(p => p.IdPermissao == permissao.IdPermissao))
                    RemoverPermissoesAsync.Add(permissao);

            foreach (var permissao in permitidos)
                if (!permissoesUsuario.Any(p => p.IdPermissao == permissao.IdPermissao))
                    AdicionarPermissoesAsync.Add(permissao);

            if (RemoverPermissoesAsync.Count() == 0 && AdicionarPermissoesAsync.Count() == 0)
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
