namespace CliniCorp.Business.Models
{
    public class PageList<T> : List<T>
    {
        public int Currentpage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageList(List<T> items, int Count, int pageNumber, int pageSize)
        {
            TotalCount = Count;
            PageSize = pageSize;
            Currentpage = pageNumber;
            TotalPages = (int)Math.Ceiling(Count / (double)pageSize);

            this.AddRange(items);

        }

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Take(pageSize)
                .ToList();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
