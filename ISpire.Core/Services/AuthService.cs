using ISpire.Core.Entities;
using ISpire.Core.Repositories;

namespace ISpire.Core.Services;

public abstract record RegisterResult
{
    public record AlreadyExists : RegisterResult;
    public record RepositoryAddFailed: RegisterResult;
    public record Success(Account account) : RegisterResult;
}


public abstract record LoginResult
{
    public record AccountNotFound : LoginResult;
    public record WrongPassword: LoginResult;
    public record Success(string Token) : LoginResult;
}

public class AuthService
{
    private readonly JwtService _jwtService;
    private readonly IAccountRepository _accountRepository;

    public AuthService(JwtService jwtService, IAccountRepository accountRepository)
    {
        _jwtService = jwtService;
        _accountRepository = accountRepository;
    }

    public async Task<RegisterResult> Register(string name, string email, string password)
    {
        var emailAccount = await _accountRepository.FindByEmail(email);
        var nameAccount = await _accountRepository.FindByName(name);

        if (emailAccount == null || nameAccount == null)
        {
            return new RegisterResult.AlreadyExists();
        }
        
        var account = await _accountRepository.Add(name, email, BCrypt.Net.BCrypt.HashPassword(password));

        if (account == null)
        {
            return new RegisterResult.RepositoryAddFailed();
        }

        return new RegisterResult.Success(account);
    }
    
    
    public async Task<LoginResult> Login(string email, string password)
    {
        var account = await _accountRepository.FindByEmail(email);

        if (account == null)
        {
            return new LoginResult.AccountNotFound();
        }
        
        if (BCrypt.Net.BCrypt.Verify(password, account.PasswordHash) == false)
        {
            return new LoginResult.AccountNotFound();
        }

        var token = _jwtService.GenerateJwtToken(account);

        return new LoginResult.Success(token);
    }
}