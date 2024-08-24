using DAL.Repository;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork.Interfaces;
using DAL.Data.Interfaces;

namespace DAL.UnitOfWork;

public class UnitOfWork(IMongoDbContext dbContext) : IUnitOfWork
{
    private readonly IMongoDbContext dbContext = dbContext;
    private IUserRepository? userRepository;
    public IUserRepository Users => userRepository ??= new UserRepository(dbContext);
}