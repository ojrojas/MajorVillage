namespace Identity.Api.GroupsEndpoints;

public static class TypeIdentificationGroupRoute
{
    public static RouteGroupBuilder AddTypeIdentificationGroupRoute(this RouteGroupBuilder group)
    {
        group.WithTags("TypeIdentificationEndpoints");
        GetAllTypeIdentifications(group);
        CreateTypeIdentification(group);
        GetTypeIdentificationById(group);
        UpdateTypeIdentification(group);
        DeleteTypeIdentification(group);

        return group;
    }

    private static RouteHandlerBuilder DeleteTypeIdentification(RouteGroupBuilder group)
    {
        return
                group.MapDelete("DeleteTypeIdentification/{Id}", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeIdentificationService _service, [FromRoute] Guid Id, CancellationToken cancellationToken) =>
                {
                    return await _service.DeleteTypeIdentificationAsync(new DeleteTypeIdentificationRequest { Id = Id }, cancellationToken);
                }).WithDescription("Delete type identification")
                .WithSummary("Delete type identification")
                .Produces(200, typeof(DeleteTypeIdentificationResponse));
    }

    private static RouteHandlerBuilder UpdateTypeIdentification(RouteGroupBuilder group)
    {
        return
                group.MapPatch("UpdateTypeIdentification", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeIdentificationService _service, [FromBody] UpdateTypeIdentificationRequest request, CancellationToken cancellationToken) =>
                {
                    return await _service.UpdateTypeIdentificationAsync(request, cancellationToken);
                }).WithSummary("Update type ideitification")
                .WithDescription("Update type identification")
                .Produces(200, typeof(UpdateTypeIdentificationResponse));
    }

    private static RouteHandlerBuilder GetTypeIdentificationById(RouteGroupBuilder group)
    {
        return
                group.MapGet("GetTypeIdentificationById/{Id}", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeIdentificationService _service, [FromRoute] Guid Id, CancellationToken cancellationToken) =>
                {
                    return await _service.GetTypeIdentificationByIdAsync(new GetTypeIdentificationByIdRequest { Id = Id }, cancellationToken);
                }).WithSummary("Get type identification by id")
                .WithDescription("Get type identificatio by id")
                .Produces(200, typeof(GetTypeIdentificationByIdResponse));
    }

    private static RouteHandlerBuilder CreateTypeIdentification(RouteGroupBuilder group)
    {
        return
                group.MapPost("CreateTypeIdentification",
                    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeIdentificationService _service, [FromBody] CreateTypeIdentificationRequest request, CancellationToken cancellationToken) =>
                    {
                        await _service.CreateTypeIdentificationAsync(request, cancellationToken);
                    })
                    .WithSummary("Create type idenfication")
                    .WithDescription("Create type identification");
    }

    private static RouteHandlerBuilder GetAllTypeIdentifications(RouteGroupBuilder group)
    {
        return
                group.MapGet("GetAllTypeIdentifications",
                    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeIdentificationService _service, CancellationToken cancellationToken) =>
                    {
                        return await _service.GetAllTypeIdentificationAsync(new(), cancellationToken);
                    })
                    .WithSummary("Get all type identifications")
                    .WithDescription("Get all type identifications")
                    .Produces(200, typeof(GetAllTypeIdentificationResponse));
    }
}

