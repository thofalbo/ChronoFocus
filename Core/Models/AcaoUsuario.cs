namespace Core.Models;
public class AcaoUsuario
{
    public int IdAcao { get; set; }
    public int IdUsuario { get; set; }
    // public DateTime DataCadastro { get; set; }
    // public int UsuarioCadastro { get; set; }

    public Acao Acao { get; set; }
    public Usuario Usuario { get; set; }
}