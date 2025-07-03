using Microsoft.Extensions.Options;
using MsSqlConnectionStringBuilder.Interfaces;
using MsSqlConnectionStringBuilder.Options;

namespace MsSqlConnectionStringBuilder;


public class SqlConnectionAccessor<T>(IOptions<T> options) : IMsSqlConfiguration where T : SqlConnectionOptions
{
    private readonly T _options = options.Value;

    public string Server => _options.Server;
    public int? Port => _options.Port;
    public string Database => _options.Database;
    public bool IntegratedSecurity => _options.IntegratedSecurity;
    public bool TrustedServerCertificate => _options.TrustedServerCertificate;
    public string Username => _options.Username;
    public string Password => _options.Password;
    public bool Mars => _options.Mars;
    public TimeSpan? ConnectionTimeout => _options.ConnectionTimeout;
    public int? MaxPoolSize => _options.MaxPoolSize;
}