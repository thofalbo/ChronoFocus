namespace Web.ViewModels;
public class OpcaoTelaUsuarioViewModel
{
    public OpcaoTelaUsuario OpcaoTelaUsuario { get; set; }
    public IEnumerable<Opcao> Opcoes { get; set; }
    public IEnumerable<Tela> Telas { get; set; }
    public IEnumerable<Usuario> Usuarios { get; set; }
}