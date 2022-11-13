namespace Core.Interfaces
{
    public interface IAddressService
    {
        Task<CreateAddressResponse> CreateAddressAsync(CreateAddressRequest request, CancellationToken cancellationToken);
        Task<DeleteAddressResponse> DeleteAddressAsync(DeleteAddressRequest request, CancellationToken cancellationToken);
        Task<GetAddressByIdResponse> GetAddressByIdAsync(GetAddressByIdRequest request, CancellationToken cancellationToken);
        Task<GetAllAddressResponse> GetAllAddressAsync(GetAllAddressRequest request, CancellationToken cancellationToken);
        Task<UpdateAddressResponse> UpdateAddressAsync(UpdateAddressRequest request, CancellationToken cancellationToken);
    }
}