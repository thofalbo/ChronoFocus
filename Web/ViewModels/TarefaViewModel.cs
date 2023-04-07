namespace Web.ViewModels
{
    public class TarefaViewModel
    {
        public int IdUsuario { get; set; }
        public string Atividade { get; set; }
        public string? TipoAtividade { get; set; }
        public string? Plataforma { get; set; }
        public DateTime TempoTarefa { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public TarefaViewModel(){}

        public TarefaViewModel(Tarefa tarefa){
            IdUsuario = 1;
            Atividade = tarefa.Atividade;
            TipoAtividade = tarefa.TipoAtividade;
            Plataforma = tarefa.Plataforma;
            TempoTarefa = new DateTime(1990, 04, 07, 0, 0, 0, 0, 0).ToUniversalTime();
            DataCadastro = new DateTime(2023, 04, 07, 0, 0, 0, 0, 0).ToUniversalTime();
        }
    }
}