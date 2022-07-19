using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using uBlog.Domain;

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
        public ObjectId PostTopicId { get; set; }

        public PostTopic Topic => Data.RamTopics.FirstOrDefault(x => x.Id == PostTopicId);


        public Flag Flag { get; set; }

        public List<Tag> Tags { get; set; }
    }

    public class PostTopic
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
    }

    public class Flag
    {
        public ObjectId Id { get; set; }
        public string FlagName { get; set; }
    }

    public class Tag
    {
        public string TagName { get; set; }
    }


    public enum SortState
    {
        TitleAsc,    // по названию по возрастанию
        TitleDesc,   // по названию по убыванию
        DateAsc, // по дате по возрастанию
        DateDesc,    // по дате по убыванию
    }
}
