

using System.Linq.Expressions;


namespace Shop.Common.Data.Repository
{
    public interface IBaseRepository<TEntity, TType> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetAll();
        List<TEntity> GetEntityById(int Id);
        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}
