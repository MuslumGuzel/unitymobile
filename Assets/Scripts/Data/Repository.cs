using System.Collections.Generic;
using System.Linq;
using SQLiteUnity;

namespace Assets.Scripts.Database
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private DataContext Context { get; }

        public TableQuery<TEntity> Table => Context.Connection.Table<TEntity>();


        public Repository(DataContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table;
        }

        public TEntity GetById(int id)
        {
            return Table.FirstOrDefault(en => en.Id == id);
        }

        public TEntity Insert(TEntity entity)
        {
            Context.Connection.Insert(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Connection.Update(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Connection.Delete(entity);
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity = GetById(id);
            Context.Connection.Delete(entity);
            return entity;
        }

    }
}