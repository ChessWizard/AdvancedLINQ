using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Shared.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> source, int pageNumber, int pageSize)
            => source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}
