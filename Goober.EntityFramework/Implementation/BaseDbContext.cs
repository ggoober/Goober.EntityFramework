using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace Goober.EntityFramework.Implementation
{
    public abstract class BaseDbContext : DbContext, IBaseDbContext
    {
        #region ctor

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {

        }

        #endregion

        #region public methods

        public IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }

        public DbConnection GetDbConnection()
        {
            return Database.GetDbConnection();
        }

        #endregion
    }
}
