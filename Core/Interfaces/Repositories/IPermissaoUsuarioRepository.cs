namespace Core.Interfaces.Repositories
{
    public interface IPermissaoUsuarioRepository
    {
        Task EditarPermissoesAsync(IEnumerable<PermissaoDto> permitidos);
    }
}
