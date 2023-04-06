namespace Web.ViewModels
{
    public class DepartamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public DepartamentoViewModel(){}

        public DepartamentoViewModel(Departamento departamento){
            Id = departamento.Id;
            Nome = departamento.Nome;
        }
    }
}