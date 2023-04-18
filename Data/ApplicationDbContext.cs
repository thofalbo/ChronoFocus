namespace Data
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(AppSettings appSettings) : base(appSettings, "Application")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}