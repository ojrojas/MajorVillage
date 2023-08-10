using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Web.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaController : ControllerBase
{

    private readonly ILogger<AreaController> _logger;
    private readonly IAreaService _service;

    public AreaController(ILogger<AreaController> logger, IAreaService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    public async ValueTask<CreateAreaResponse> CreateArea(GrpcSchool.CreateAreaRequest request, CancellationToken cancellationToken)
    {
        return await _service.CreateAreaAsync(request, cancellationToken);
    }
}
