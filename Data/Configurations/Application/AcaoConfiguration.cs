namespace Data.Configurations.Application;
public class AcaoConfiguration : IEntityTypeConfiguration<Acao>
{
    public void Configure(EntityTypeBuilder<Acao> builder)
    {
        builder.ToTable("acao", "dbo");

        builder.HasKey(x => x.Id).HasName("pk_acao");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.Nome).HasColumnName("nome");
        builder.Property(x => x.IdControlador).HasColumnName("id_controlador");

        builder.HasOne(x => x.Controlador).WithMany(x => x.Acoes).HasForeignKey(x => x.IdControlador).HasConstraintName("fk_acao_controlador");;
        builder.HasMany(x => x.Permissoes).WithOne(x => x.Acao);
    }
}