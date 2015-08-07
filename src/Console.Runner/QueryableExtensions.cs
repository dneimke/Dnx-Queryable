
namespace Parliament.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class QueryableExtensions
    {
        public static IQueryable<T> SetOrder<T>(this IQueryable<T> allData, string orderBy, bool orderAscending) where T:class
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return allData;
            }

            if (QueryHelper.PropertyExists<T>(orderBy))
            {
                var orderByExpression = QueryHelper.GetPropertyExpression<T>(orderBy);
                allData = orderAscending ? allData.OrderBy(orderByExpression) : allData.OrderByDescending(orderByExpression);
                return allData;
            }
            else
            {
                throw new ArgumentException("Property not found", nameof(orderBy));
            }
        }

        public static IQueryable<T> ConfigurePagedQuery<T>(this IQueryable<T> allEntities, int page, int pageSize, int skip, int take, string order, bool orderAscending) where T : class
        {
            return allEntities.SetOrder(order, orderAscending)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
