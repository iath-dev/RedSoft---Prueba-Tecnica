using System.Linq.Expressions;

namespace RESTApi.Interface
{
    public interface IMongoRepository<T> where T : IDocument
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression);
        T FindOne(Expression<Func<T, bool>> filterExpression);
        T FindById(string id);
        void InsertOne(T entity);
        void InsertMany(ICollection<T> collection);
        void ReplaceOne(T entity);
        void DeleteOne(Expression<Func<T, bool>> filterExpression);
        void DeleteById(string id);
        void DeleteMany(Expression<Func<T, bool>> filterExpression);
    }
}
