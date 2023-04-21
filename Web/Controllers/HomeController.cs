namespace Web.Controllers;

public class HomeController : AuthenticatedController
{
    public IActionResult Index() => View();
}
