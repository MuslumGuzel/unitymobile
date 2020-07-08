using System.Collections.Generic;

namespace Assets.Scripts.Database
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);

        TEntity Delete(int id);
    }
}