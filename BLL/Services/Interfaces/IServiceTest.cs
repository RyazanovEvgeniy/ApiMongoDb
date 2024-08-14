using DAL.Entities;

namespace BLL.Services.Interfaces;

public interface IServiceTest
{
    List<Test> GetAll();
}