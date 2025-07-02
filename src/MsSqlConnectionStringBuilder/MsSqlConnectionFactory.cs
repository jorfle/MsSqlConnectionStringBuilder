using System.Data;
using Microsoft.Data.SqlClient;

namespace MsSqlConnectionStringBuilder;

public class MsSqlConnectionFactory
{
    private readonly string _connString;

    public MsSqlConnectionFactory(IMsSqlConfiguration msSqlConfig)
    {
        ArgumentNullException.ThrowIfNull(msSqlConfig);

        var sb = new SqlConnectionStringBuilder
        {
            InitialCatalog = msSqlConfig.Database,
            IntegratedSecurity = msSqlConfig.IntegratedSecurity,
            MultipleActiveResultSets = msSqlConfig.Mars,
            TrustServerCertificate = msSqlConfig.TrustedServerCertificate,
            DataSource = !msSqlConfig.Port.HasValue ? msSqlConfig.Server : $"{msSqlConfig.Server},{msSqlConfig.Port}"
        };

        if (!msSqlConfig.IntegratedSecurity)
        {
            sb.UserID = msSqlConfig.Username;
            sb.Password = msSqlConfig.Password;
        }

        if (msSqlConfig.ConnectionTimeout.HasValue)
        {
            sb.ConnectTimeout = (int)msSqlConfig.ConnectionTimeout.Value.TotalSeconds;
        }

        if (msSqlConfig.MaxPoolSize.HasValue)
        {
            sb.MaxPoolSize = msSqlConfig.MaxPoolSize.Value;
        }

        _connString = sb.ToString();
    }

    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return conn;
    }

    public IDbConnection CreateConnection()
    {
        var conn = new SqlConnection(_connString);
        conn.Open();
        return conn;
    }
}