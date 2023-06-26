namespace Identity.Api.Controllers;

[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IIdentityServerInteractionService _interaction;

    public HomeController(IIdentityServerInteractionService interaction)
    {
        _interaction = interaction ?? throw new ArgumentNullException(nameof(interaction));
    }

    [HttpGet("Error")]
    public async Task<ErrorViewModel> Error(string errorId)
    {
        var vm = new ErrorViewModel();

        // retrieve error details from identityserver
        var message = await _interaction.GetErrorContextAsync(errorId);
        if (message != null)
        {
            vm.Error = message;
        }

        return  vm;
    }
}

