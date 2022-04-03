namespace MajorVillage.Core.Interfaces;

public interface IElectiveYearRepository
{
    Task<Guid> CreateElectiveYear(ElectiveYear electiveYear, CancellationToken cancellationToken);
    Task<bool> DeleteElectiveYear(ElectiveYear electiveYear, CancellationToken cancellationToken);
    Task<ElectiveYear> GetElectiveYearById(Guid id, CancellationToken cancellationToken);
    Task<bool> UpdateElectiveYear(ElectiveYear electiveYear, CancellationToken cancellationToken);
}