namespace PersonDirectory.Common.Application.Paging
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
