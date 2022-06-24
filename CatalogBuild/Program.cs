using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CatalogBuild

{
    class Program
    {
        private static IMongoCollection<BsonDocument> collection;

        private static object BaseConnect(string targetCollection) { 
            string connectionString = "mongodb://master:159753@localhost/test?authSource=admin";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ushopbase");
            
            return collection = database.GetCollection<BsonDocument>(targetCollection);
        
        }
        static void Main(string[] args)
        {
            SaveDocs().GetAwaiter().GetResult();

            //Console.ReadLine();
        }

        private static async Task SaveDocs()
        {
            BaseConnect("blogpost3");

            BsonDocument post10 = new BsonDocument
            {
                {"Title", "!!!!Карты «МИР» будут использовать по-новому!!!!!!!"},
                {"Text", "С 25 октября 2022 года россиянам будет доступен новый способ оплаты через карты «МИР». Оплачивать покупки можно будет с помощью QR-кодов. Об этом сообщают «Известия» с отсылкой на бюллетень национальной платежной системы."},
                {"Author", "Майл.ру"}
            };
            BsonDocument post11 = new BsonDocument
            {
                {"Title", "!!!!Российские ученые использовали кактус для улучшения Wi-Fi!!!!!!!"},
                {"Text", "Высокая доля воды внутри растительности вызывает множественные электромагнитные резонансы. Например, стебли кактуса nopal, который исследовали ученые, почти на 75−85% состоят из воды, что и позволило использовать его в качестве естественной широкополосной всенаправленной антенны, работающей в нескольких диапазонах связи Wi-Fi от 900 МГц до 7,7 ГГц."},
                {"Author", "Майл.ру"}
            };
            await collection.InsertOneAsync(post10);
            await collection.InsertOneAsync(post11);
        }
    }
}
