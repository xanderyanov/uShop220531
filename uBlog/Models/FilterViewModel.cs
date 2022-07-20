using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;

namespace uBlog.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<PostTopic> topics, string id)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            topics.Insert(0, new PostTopic { Title = "Все", IdAsString = "" });

            Topics = new SelectList(topics, "IdAsString", id);

            SelectedTopic = id;
        }






        public SelectList Topics { get; } // список тегов
        public string SelectedTopic { get; } // выбранный тег
    }
}
