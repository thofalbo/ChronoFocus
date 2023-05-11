namespace Core.Helpers
{
    public class Notification
    {
        private readonly Collection<NotificationItem> _notifications;

        public Notification()
        {
            _notifications = new Collection<NotificationItem>();
        }

        public void Add(string message)
        {
            if (_notifications.All(x => x.Message != message || x.Type != NotificationTypeEnum.None))
                _notifications.Add(new NotificationItem(message, NotificationTypeEnum.None));
        }

        public void Add(string message, NotificationTypeEnum type)
        {
            if (_notifications.All(x => x.Message != message || x.Type != type))
                _notifications.Add(new NotificationItem(message, type));
        }

        public void Add(string prefix, string message, NotificationTypeEnum type)
        {
            if (_notifications.All(x => x.Message != message || x.Type != type))
                _notifications.Add(new NotificationItem($"{prefix}: {message}", type));
        }

        public bool Any() => _notifications.Any();
        public bool Any(NotificationTypeEnum type) => _notifications.Any(x => x.Type == type);

        public IEnumerable<string> Get(bool prefixType = false)
            => _notifications.Select(x => prefixType ? $"[{x.Type}] {x.Message}" : x.Message);
        public IEnumerable<string> Get(NotificationTypeEnum type, bool prefixType = false)
            => _notifications.Where(x => x.Type == type).Select(x => prefixType ? $"[{x.Type}] {x.Message}" : x.Message);

        public void Clear() => _notifications.Clear();
    }

    internal class NotificationItem
    {
        public string Message { get; }
        public NotificationTypeEnum Type { get; }

        internal NotificationItem(string message, NotificationTypeEnum type)
        {
            Message = message;
            Type = type;
        }
    }

    public enum NotificationTypeEnum
    {
        None,
        Error,
        Warning,
        Success
    }
}
