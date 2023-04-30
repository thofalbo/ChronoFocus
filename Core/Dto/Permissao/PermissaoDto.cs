namespace Core.Dto
{
    public class PermissaoDto
    {
        public int IdPermissao { get; set; }
        public int IdUsuario { get; set; }
        public string Controlador { get; set; }
        public string Descricao { get; set; }
        public bool TemPermissao { get; set; }

    }
}