﻿namespace Core.Dtos;

public record DeleteTypeUserResponse : BaseResponse
{
	public DeleteTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUserDeleted { get; set; }
}

