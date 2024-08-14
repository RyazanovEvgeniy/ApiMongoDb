using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services;

public class ServiceTest : IServiceTest
{
    private IRepositoryTest _repositoryTest;

    public ServiceTest(IRepositoryTest repositoryTest)
    {
        _repositoryTest = repositoryTest;
    }

    public List<Test> GetAll()
    {
        return _repositoryTest.GetAll();
    }
}
