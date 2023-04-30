namespace Core.Dto
{
    public class AcaoDto
    {
        public int Id { get; set; }
        public string Controlador { get; set; }
        public string Rota { get; set; }
        public string Descricao { get; set; }
        public int UsuarioCadastro { get; set; }
        public bool TemPermissao { get; set; }
        public int IdUsuario { get; set; }

    }
}