namespace MajorVillage.Core.Interfaces;

public interface IElectiveYearRepository
{
    Task<Guid> CreateElectiveYear(ElectiveYear electiveYear, CancellationToken cancellationToken);
    Task<ElectiveYear> GetElectiveYearById(Guid id, CancellationToken cancellationToken);
}