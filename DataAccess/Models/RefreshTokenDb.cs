namespace Models;

public class RefreshTokenDb
{
    public RefreshTokenDb(long id, long accountId, string token)
    {
        Id = id;
        AccountId = accountId;
        Token = token;
    }

    public long Id { get; set; }
    public long AccountId { get; set; }
    public string Token { get; set; }


    public AccountDb? Account { get; set; }
}
