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
            var usuarios = _dbContext.Usuarios.ToList();
            // var users = new List<Usuario>();
            // users.Add(new Usuario { Id = 1, Login = "Bakumito"});
            // users.Add(new Usuario { Id = 5, Login = "teste"});
            return usuarios.Where(x => x.Login.ToLower() == login.ToLower() && x.Senha == x.Senha).FirstOrDefault();
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