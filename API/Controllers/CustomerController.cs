using Microsoft.AspNetCore.Mvc;

using BLL.Services.Interfaces;
using DAL.Entities;

namespace API.Controllers;

[Route("api/test")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<Customer>> GetById(string id)
    {
        return Ok(await _customerService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Add(Customer customer)
    {
        return Ok(await _customerService.AddAsync(customer));
    }
}