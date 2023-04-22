namespace Data.Repositories;
public class TarefaRepository : ITarefaRepository
{
    private readonly ApplicationDbContext _dbContext;
    public TarefaRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
    public IEnumerable<Tarefa> MostrarTarefas(int idUsuario)
    {
        var tarefas = _dbContext.Tarefas
            .Include(obj => obj.Usuario)
            .ToList()
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
        _dbContext.Tarefas.Remove(await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id));
        await _dbContext.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        _dbContext.Tarefas.Update(tarefa);
        await _dbContext.SaveChangesAsync();
    }
}