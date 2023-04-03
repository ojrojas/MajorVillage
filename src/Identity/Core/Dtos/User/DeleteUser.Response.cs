﻿namespace Core.Dtos;

public record DeleteUserResponse : BaseResponse
{
	public DeleteUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public bool UserDeleted { get; set; }
}

