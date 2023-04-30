namespace Core.Interfaces.Services
{
    public interface IPermissaoUsuarioService
    {
        Task EditarPermissoesAsync(PermissoesDto permissoes);
    }
}
