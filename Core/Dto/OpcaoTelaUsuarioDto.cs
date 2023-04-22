namespace Core.Dto;
public class OpcaoTelaUsuarioDto
{
    public OpcaoTelaUsuario OpcaoTelaUsuario { get; set; }
    public IEnumerable<Opcao> Opcoes { get; set; }
    public IEnumerable<Tela> Telas { get; set; }
    public IEnumerable<Usuario> Usuarios { get; set; }
}