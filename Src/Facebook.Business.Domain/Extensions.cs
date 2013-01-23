using System.Collections.Generic;
using System.Linq;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Business.Domain
{
    public static class Extensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> queryable, int page, int count)
        {
            ContractUtil.IsInRange(page, 1);
            ContractUtil.IsInRange(count, 1);

            return queryable.Skip((page - 1)*count).Take(count);
        }

        public static IDictionary<T, int> ToOccurrenceTable<T>(this IEnumerable<T> items)
        {
            var table = new Dictionary<T, int>();

            foreach (var i in items)
            {
                if (table.ContainsKey(i))
                    table[i]++;
                else
                    table.Add(i, 1);
            }

            return table;
        } 
    }
}