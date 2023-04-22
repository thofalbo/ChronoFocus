namespace Core.Models;
public class Opcao
{
    public int Id { get; set; }
    public string Rota { get; set; }
    public IEnumerable<OpcaoTelaUsuario> OpcoesTelaUsuario { get; set; }

}