using System.Linq;

namespace B3.Infrastructure.AutoMapper
{
    public interface IObjectMapper
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source);
    }
}