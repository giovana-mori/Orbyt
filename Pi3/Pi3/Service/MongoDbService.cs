using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Pi3.Service
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;
        
        public MongoDbService()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString;
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("Pi3");                                                                                                                                                                                                                                                                                                                                                                                                  
        }
    }
}