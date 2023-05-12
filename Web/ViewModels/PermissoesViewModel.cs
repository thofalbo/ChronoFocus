namespace Web.ViewModels
{
    public class PermissoesViewModel
    {
        public IEnumerable<PermissaoDto> Permitidos { get; set; }
        
        public bool IsValid(Notification notification)
        {
            if (Permitidos == null)
                notification.Add("Nenhuma alteração feita", NotificationTypeEnum.Success);
            
            return !notification.Any();
        }
    }
}
