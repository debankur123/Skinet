using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T>
    {
        public BaseSpecifications()
        {
            
        }
        protected BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria         {get;}
        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy     {get; private set;}
        public Expression<Func<T, object>> OrderByDesc {get; private set;}
        public int Take             {get; private set;}
        public int Skip             {get; private set;}
        public bool IsPagingEnabled {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> includeExpression){
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpr){
            OrderBy = orderByExpr;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpr){
            OrderByDesc = orderByDescExpr;
        }
        protected void AddPagination(int skip,int take){
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
        
    }
}