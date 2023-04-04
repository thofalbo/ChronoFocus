namespace Data
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(AppSettings appSettings) : base(appSettings, "Application")
        {

        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
    }
}