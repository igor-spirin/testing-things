namespace Domain.Models.Auth;

public class LoginCredentials
{
    public LoginCredentials(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public string Login { get; set; }
    public string Password { get; set; }
}
