namespace Core.Interfaces.Services;
public interface ITarefaService
{
    Task CadastrarAsync(Tarefa tarefa, int usuarioLogado);
}