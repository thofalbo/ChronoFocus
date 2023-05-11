namespace Data.Configurations.Application
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tarefa", "dbo");

            builder.HasKey(x => x.Id).HasName("pk_tarefa");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");
            builder.Property(x => x.Atividade).HasColumnName("atividade");
            builder.Property(x => x.TipoAtividade).HasColumnName("tipo_atividade");
            builder.Property(x => x.Plataforma).HasColumnName("plataforma");
            builder.Property(x => x.TempoTarefa).HasColumnName("tempo_tarefa");
            builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Tarefas).HasForeignKey(x => x.IdUsuario).HasConstraintName("fk_usuario_tarefa"); ;
        }
    }
}
