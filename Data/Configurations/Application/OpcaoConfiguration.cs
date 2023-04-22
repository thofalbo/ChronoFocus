namespace Data.Configurations.Application;
public class OpcaoConfiguration : IEntityTypeConfiguration<Opcao>
{
    public void Configure(EntityTypeBuilder<Opcao> builder)
    {
        builder.ToTable("opcao", "dbo");

        builder.HasKey(x => x.Id).HasName("pk_opcao");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.Rota).HasColumnName("rota");

        builder.HasMany(x => x.OpcoesTelaUsuario).WithOne(x => x.Opcao);
    }
}