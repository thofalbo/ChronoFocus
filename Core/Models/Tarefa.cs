namespace Core.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Atividade { get; set; }
        public string TipoAtividade { get; set; }
        public string Plataforma { get; set; }
        public TimeSpan TempoTarefa { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public Usuario Usuario { get; set; }
    }
}