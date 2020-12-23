using System;
using MongoDB.Driver;
using famcook.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver.GridFS;

namespace famcook.Data
{
    public class DatabaseSettings : IDatabaseSettings
    {
        private readonly IMongoDatabase Database;

        public DatabaseSettings(IOptions<MongoSettings> configuration)
        {
            MongoClient mongoClient = new MongoClient(configuration.Value.ConnectionString);
            Database = mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public IMongoDatabase GetDatabase()
        {
            return Database;
        }
    }
}
