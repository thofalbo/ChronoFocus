namespace Core.Models
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Controlador { get; set; }
        public string Rota { get; set; }
        public string Descricao { get; set; }
        public int UsuarioCadastro { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<PermissaoUsuario> PermissoesUsuarios { get; set; }

    }
}
