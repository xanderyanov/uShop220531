using MongoDB.Bson;
using uShop.Models;

namespace uShop.Interfaces
{
    public interface IBlogServices
    {

        Blog CreatePost(Blog post);

        List<Blog> GetAllPosts();
        
        Blog UpdatePost(ObjectId Id);

        Blog DeletePost(ObjectId Id);

    }
}
