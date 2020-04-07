using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B3.Infrastructure.AutoMapper;
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

        public static IPagedResult<TDest> MapToPagedResult<TSource, TDest>(this IPagedResult<TSource> pagedResult, IObjectMapper mapper)
            where TDest : class
        {
            var mapped = (IList<TDest>)mapper.Map(pagedResult.Data.AsEnumerable(), pagedResult.Data.GetType(), typeof(IEnumerable<TDest>));

            return new PagedResult<TDest>(mapped, pagedResult.PageInfo);
        }
    }
}