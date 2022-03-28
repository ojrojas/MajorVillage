namespace MajorVillage.Core.Interfaces;

public interface IStudentRepository
{
    Task<dynamic> CreateStudentAsync(Student student, CancellationToken cancellationToken);
    Task<dynamic> CreateStudentsAsync(IEnumerable<Student> students, IDbTransaction transaction, int timeOut, CancellationToken cancellationToken);
    Task<bool> DeleteStudentAsync(Student student, CancellationToken cancellationToken);
    Task<Student> GetStudentByIdAsync(object id, CancellationToken cancellationToken);
    Task<IEnumerable<Student>> ListStudentAsync(IPredicate predicate, CancellationToken cancellationToken);
    Task<bool> UpdateStudentAsync(Student student, CancellationToken cancellationToken);
}
