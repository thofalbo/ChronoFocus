namespace Data;
public class AppDbContext : BaseDbContext
{
    public AppDbContext(AppSettings appSettings) : base(appSettings, "Application") {}

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Acao> Acoes { get; set; }
    public DbSet<AcaoUsuario> AcaoUsuarios { get; set; }
}