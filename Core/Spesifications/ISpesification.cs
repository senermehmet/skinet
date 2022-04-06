using System.Linq.Expressions;

namespace Core.Spesifications
{
    public interface ISpesification<T>
    {
        Expression<Func<T, bool>> Creteria {get;}
        List<Expression<Func<T, object>>> Includes {get;}
        Expression<Func<T,object>> OrderBy {get;}
        Expression<Func<T,object>> OrderByDescending {get;}


    }
}