﻿namespace School.Core.Dtos;

public record DeleteCourseRequest: BaseRequest
{
    public Guid Id { get; set; }
}
