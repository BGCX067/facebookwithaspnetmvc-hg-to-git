using System.Data.Entity;
using System.Data.Objects;

namespace Facebook.Data.EntityFramework
{
    /// <summary>
    /// Acts as a super layer type for all repositories.
    /// </summary>
    class Repository <TEntity> where TEntity : class 
    {
        protected readonly DbSet<TEntity> Set;

        protected Repository(DbSet<TEntity> set)
        {
            Set = set;
        }
    }
}
