using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;

namespace Server.Controllers;

[Authorize]
[Route("api/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAccountsService _accountsService;
    private readonly ILogger<AccountsController> _logger;

    public AccountsController(IAccountsService accountsService, ILogger<AccountsController> logger)
    {
        _accountsService = accountsService;
        _logger = logger;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCredentialsDto dto)
    {
        try
        {
            var tokens = await _accountsService.LoginAsync(dto.ToDomain());
            if (tokens is null)
            {
                return NotFound();
            }
            
            return Ok(tokens.ToDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminGet()
    {
        return Ok();
    }
    
    [Authorize(Roles = "Default")]
    [HttpGet("default")]
    public IActionResult DefaultGet()
    {
        return Ok();
    }
    
    [Authorize(Roles = "Admin,Default")]
    [HttpGet("mixed")]
    public IActionResult MixedGet()
    {
        return Ok();
    }
}
