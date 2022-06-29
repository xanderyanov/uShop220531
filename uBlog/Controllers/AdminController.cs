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


        //переход на страницу, где форма обновления документа. Там все работает
        [HttpGet]
        public IActionResult UpdatePost(string id)
        {
            ObjectId Id = default;
            try
            {
                Id = new ObjectId(id);
            }
            catch
            {
                return NotFound();
            }
            
            Post post = Data.ExistingPosts.Find(x => x.Id == Id);
            return View("Update", post);
        }

        //Клик по submit отредактированной формы
        [HttpPost]
        public IActionResult UpdatePost(Post post)
        {

            BsonDocument filter = new BsonDocument() {
                {
                    "_id", post.Id
                }
            };

            Data.blogCollection.ReplaceOne(filter, post, new ReplaceOptions()
            {
                IsUpsert = true
            });

            int index = Data.ExistingPosts.FindIndex(x => x.Id == post.Id);
            if (index == -1) Data.ExistingPosts.Add(post); else Data.ExistingPosts[index] = post;


            return RedirectToAction("Index");
        }









        [HttpPost]
        public IActionResult DeletePost(string Id)
        {
            var postId = new ObjectId(Id);

            BsonDocument filter = new BsonDocument() {
                {
                    "_id", postId
                }
            };

            Data.blogCollection.DeleteOne(filter);

            Data.ExistingPosts.RemoveAll(x => x.Id == postId);


            return RedirectToAction("Index");

        }
    }
}
