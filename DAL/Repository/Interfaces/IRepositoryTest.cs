using DAL.Entities;

namespace DAL.Repository.Interfaces;

public interface IRepositoryTest
{
    List<Test> GetAll();
}