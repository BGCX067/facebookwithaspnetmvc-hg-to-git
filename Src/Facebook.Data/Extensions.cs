using System.Linq;

namespace Facebook.Data
{
    public static class Extensions
    {
        /// <summary>
        /// Paginates a queryable.
        /// </summary>
        /// <typeparam name="T">The type of the items in the queryable.</typeparam>
        /// <param name="queryable">The items to paginate.</param>
        /// <param name="page">The page number.</param>
        /// <param name="count">The items count.</param>
        /// <returns>The result of paginate <paramref name="queryable"/></returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page = 1, int count = int.MaxValue)
        {
            return queryable.Skip((page - 1) * count).Take(count);
        }
    }
}