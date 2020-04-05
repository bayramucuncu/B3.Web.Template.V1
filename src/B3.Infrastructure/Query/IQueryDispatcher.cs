namespace B3.Infrastructure.Query
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TResult, TQuery>(TQuery query) where TQuery: IQuery<TResult>;
    }
}