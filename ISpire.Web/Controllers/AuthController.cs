using ISpire.Core.Errors;
using ISpire.Core.Services;
using ISpire.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ISpire.Web.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        RegisterResult result = await _authService.Register(dto.Name, dto.Email, dto.Password);

        return result switch
        {
            RegisterResult.Success => Ok(new {message = "Registration Successful"}),
            RegisterResult.WrongEmailPattern=> Conflict(new { message = "Wrong email pattern"}),
            RegisterResult.RepositoryAddFailed => Conflict(new { message = "Failed to add user to repository"}),
            RegisterResult.AlreadyExists => BadRequest(new { message = "User already exists"}),
            _ => BadRequest()
        };
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        LoginResult result = await _authService.Login(dto.Email, dto.Password);

        return result switch
        {
            LoginResult.Success token => Ok(new { token.Token}),
            LoginResult.AccountNotFound => NotFound(new { message = "Account not found"}),
            LoginResult.WrongPassword=> Unauthorized(new { message = "Password is wrong"}),
            _ => BadRequest()
        };
    }
    
}