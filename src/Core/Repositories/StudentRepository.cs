namespace MajorVillage.Core.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IDapperRepository<Student> _repository;

    public StudentRepository(IDapperRepository<Student> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<dynamic> CreateStudentAsync(Student student, CancellationToken cancellationToken)
    {
        return await _repository.InsertAsync(student, cancellationToken);
    }

    public async Task<dynamic> CreateStudentsAsync(IEnumerable<Student> students, IDbTransaction transaction, int timeOut, CancellationToken cancellationToken)
    {
        return await _repository.InsertsAsync(students, cancellationToken, transaction, timeOut);
    }
    public async Task<bool> DeleteStudentAsync(Student student, CancellationToken cancellationToken)
    {   
        return await _repository.DeleteAsync(student, cancellationToken);
    }

    public async Task<Student> GetStudentByIdAsync(object id, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Student>> ListStudentAsync(IPredicate predicate, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(predicate, cancellationToken);
    }

    public async Task<bool> UpdateStudentAsync(Student student, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAsync(student,cancellationToken, null, default);
    }
}