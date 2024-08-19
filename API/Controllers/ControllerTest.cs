using Microsoft.AspNetCore.Mvc;

using BLL.Services.Interfaces;
using DAL.Entities;

namespace API.Controllers;

[Route("api/test")]
[ApiController]
public class ControllerTest : ControllerBase
{
    private readonly IServiceTest _serviceTest;

    public ControllerTest(IServiceTest serviceTest)
    {
        _serviceTest = serviceTest;
    }

    [HttpGet]
    public ActionResult<List<Test>> Get()
    {
        return Ok(_serviceTest.GetAll());
    }
}