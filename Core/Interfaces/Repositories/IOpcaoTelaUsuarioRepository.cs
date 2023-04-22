namespace Core.Interfaces.Repositories;
public interface IOpcaoTelaUsuarioRepository
{
    Task CadastrarAsync(OpcaoTelaUsuario opcaoTelaUsuario);

}