using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using uShop.Domain;

namespace uShop
{
    public static class Data
    {
        public static IMongoDatabase DB;

        public static List<Product> Products;

        public static List<string> Categories;

        public static void InitData(IConfiguration Configuration)
        {
            var dbConfigSection = Configuration.GetSection("DBConfig");
            var dbConfig = new DBConf(dbConfigSection);
            var mongoClient = new MongoClient(dbConfig.ConnectionString);
            DB = mongoClient.GetDatabase(dbConfig.DBName);
            Products = GetAllProducts();
            Categories = Products.Select(x => x.BrandName).Distinct().OrderBy(x => x).ToList();
        }

        private static List<Product> GetAllProducts()
        {
            var productsCollection = DB.GetCollection<Product>("products");
            BsonDocument filter = new BsonDocument();
            return productsCollection.Find(filter).ToList();
        }
    }
}
