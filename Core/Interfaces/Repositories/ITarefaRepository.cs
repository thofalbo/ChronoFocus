namespace Core.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        Task CadastrarAsync(Tarefa tarefa);
        IEnumerable<Tarefa> MostrarTarefas(int idUsuario);
        Task ExcluirAsync(int id);
        // Task<Tarefa> BuscarTarefaUsuarioAsync(int idUsuario);
    }
}