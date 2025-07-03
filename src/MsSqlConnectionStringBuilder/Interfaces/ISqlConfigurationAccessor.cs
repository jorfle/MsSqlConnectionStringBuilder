namespace MsSqlConnectionStringBuilder.Interfaces;

public interface ISqlConfigurationAccessor
{
    string Server { get;}

    int? Port { get;}

    string Database { get;}

    bool IntegratedSecurity { get;}

    bool TrustedServerCertificate { get;}

    string Username { get;}

    string Password { get;}

    bool Mars { get;}

    TimeSpan? ConnectionTimeout { get;}

    int? MaxPoolSize { get;}
}