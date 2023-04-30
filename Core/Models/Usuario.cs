namespace Core.Models;
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime DataCadastro { get; set; }

    public IEnumerable<Tarefa> Tarefas { get; set; }
    public IEnumerable<AcaoUsuario> AcaoUsuarios { get; set; }
}