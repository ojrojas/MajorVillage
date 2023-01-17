namespace Api.Endpoints
{
    [ApiController]
    [Route("api/[controller]")]
    public class Index : EndpointBaseAsync.WithoutRequest.WithActionResult
    {
        [HttpPost]
        [Produces(typeof(string))]
        [SwaggerOperation(
        Summary = "Home",
        Description = "Index",
        OperationId = "home.index",
        Tags = new[] { "HomeEndpoints" })]
        public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            return Ok("API Status Ok");
        }
    }
}
