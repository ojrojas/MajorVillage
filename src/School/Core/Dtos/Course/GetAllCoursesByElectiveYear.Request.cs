﻿namespace Core.Dtos;

public record GetAllCoursesByElectiveYearRequest: BaseRequest
{
	public Guid ElectiveYearId { get; set; }
}

