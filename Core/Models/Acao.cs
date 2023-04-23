namespace Core.Models;
public class Acao
{
    public int Id { get; set; }
    public int IdControlador { get; set; }
    public string Nome { get; set; }
    public Controlador Controlador { get; set; }
    public IEnumerable<Permissao> Permissoes { get; set; }

}