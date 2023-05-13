namespace Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TarefaRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task CadastrarAsync(Tarefa tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var tarefa = await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Tarefas.Remove(tarefa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            await _dbContext.UpdateEntryAsync<Tarefa>(tarefa.Id, new {
                Atividade = tarefa.Atividade,
                TipoAtividade = tarefa.TipoAtividade,
                Plataforma = tarefa.Plataforma,
                TempoTarefa = tarefa.TempoTarefa
            });
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Tarefa> BuscarPorIdAsync(int id) => await _dbContext.Tarefas.FindAsync(id);

        public async Task<IEnumerable<Tarefa>> BuscarTarefasAsync(int idUsuario)
        {
            var tarefas = await _dbContext.Tarefas
                .Include(obj => obj.Usuario)
                .Where(x => x.IdUsuario == idUsuario)
                .ToListAsync();

            return tarefas;
        }
    }
}
