namespace Data.Configurations.Application;
public class AcaoConfiguration : IEntityTypeConfiguration<Acao>
{
    public void Configure(EntityTypeBuilder<Acao> builder)
    {
        builder.ToTable("acao", "dbo");

        builder.HasKey(x => x.Id).HasName("pk_acao");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.Controlador).HasColumnName("controlador");
        builder.Property(x => x.Rota).HasColumnName("rota");
        builder.Property(x => x.Descricao).HasColumnName("descricao");
        builder.Property(x => x.UsuarioCadastro).HasColumnName("usuario_cadastro");
        builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");

        builder.HasMany(x => x.AcaoUsuarios).WithOne(x => x.Acao);
    }
}