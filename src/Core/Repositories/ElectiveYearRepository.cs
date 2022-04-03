namespace MajorVillage.Core.Repositories;

public class ElectiveYearRepository : IElectiveYearRepository
{
    private readonly IDapperRepository<ElectiveYear> _repository;
    private readonly ILogger<ElectiveYearRepository> _logger;

    public ElectiveYearRepository(IDapperRepository<ElectiveYear> repository,
                                  ILogger<ElectiveYearRepository> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Guid> CreateElectiveYear(ElectiveYear electiveYear, CancellationToken cancellationToken)
    {
        return await _repository.InsertAsync(electiveYear, cancellationToken);
    }

    public async Task<ElectiveYear> GetElectiveYearById(Guid id, CancellationToken cancellationToken)
    {
        IPredicate predicate = Predicates.Field<ElectiveYear>(e => e.Id, Operator.Eq, id);
        return await _repository.GetByIdAsync(predicate, cancellationToken);
    }

    public async Task<bool> UpdateElectiveYear(ElectiveYear electiveYear, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAsync(electiveYear, cancellationToken);
    }

    public async Task<bool> DeleteElectiveYear(ElectiveYear electiveYear, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(electiveYear, cancellationToken);
    }
}