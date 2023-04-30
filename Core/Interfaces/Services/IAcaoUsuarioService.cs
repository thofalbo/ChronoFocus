namespace Core.Interfaces.Services
{
    public interface IAcaoUsuarioService
    {
        Task EditarPermissoesAsync(PermissoesDto permissoes);
    }
}