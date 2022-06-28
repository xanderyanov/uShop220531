using MongoDB.Bson;
using MongoDB.Driver;
using uBlog.Models;

namespace uBlog.Domain
{
    public class Data
    {
        public static IMongoDatabase DB;

        public static List<Post> ExistingPosts;

        public static IMongoCollection<Post> blogCollection;

        public static void InitData(IConfiguration Configuration)
        {
            var dbConfigSection = Configuration.GetSection("DBConfig");
            var dbConfig = new DBConf(dbConfigSection);
            var mongoClient = new MongoClient(dbConfig.ConnectionString);
            DB = mongoClient.GetDatabase(dbConfig.DBName);

            blogCollection = DB.GetCollection<Post>("blogpost");

            ExistingPosts = GetAllPosts();
        }

        private static List<Post> GetAllPosts()
        {
            BsonDocument filter = new BsonDocument();

            var result = blogCollection.Find(filter).ToList();

            var resultWithSortByDate = result.OrderByDescending(p => p.PostDate);

            return resultWithSortByDate.ToList();
        }
    }

}