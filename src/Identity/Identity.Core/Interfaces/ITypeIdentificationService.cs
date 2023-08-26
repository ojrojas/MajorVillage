﻿namespace Identity.Core.Interfaces;

public interface ITypeIdentificationService
{
    ValueTask<CreateTypeIdentificationResponse> CreateTypeIdentificationAsync(CreateTypeIdentificationRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteTypeIdentificationResponse> DeleteTypeIdentificationAsync(DeleteTypeIdentificationRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllTypeIdentificationResponse> GetAllTypeIdentificationAsync(GetAllTypeIdentificationRequest request, CancellationToken cancellationToken);
    ValueTask<GetTypeIdentificationByIdResponse> GetTypeIdentificationByIdAsync(GetTypeIdentificationByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateTypeIdentificationResponse> UpdateTypeIdentificationAsync(UpdateTypeIdentificationRequest request, CancellationToken cancellationToken);
}