namespace Core.Interfaces.Repositories;
public interface IPermissaoRepository
{
     Task<IEnumerable<Permissao>> ListarAsync();
     Task<IEnumerable<Permissao>> ListarPorFuncionarioAsync(string nomeFuncionario);
     Task EditarPermissoesAsync(IEnumerable<Permissao> permitidos);

}