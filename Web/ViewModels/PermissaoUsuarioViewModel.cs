namespace Web.ViewModels
{
    public class PermissaoUsuarioViewModel
    {
        public string Nome { get; set; }

        public bool IsValid(Notification notification)
        {
            if (string.IsNullOrEmpty(Nome))
                notification.Add("Nome inválido");
            
            return !notification.Any();
        }
    }
}
