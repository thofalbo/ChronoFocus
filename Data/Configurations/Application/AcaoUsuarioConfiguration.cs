namespace Data.Configurations.Application;
public class AcaoUsuarioConfiguration : IEntityTypeConfiguration<AcaoUsuario>
{
    public void Configure(EntityTypeBuilder<AcaoUsuario> builder)
    {
        builder.ToTable("acao_usuario", "dbo");

        builder.HasKey(x => new { x.IdAcao, x.IdUsuario }).HasName("pk_acao_usuario");

        builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");
        builder.Property(x => x.IdAcao).HasColumnName("id_acao");

        builder.HasOne(x => x.Acao).WithMany(x => x.AcaoUsuarios).HasForeignKey(x => x.IdAcao).HasConstraintName("fk_acao_usuario_acao");
        builder.HasOne(x => x.Usuario).WithMany(x => x.AcaoUsuarios).HasForeignKey(x => x.IdUsuario).HasConstraintName("fk_acao_usuario_usuario");
    }
}