namespace Data.Repositories.Base;
public class DbTransaction : IDbTransaction
{
    private readonly IDbContextTransaction _dbContextTransaction;

    public DbTransaction(IDbContextTransaction dbContextTransaction) => _dbContextTransaction = dbContextTransaction;
    public async Task CommitAsync() => await _dbContextTransaction.CommitAsync();

    public void Commit() => _dbContextTransaction.Commit();

    public async Task RollbackAsync() => await _dbContextTransaction.RollbackAsync();

    public void Rollback() => _dbContextTransaction.Rollback();
}