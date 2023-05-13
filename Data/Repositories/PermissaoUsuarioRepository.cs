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

        public async Task EditarPermissoesAsync(IEnumerable<PermissaoDto> permitidos)
        {
            var permissoesUsuario = await _dbContext.PermissoesUsuarios.ToListAsync();

            var permissoesAdicionar = permitidos
                .Where(p => p.TemPermissao && !permissoesUsuario
                    .Any(pu => pu.IdUsuario == p.IdUsuario && pu.IdPermissao == p.IdPermissao))
                .Select(p => new PermissaoUsuario
                {
                    IdPermissao = p.IdPermissao,
                    IdUsuario = p.IdUsuario
                });

            var permissoesRemover = permitidos
                .Where(p => !p.TemPermissao && permissoesUsuario
                    .Any(pu => pu.IdUsuario == p.IdUsuario && pu.IdPermissao == p.IdPermissao))
                .Select(p => new PermissaoUsuario
                {
                    IdPermissao = p.IdPermissao,
                    IdUsuario = p.IdUsuario
                });

            if (!(permissoesRemover.Any() || permissoesAdicionar.Any()))
            {
                _notification.Add("Nenhuma alteração feita");
                return;
            }

            _dbContext.PermissoesUsuarios.RemoveRange(permissoesRemover);
            await _dbContext.PermissoesUsuarios.AddRangeAsync(permissoesAdicionar);

            await _dbContext.SaveChangesAsync();
            _notification.Add("Permissões editadas com sucesso");
        }
    }
}
