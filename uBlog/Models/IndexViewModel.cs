namespace uBlog.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; }
        public PageViewModel PageViewModel { get; }
        public IndexViewModel(IEnumerable<Post> posts, PageViewModel viewModel)
        {
            Posts = posts;
            PageViewModel = viewModel;
        }
    }
}


//-https://metanit.com/sharp/aspnetmvc/11.7.php