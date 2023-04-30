namespace Core.Models;
public class PermissaoUsuario
{
    public int IdPermissao { get; set; }
    public int IdUsuario { get; set; }

    public Acao Acao { get; set; }
    public Usuario Usuario { get; set; }
}
    // public DateTime DataCadastro { get; set; }
    // public int UsuarioCadastro { get; set; }