namespace ProcApi.Infrastructure.Options;

public class PasswordOptions
{
    public int KeySize { get; set; }
    public int Iteration { get; set; }
}