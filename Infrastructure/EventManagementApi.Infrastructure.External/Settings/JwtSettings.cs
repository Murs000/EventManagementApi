namespace EventManagementApi.Infrastructure.External.Settings;

public class JwtSettings
{
    public string Secret { get; set; }
    public int ExpireAt { get; set; }
}