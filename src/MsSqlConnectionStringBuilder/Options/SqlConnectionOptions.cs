using MsSqlConnectionStringBuilder.Interfaces;

namespace MsSqlConnectionStringBuilder.Options;

public abstract class SqlConnectionOptions : IMsSqlConfiguration
{
    public required string Server { get; set; }
    public int? Port { get; set; }
    public required string Database { get; set; }
    public required bool IntegratedSecurity { get; set; }
    public bool TrustedServerCertificate { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public bool Mars { get; set; }
    public TimeSpan? ConnectionTimeout { get; set; }
    public int? MaxPoolSize { get; set; }
}