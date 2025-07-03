namespace MsSqlConnectionStringBuilder.Interfaces;

/// <summary>
/// Interface for reading SqlSettings
/// </summary>
public interface IMsSqlConfiguration
{
    string Server { get; }
    int? Port { get; }
    string Database { get; }
    bool IntegratedSecurity { get; }
    bool TrustedServerCertificate { get; }
    string Username { get; }
    string Password { get; }
    bool Mars { get; }
    TimeSpan? ConnectionTimeout { get; }
    int? MaxPoolSize { get; }
}