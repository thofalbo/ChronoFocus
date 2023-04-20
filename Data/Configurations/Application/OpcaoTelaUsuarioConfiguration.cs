namespace Data.Configurations.Application
{
    public class OpcaoTelaUsuarioConfiguration : IEntityTypeConfiguration<OpcaoTelaUsuario>
    {
        public void Configure(EntityTypeBuilder<OpcaoTelaUsuario> builder)
        {
            builder.ToTable("opcao_tela_usuario", "dbo");

            builder.HasKey(x => new { x.IdOpcao, x.IdTela, x.IdUsuario });

            builder.Property(x => x.IdOpcao).HasColumnName("id_opcao");
            builder.Property(x => x.IdTela).HasColumnName("id_tela");
            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");

            builder.HasOne(x => x.Opcao).WithMany(x => x.OpcoesTelaUsuario).HasForeignKey(x => x.IdOpcao);
            builder.HasOne(x => x.Tela).WithMany(x => x.OpcoesTelaUsuario).HasForeignKey(x => x.IdTela);
            builder.HasOne(x => x.Usuario).WithMany(x => x.OpcoesTelaUsuario).HasForeignKey(x => x.IdUsuario);
        }
    }
}