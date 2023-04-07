namespace Core.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        Task CadastrarAsync(Tarefa tarefa);
    }
}