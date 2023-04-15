namespace Core.Interfaces.Services
{
    public interface ITarefaService
    {
        Task CadastrarAsync(Tarefa tarefa, int usuarioLogado);
        IEnumerable<Tarefa> MostrarTarefas(int idUsuario);
        Task ExcluirAsync(int id);
    }
}