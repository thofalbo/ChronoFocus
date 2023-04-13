namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> Get(string login, string senha)
        {
            return _dbContext.Usuarios.ToList()
                .Where(x => x.Login.ToLower() == login.ToLower() && x.Senha == x.Senha)
                .FirstOrDefault();
        }

        public async Task CadastrarAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(new Usuario
            {
                Login = usuario.Login,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCadastro = usuario.DataCadastro.ToUniversalTime()
            });
            await _dbContext.SaveChangesAsync();
        }
        
    }
}