namespace Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TarefaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tarefa> BuscarTarefaUsuarioAsync(int idUsuario)
        {
            return await _dbContext.Usuarios
                .Where(x => x.Id == idUsuario)
                .Select(x => new Tarefa{IdUsuario = x.Id})
                .FirstOrDefaultAsync();
        }
        public IEnumerable<Tarefa> MostrarTarefas(int idUsuario)
        {
            var tarefas = _dbContext.Tarefas.ToList()
                .Where(x => x.IdUsuario == idUsuario);

            return tarefas;
        }
        public async Task CadastrarAsync(Tarefa tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            await _dbContext.Database.ExecuteSqlRawAsync(
                $@"DELETE FROM dbo.tarefa WHERE id = {id};");
        }
    }
}