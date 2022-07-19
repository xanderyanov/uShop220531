namespace uBlog.Models
{
    public class ComplexModel
    {

        public IEnumerable<Post> Posts { get; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }

        public ComplexModel(IEnumerable<Post> posts, PageViewModel pageViewModel, SortViewModel sortViewModel)
        {
            Posts = posts;

            PageViewModel = pageViewModel;

            SortViewModel = sortViewModel;
        }

        public string UrlForOtherPage(int delta)
        {
            return "?sortOrder=" + SortViewModel.Current + "&page=" + (PageViewModel.PageNumber + delta);
        }

        public string UrlForOtherSortOrder(SortState newSortOrder)
        {
            return "?sortOrder=" + newSortOrder + "&page=" + (PageViewModel.PageNumber);
        }

    }
}
