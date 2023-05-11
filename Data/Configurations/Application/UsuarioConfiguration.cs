namespace Data.Configurations.Application
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "dbo");

            builder.HasKey(x => x.Id).HasName("pk_usuario");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Login).HasColumnName("login");
            builder.Property(x => x.Senha).HasColumnName("senha");
            builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");

            builder.HasMany(x => x.Tarefas).WithOne(x => x.Usuario);
            builder.HasMany(x => x.PermissoesUsuarios).WithOne(x => x.Usuario);
        }
    }
}
