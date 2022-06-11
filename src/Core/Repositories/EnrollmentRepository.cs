namespace MajorVillage.Core.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    private ILogger<EnrollmentRepository> _logger;
    private readonly IDapperRepository<Enrollment> _repository;

    public EnrollmentRepository(ILogger<EnrollmentRepository> logger, IDapperRepository<Enrollment> repository)
    {
        _logger = logger ?? throw new ArgumentException(nameof(logger));
        _repository = repository ?? throw new ArgumentException(nameof(repository));
    }

    public async Task<Guid> CreateEnrollment(Enrollment enrollment, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Create enrollment {enrollment}");
        return await _repository.InsertAsync(entity: enrollment, cancellationToken: cancellationToken);
    }

    public async Task<Enrollment> GetEnrollmentById(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get enrollment by id {id}");
        IPredicate predicate = Predicates.Field<Enrollment>(e => e.Id, Operator.Eq, id);
        return await _repository.GetByIdAsync(predicate, cancellationToken);
    }

    public async Task<bool> UpdateEnrollment(Enrollment enrollment, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Update enrollment params {enrollment}");
        return await _repository.UpdateAsync(enrollment, cancellationToken);
    }

    public async Task<bool> DeleteEnrollment(Enrollment enrollment, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Delete enrollment {enrollment}");
        return await _repository.DeleteAsync(enrollment, cancellationToken);
    }
}