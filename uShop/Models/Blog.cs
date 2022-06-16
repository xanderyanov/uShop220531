using MongoDB.Bson;

namespace uShop.Models
{
    public class Blog
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
