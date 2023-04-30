namespace Data.Configurations.Application;
public class PermissaoUsuarioConfiguration : IEntityTypeConfiguration<PermissaoUsuario>
{
    public void Configure(EntityTypeBuilder<PermissaoUsuario> builder)
    {
        builder.ToTable("permissao_usuario", "dbo");

        builder.HasKey(x => new { x.IdPermissao, x.IdUsuario }).HasName("pk_permissao_usuario");

        builder.Property(x => x.IdPermissao).HasColumnName("id_permissao");
        builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");

        builder.HasOne(x => x.Permissao).WithMany(x => x.PermissoesUsuarios).HasForeignKey(x => x.IdPermissao).HasConstraintName("fk_permissao_usuario_permissao");
        builder.HasOne(x => x.Usuario).WithMany(x => x.PermissoesUsuarios).HasForeignKey(x => x.IdUsuario).HasConstraintName("fk_permissao_usuario_usuario");
    }
}