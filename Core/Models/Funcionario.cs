namespace Core.Models;
public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Apelido { get; set; }
    public string Senha { get; set; }
    public DateTime DataCadastro { get; set; }
    public IEnumerable<Permissao> Permissoes { get; set; }
}