using DAL.Repository.Interfaces;

namespace DAL.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
}