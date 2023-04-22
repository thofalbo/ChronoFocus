namespace Data.Repositories.Base;
public class BaseRepository : IBaseRepository
{
    private readonly DbContext _dbContext;

    public BaseRepository(DbContext dbContext) => _dbContext = dbContext;

    public async Task<IDbTransaction> BeginTransactionAsync() => new DbTransaction(await _dbContext.Database.BeginTransactionAsync());
    
    public IDbTransaction BeginTransaction() => new DbTransaction(_dbContext.Database.BeginTransaction());
}