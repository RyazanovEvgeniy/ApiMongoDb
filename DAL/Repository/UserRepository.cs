using System.Linq.Expressions;

using DAL.Data.Interfaces;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository;

public class UserRepository(IMongoDbContext context) : Repository<User>(context), IUserRepository;