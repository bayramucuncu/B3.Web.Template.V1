namespace B3.Infrastructure.Settings
{
    public interface IApplicationSettings
    {
        string ConnectionSettings { get; }
        string DatabaseType { get; }
        int DefaultPageSize { get; }
    }
}