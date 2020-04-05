using System.Collections.Generic;

namespace B3.Infrastructure.Pagination
{
    public class PagedResult<T> : IPagedResult<T> where T : class
    {
        public PageInfo PageInfo { get; }

        public IList<T> Data { get; }

        public PagedResult(IList<T> items, PageInfo pageInfo)
        {
            PageInfo = pageInfo;
            Data = items;
        }
    }
}