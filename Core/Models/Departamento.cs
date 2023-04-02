namespace Core.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Vendedor> Vendedores { get; set; }
    }
}