using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uBlog.Models
{
    public class Post
    {
        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string IdAsString
        {
            get
            {
                return Id.ToString();
            }
            set
            {
                if (value == null)
                    Id = ObjectId.Empty;
                else
                    Id = new ObjectId(value);
            }
        }
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
