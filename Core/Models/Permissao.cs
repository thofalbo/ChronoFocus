namespace Core.Models;
public class Permissao
{
    public int IdFuncionario { get; set; }
    public int IdControlador { get; set; }
    public int IdAcao { get; set; }
    public Funcionario Funcionario { get; set; }
    public Controlador Controlador { get; set; }
    public Acao Acao { get; set; }
}