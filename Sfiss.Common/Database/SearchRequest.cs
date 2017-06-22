namespace Sfiss.Common.Database
{
    public class SearchRequest
    {
        public string Title { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string OrderBy { get; set; }

        public bool IsPaginated { get; set; }
    }
}