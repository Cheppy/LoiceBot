using Npgsql;
using System.Data.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;

class DBConnect : DbConfiguration
{
    public DBConnect()
    {
        var name = "Npgsql";

        SetProviderFactory(providerInvariantName: name,
        providerFactory: NpgsqlFactory.Instance);

        SetProviderServices(providerInvariantName: name,
        provider: NpgsqlServices.Instance);

        SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
    }
}