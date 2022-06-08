using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uShop;

[BsonIgnoreExtraElements]  //если какого-то поля нет - не выведет ошибку а проигнорирует
public class Post
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
    public PostCategory PostCategory { get; set; }

}

public class PostCategory
{
    public string Name { get; set; }
}
