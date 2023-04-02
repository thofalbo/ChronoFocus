namespace Core.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public Departamento Departamento { get; set; }
    }
}