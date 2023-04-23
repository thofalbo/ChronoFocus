namespace Data.Configurations.Application;
public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
{
    public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("permissao", "dbo");

            builder.HasKey(x => new { x.IdUsuario, x.IdControlador, x.IdAcao }).HasName("pk_permissao");

            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");
            builder.Property(x => x.IdControlador).HasColumnName("id_controlador");
            builder.Property(x => x.IdAcao).HasColumnName("id_acao");
            builder.Property(x => x.Acesso).HasColumnName("acesso");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Permissoes).HasForeignKey(x => x.IdUsuario).HasConstraintName("fk_permissao_usuario");
            builder.HasOne(x => x.Controlador).WithMany(x => x.Permissoes).HasForeignKey(x => x.IdControlador).HasConstraintName("fk_permissao_controlador");
            builder.HasOne(x => x.Acao).WithMany(x => x.Permissoes).HasForeignKey(x => x.IdAcao).HasConstraintName("fk_permissao_acao");
        }
}