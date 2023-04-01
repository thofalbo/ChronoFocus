namespace Data
{
    public class BaseDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            // modelBuilder.Entity<ModelName>().ToTable("table_name");
        }
    }
}