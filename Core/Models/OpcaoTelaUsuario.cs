namespace Core.Models
{
    public class OpcaoTelaUsuario
    {
        public int IdOpcao { get; set; }
        public int IdTela { get; set; }
        public int IdUsuario { get; set; }
        public Opcao Opcao { get; set; }
        public Tela Tela { get; set; }
        public Usuario Usuario { get; set; }
    }
}