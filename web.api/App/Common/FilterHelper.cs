using System;
using System.Linq;
using System.Linq.Expressions;

namespace web.api.App.Common
{
    public static class FilterHelper
    {
        public static IQueryable<T> FilterBy<T>(this IQueryable<T> queryable,
            Expression<Func<T, bool>> filter,
            object filterParameter)
        {
            return filterParameter != null ? queryable.Where(filter) : queryable;
        }
    }
}