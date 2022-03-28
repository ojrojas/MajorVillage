namespace MajorVillage.Core.Repositories;



public class UserApplicationRepository : IUserApplicationRepository
{
    private readonly IDapperRepository<UserApplication> _repository;
    private readonly ILogger<UserApplicationRepository> _logger;
    private readonly IEncryptPassFunctionality _crypt;

    public UserApplicationRepository(IDapperRepository<UserApplication> repository,
                                     ILogger<UserApplicationRepository> logger,
                                     IEncryptPassFunctionality crypt)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _crypt = crypt ?? throw new ArgumentNullException(nameof(crypt));
    }

    public async Task<Guid> CreateUserApplication(UserApplication userApplication, CancellationToken cancellationToken)
    {
        userApplication.Password = await _crypt.Encrypt(userApplication.Password);
        return await _repository.InsertAsync(userApplication, cancellationToken);
    }

    public async Task<UserApplication> LoginAsync(UserApplication userApplication, CancellationToken cancellationToken)
    {
        userApplication.Password = await _crypt.Encrypt(userApplication.Password);
         PredicateGroup pg = new() { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
        pg.Predicates.Add(Predicates.Field<UserApplication>(u=> u.UserName, Operator.Eq, userApplication.UserName));
        pg.Predicates.Add(Predicates.Field<UserApplication>(p=> p.Password, Operator.Eq, userApplication.Password));
        var result =  await _repository.GetAllAsync(pg, cancellationToken);
        return result.FirstOrDefault();
    }
}