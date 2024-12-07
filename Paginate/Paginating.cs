using Microsoft.EntityFrameworkCore;

namespace NorthwindApp.Paginate
{
    public class Paginated<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }


        public Paginated(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public bool HasPreviousPage => (PageIndex) > 1;
        public bool HasNextPage => (PageIndex < TotalPages);
        public int FirstPage => (PageIndex - 1) * PageSize + 1;
        public int LastIPage => Math.Min(PageIndex * PageSize, TotalItems);


        public static async Task<Paginated<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new Paginated<T>(items, count, pageIndex, pageSize);
        }
    }
}
