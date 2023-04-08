namespace Core.Interfaces.Services
{
    public interface ITarefaService
    {
        Task CadastrarAsync(Tarefa tarefa);
        IEnumerable<Tarefa> MostrarTarefas(int idUsuario);
        Task ExcluirAsync(int id);
    }
}