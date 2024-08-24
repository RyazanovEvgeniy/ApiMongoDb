using Microsoft.AspNetCore.Mvc;

using BLL.Services.Interfaces;
using DAL.Entities;

namespace API.Controllers;

[Route("api/test")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(string id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<string>> Add(User user)
    {
        return Ok(await _userService.AddAsync(user));
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Update(User user)
    {
        return Ok(await _userService.UpdateAsync(user));
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> Delete(string id)
    {
        return Ok(await _userService.DeleteAsync(id));
    }
}