namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Usuario>> BuscarUsuariosAsync() => await _dbContext.Usuarios.ToListAsync();

        public async Task<Usuario> BuscarUsuarioAsync(Usuario usuario)
        {
            if (usuario.Login != null && usuario.Senha != null)
                return await _dbContext.Usuarios
                    .AsSingleQuery()
                        .Include(x => x.PermissoesUsuarios)
                        .ThenInclude(p => p.Permissao)
                        .Where(
                            x => x.Login.ToLower() == usuario.Login.ToLower()
                            && x.Senha == usuario.Senha
                        )
                        .FirstOrDefaultAsync();

            else if (usuario.Id != default)
                return await _dbContext.Usuarios
                    .Where(x => x.Email == usuario.Email)
                    .FirstOrDefaultAsync();

            else
                return await _dbContext.Usuarios.FindAsync(usuario.Id);


        }

        public async Task<Usuario> VerificaUsuario(string login, string senha)
        {
            var usuariologado = await _dbContext.Usuarios
                .AsSingleQuery()
                    .Include(x => x.PermissoesUsuarios)
                    .ThenInclude(p => p.Permissao)
                    .Where(
                        x => x.Login.ToLower() == login.ToLower()
                        && x.Senha == senha
                    )
                    .FirstOrDefaultAsync();

            return usuariologado;
        }

        public async Task<Usuario> BuscarUsuarioAsync(string nome)
        {
            var usuario = await _dbContext.Usuarios
                .Where(x => x.Nome.ToLower() == nome.ToLower())
                    .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task CadastrarAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(new Usuario
            {
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCadastro = usuario.DataCadastro.ToUniversalTime()
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
