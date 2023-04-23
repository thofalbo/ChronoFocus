namespace Core.Models;
public class Controlador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<Acao> Acoes { get; set; }
    public IEnumerable<Permissao> Permissoes { get; set; }

}