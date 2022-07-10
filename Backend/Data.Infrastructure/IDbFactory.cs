namespace Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DBEntities Init();
    }
}
