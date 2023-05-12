namespace Core.Dto
{
    public class PermissoesDto
    {
        public IEnumerable<PermissaoDto> Permitidos { get; set; }
        public List<PermissaoUsuario> Autorizados { get; set; }
        public List<PermissaoUsuario> Negados { get; set; }

    }
}
