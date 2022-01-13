using System.Linq.Expressions;

namespace Core.Spesifications
{
    public class BaseSpesification<T> : ISpesification<T>
    {
        public BaseSpesification()
        {
        }

        public BaseSpesification(Expression<Func<T, bool>> creteria)
        {
            Creteria = creteria;
        }

        public Expression<Func<T, bool>> Creteria {get; }

        public List<Expression<Func<T, object>>> Includes {get;} = new  List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpresion)
        {
            Includes.Add(includeExpresion);
        }
    }
}