using System;
using MongoDB.Driver;
namespace famcook.Models
{
    public interface IDatabaseSettings
    {
        IMongoCollection<Recipe> GetCollection<Recipe>(string name);
    }
}
