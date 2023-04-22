namespace Data.Repositories;
public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _dbContext;
    public TarefaRepository(AppDbContext dbContext) => _dbContext = dbContext;
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
        var tarefa = await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.Tarefas.Remove(tarefa);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        _dbContext.Tarefas.Update(tarefa);
        await _dbContext.SaveChangesAsync();
    }
    public async Task BuscarAsync(Tarefa tarefa)
    {
        _dbContext.Tarefas.Add(tarefa);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Tarefa> BuscarPorIdAsync(int id) => await _dbContext.Tarefas.FindAsync(id);
}