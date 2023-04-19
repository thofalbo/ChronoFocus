namespace Web.ViewModels;

public class ErrorViewModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !RequestId.IsNullOrEmpty();
}
