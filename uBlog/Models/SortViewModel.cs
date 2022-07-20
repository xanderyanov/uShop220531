namespace uBlog.Models
{
    public class SortViewModel
    {
        public SortState TitleSort { get; }
        public SortState DateSort { get; }
        public SortState Current { get; }

        public SortViewModel(SortState sortOrder)
        {
            TitleSort = sortOrder;
            DateSort = sortOrder;
            Current = sortOrder;
        }


    }
}
