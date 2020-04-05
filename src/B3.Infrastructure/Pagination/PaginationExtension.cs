using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace B3.Infrastructure.Pagination
{
    public static class PaginationExtension
    {
        public static PagedResult<T> ToPagedList<T>(this IQueryable<T> source, int page, int pageSize)
            where T : class
        {
            if (page <= 0)
                page = 1;

            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var pageInfo = new PageInfo(count, page, pageSize);

            return new PagedResult<T>(items, pageInfo);
        }

        public static async Task<PagedResult<T>> ToPagedListAsync<T>(this IQueryable<T> source, int page, int pageSize)
            where T : class
        {
            if (page <= 0)
                page = 1;

            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var pageInfo = new PageInfo(count, page, pageSize);

            return new PagedResult<T>(items, pageInfo);
        }
    }
}