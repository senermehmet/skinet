using Core.Entities;
using Core.Spesifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpesificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpesification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Creteria != null)
            {
                query = query.Where(spec.Creteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;


        }
    }
}