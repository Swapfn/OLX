using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DBEntities dbContext;
        private readonly IConfiguration Config;

        public DbFactory(IConfiguration configuration)
        {
            Config = configuration;
        }
        public DBEntities Init()
        {
            return dbContext ?? (dbContext = CreateDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public DBEntities CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBEntities>();
            string connectionString = Config.GetConnectionString("OLXDbConnectionStrings");

            optionsBuilder.UseSqlServer(connectionString);


            return new DBEntities(optionsBuilder.Options);
        }
    }
}
