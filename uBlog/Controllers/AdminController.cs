using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using uBlog.Domain;
using uBlog.Models;

namespace uBlog.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(Data.ExistingPosts);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            if (post.Id == default)
            {
                post.Id = ObjectId.GenerateNewId();
            }
            BsonDocument filter = new BsonDocument() {
                {
                    "_id", post.Id
                }
            };

            Data.blogCollection.ReplaceOne(filter, post, new ReplaceOptions()
            {
                IsUpsert = true
            });


            if (!Data.ExistingPosts.Any(x => x.Id == post.Id))
                Data.ExistingPosts.Add(post);

            return RedirectToAction("Index");

            //return Redirect("/Blog");


        }
    }
}
