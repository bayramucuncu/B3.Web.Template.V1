using System.Collections.Generic;
using Newtonsoft.Json;

namespace B3.Infrastructure.Pagination
{
    public interface IPagedResult<T>
    {
        [JsonProperty("pageInfo")]
        PageInfo PageInfo { get; }

        [JsonProperty("data")]
        IList<T> Data { get; }
    }
}