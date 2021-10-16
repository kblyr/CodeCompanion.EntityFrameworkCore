using System.Linq.Expressions;

namespace CodeCompanion.EntityFrameworkCore
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicateExp, bool condition)
        {
            if (condition)
                return query.Where(predicateExp);

            return query;
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicateExp, Func<bool> conditionCheck)
        {
            if (conditionCheck())
                return query.Where(predicateExp);

            return query;
        }
    }
}