namespace Data;
public class AppDbContext : BaseDbContext
{
    public AppDbContext(AppSettings appSettings) : base(appSettings, "Application") {}

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<OpcaoTelaUsuario> OpcoesTelaUsuario { get; set; }
    public DbSet<Opcao> Opcoes { get; set; }
    public DbSet<Tela> Telas { get; set; }
}