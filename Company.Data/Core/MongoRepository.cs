using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Company.Data.Core
{
    public class MongoRepository
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IOptions<DefaultOptions> _options)
        {
            try
            {
                var client = new MongoClient(_options.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(_options.Value.DbName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }
        }

        public IMongoCollection<Entities.Company> Companies => _database.GetCollection<Entities.Company>("Companies");
    }
}