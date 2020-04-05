using System;
using Newtonsoft.Json;

namespace B3.Infrastructure.Pagination
{
    public class PageInfo
    {
        [JsonProperty("firstPage")] public int FirstPage => 1;

        [JsonProperty("currentPage")] public int CurrentPage { get; protected set; }

        [JsonProperty("totalPages")] public int TotalPages { get; protected set; }

        [JsonProperty("rowCount")] public int RowCount { get; protected set; }

        [JsonProperty("pageSize")] public int PageSize { get; protected set; }

        [JsonProperty("hasPreviousPage")] public bool HasPreviousPage => CurrentPage > 1;

        [JsonProperty("hasNextPage")] public bool HasNextPage => CurrentPage < TotalPages;

        [JsonProperty("lastPage")] public int LastPage => (int)Math.Round((decimal)RowCount / PageSize, MidpointRounding.AwayFromZero);

        public PageInfo(int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            RowCount = count;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}