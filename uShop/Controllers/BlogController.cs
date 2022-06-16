using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using uShop.Models;
using System.Diagnostics;
using System.Linq;
using uShop.Models.ViewModels;


namespace uShop.Controllers
{
    public class BlogController : BaseController
    {
        public IActionResult Index()
        {
            return View("Blog", Data.ExistingPosts);
        }

        [HttpPost]
        public IActionResult CreatePost(Blog post) 
        {
            if (post.Id == default) {
                post.Id = ObjectId.GenerateNewId();
            }
            BsonDocument filter = new BsonDocument() {
                { 
                    "_id", post.Id
                }
            };

            Data.blogCollection.ReplaceOne(filter, post, new ReplaceOptions() { 
                IsUpsert = true
            });


            if(!Data.ExistingPosts.Any(x => x.Id==post.Id))
                Data.ExistingPosts.Add(post);

            return RedirectToAction("Index");
            
            //return Redirect("/Blog");


        }
    }
}
