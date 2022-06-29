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
            if (post.Id == default)
            {
                var postId = post.Id;
            }
            BsonDocument filter = new BsonDocument() {
                {
                    "_id", post.Id
                }
            };

            // Data.blogCollection.UpdateOne(filter, "то, на что заменяю - как это получить - не могу понять...");
            // должен id сохраниться же
            // пока получалось только создание нового документа 

            //как то надо обновлять Data.ExistingPosts - чтобы в памяти актуально было все - тоже не пойму...;

            return RedirectToAction("Index"); //возврат на страницу админки редактирования - где все посты
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
