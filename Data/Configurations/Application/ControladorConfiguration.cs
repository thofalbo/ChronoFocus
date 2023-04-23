namespace Data.Configurations.Application;
public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("funcionario", "dbo");

        builder.HasKey(x => x.Id).HasName("pk_funcionario");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.Nome).HasColumnName("nome");
        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Apelido).HasColumnName("apelido");
        builder.Property(x => x.Senha).HasColumnName("senha");
        builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");
        builder.Property(x => x.Nome).HasColumnName("nome");
        builder.Property(x => x.Nome).HasColumnName("nome");

        builder.HasMany(x => x.Permissoes).WithOne(x => x.Funcionario);
    }
}