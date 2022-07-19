namespace uBlog.Models
{
    public class SortViewModel
    {
        public SortState TitleSort { get; }
        public SortState DateSort { get; }
        public SortState Current { get; }

        public SortViewModel(SortState sortOrder)
        {
            //TitleSort = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            //DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            TitleSort = sortOrder;
            DateSort = sortOrder;
            Current = sortOrder;
        }


    }
}
