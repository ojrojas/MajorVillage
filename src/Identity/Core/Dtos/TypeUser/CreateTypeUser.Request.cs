﻿namespace Core.Dtos;

public record CreateTypeUserRequest : BaseRequest
{
    public TypeUser TypeUser { get; set; }
}

