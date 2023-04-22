namespace Data.Configurations.Application;
public class TelaConfiguration : IEntityTypeConfiguration<Tela>
{
    public void Configure(EntityTypeBuilder<Tela> builder)
    {
        builder.ToTable("tela", "dbo");

        builder.HasKey(x => x.Id).HasName("pk_tela");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.Rota).HasColumnName("rota");

        builder.HasMany(x => x.OpcoesTelaUsuario).WithOne(x => x.Tela);
    }
}