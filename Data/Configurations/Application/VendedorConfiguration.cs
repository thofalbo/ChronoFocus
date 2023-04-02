namespace Data.Configurations.Application
{
    public class VendedorConfiguration : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("vendedor", "dbo");

            builder.HasKey(x => x.Id).HasName("pk_vendedor");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(x => x.IdDepartamento).HasColumnName("id_departamento");
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento");

            builder.HasOne(x => x.Departamento).WithMany(x => x.Vendedores).HasForeignKey(x => x.IdDepartamento);
        }
    }
}