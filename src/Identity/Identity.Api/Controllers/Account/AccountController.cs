using Polly;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Identity.Api.Controllers.Account;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly IUserApplicationService _service;

    public AccountController(IUserApplicationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    public async Task<IActionResult> Login(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;
        await Task.CompletedTask;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginUserApplicationRequest request)
    {
        if(ModelState.IsValid)
        {
           var signin = await _service.LoginAsync(request, default);
            if(signin is not null)
            {
                Console.WriteLine("here to do signin");
                return Redirect(request.ReturnUrl);
            }
        };
        return View(request);
    }
}

