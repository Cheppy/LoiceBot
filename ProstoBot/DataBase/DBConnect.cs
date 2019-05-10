using Npgsql;
using System.Data.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;

class DBConnect : DbConfiguration
{
    public static string RAW_SQLCommand { get; set; }
    //public DBConnect()
    //{   
    //    var name = "Npgsql";
    //    SetProviderFactory(providerInvariantName: name,
    //    providerFactory: NpgsqlFactory.Instance);
                
    //    SetProviderServices(providerInvariantName: name,
    //    provider: NpgsqlServices.Instance);

    //    SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
    //}




    public
      static string PostgreSQLtestConnection()
    {   //string 
        List<string> dataItems = new List<string>();
        string connstring = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=admin; Database=LikeBotDB;";
        NpgsqlConnection connection = new NpgsqlConnection(connstring);
        connection.Open();

        string str = "";
        NpgsqlCommand command = new NpgsqlCommand("SELECT  Count(*)FROM Buttons", connection);
        //NpgsqlDataReader dataReader = command.ExecuteReader();
        Int64 count = (Int64)command.ExecuteScalar();
        connection.Close();
        Console.Write("COunt is  ");

        Console.Write("{0}\n", count);
        Console.Write(" DB Connection status is   ");
        return connection.State.ToString();
    }

}