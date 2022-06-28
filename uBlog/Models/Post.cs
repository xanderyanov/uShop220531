using MongoDB.Bson;

namespace uBlog.Models
{
    public class Post
    {
        public ObjectId Id { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public List<Tag> Tags { get; set; }
    }

    public class Tag
    { 
        public string TagName { get; set; }
    }
}
