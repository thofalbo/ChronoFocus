namespace Core.Models;
public class Permissao
{
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public int IdControlador { get; set; }
    public int IdAcao { get; set; }
    public bool Acesso { get; set; }
    public Usuario Usuario { get; set; }
    public Controlador Controlador { get; set; }
    public Acao Acao { get; set; }
}