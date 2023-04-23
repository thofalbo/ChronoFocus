namespace Data.Configurations.Application;
public class ControladorConfiguration : IEntityTypeConfiguration<Controlador>
{
    public void Configure(EntityTypeBuilder<Controlador> builder)
    {
        builder.ToTable("controlador", "dbo");

        builder.HasKey(x => x.Id).HasName("pk_controlador");

        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
        builder.Property(x => x.Nome).HasColumnName("nome");

        builder.HasMany(x => x.Acoes).WithOne(x => x.Controlador);
        builder.HasMany(x => x.Permissoes).WithOne(x => x.Controlador);
    }
}
