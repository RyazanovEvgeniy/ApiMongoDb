using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository;

public class RepositoryTest : IRepositoryTest
{
    public List<Test> GetAll()
    {
        return new List<Test>()
        { 
            new Test { name = "1" }, 
            new Test { name = "2" }, 
            new Test { name = "3" }, 
            new Test { name = "4" }, 
            new Test { name = "5" }
        };
    }
}