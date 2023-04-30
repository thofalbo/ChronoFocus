namespace Data.Configurations.Application;
public class PermissaoUsuarioConfiguration : IEntityTypeConfiguration<PermissaoUsuario>
{
    public void Configure(EntityTypeBuilder<PermissaoUsuario> builder)
    {
        builder.ToTable("acao_usuario", "dbo");

        builder.HasKey(x => new { x.IdPermissao, x.IdUsuario }).HasName("pk_acao_usuario");

        builder.Property(x => x.IdPermissao).HasColumnName("id_acao");
        builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");

        builder.HasOne(x => x.Acao).WithMany(x => x.AcaoUsuarios).HasForeignKey(x => x.IdPermissao).HasConstraintName("fk_acao_usuario_acao");
        builder.HasOne(x => x.Usuario).WithMany(x => x.AcaoUsuarios).HasForeignKey(x => x.IdUsuario).HasConstraintName("fk_acao_usuario_usuario");
    }
}