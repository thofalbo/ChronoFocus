namespace Core.Interfaces.Repositories;
public interface ITarefaRepository
{
    Task CadastrarAsync(Tarefa tarefa);
    Task<IEnumerable<Tarefa>> BuscarTarefasAsync(int idUsuario);
    Task ExcluirAsync(int id);
    Task AtualizarAsync(Tarefa tarefa);
    Task<Tarefa> BuscarPorIdAsync(int id);
}