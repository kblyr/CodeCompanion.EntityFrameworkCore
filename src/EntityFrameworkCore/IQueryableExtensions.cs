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

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicateExp, Func<bool> evaluate)
        {
            if (evaluate())
                return query.Where(predicateExp);

            return query;
        }
    }
}