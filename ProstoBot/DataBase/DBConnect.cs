using Npgsql;
using System.Data.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;

class DBConnect : DbConfiguration
{
    public static string RAW_SQLCommand { get; set; }
    public DBConnect()
    {   
        var name = "Npgsql";
        SetProviderFactory(providerInvariantName: name,
        providerFactory: NpgsqlFactory.Instance);
                
        SetProviderServices(providerInvariantName: name,
        provider: NpgsqlServices.Instance);

        SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
    }




    public
      static string PostgreSQLtest()
    {
        List<string> dataItems = new List<string>();
        string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=admin; Database=LikeBotDB;";
        NpgsqlConnection connection = new NpgsqlConnection(connstring);
        connection.Open();
        //NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM LikeBotDB", connection);
        //NpgsqlDataReader dataReader = command.ExecuteReader();
        //for (int i = 0; dataReader.Read(); i++)
        //{
        //    dataItems.Add(dataReader[0].ToString() + "," + dataReader[1].ToString() + "," + dataReader[2].ToString() + "\r\n");
        //}
        
       
         Console.Write(" DB Connection status is   ");
        return connection.State.ToString();
    }

}