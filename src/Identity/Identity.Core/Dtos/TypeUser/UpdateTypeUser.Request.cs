﻿namespace Identity.Core.Dtos;

public record UpdateTypeUserRequest : BaseRequest
{
    public TypeUser TypeUser { get; set; }
}

