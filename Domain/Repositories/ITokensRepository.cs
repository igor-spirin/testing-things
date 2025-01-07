namespace Domain.Repositories;

public interface ITokensRepository
{
    Task AddTokenAsync(string token);
}
