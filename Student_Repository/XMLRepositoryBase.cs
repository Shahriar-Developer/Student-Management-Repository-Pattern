using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Student_Domain;
using Student_Source;

namespace Student_Repository
{
    public class XMLRepositoryBase<TEntityContext, TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntityContext : XMLSet<TEntity>
        where TEntity : class
    {
        private XMLSet<TEntity> _context;

        public XMLRepositoryBase(string fileName)
        {
            _context = new XMLSet<TEntity>(fileName);
        }

        public ICollection<TEntity> GetAll() => _context.Data;

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Data.AsQueryable().Where(predicate).ToList();
        }

        public TEntity Get(TKey id)
        {
            var items = _context.Data.Cast<IEntity<TKey>>().ToList();
            return items.FirstOrDefault(f => f.ID.Equals(id)) as TEntity;
        }

        public TKey Insert(TEntity model)
        {
            var list = _context.Data;
            var entity = model as IEntity<int>;  // TKey কে int ধরে নিলাম
            if (entity == null)
                throw new InvalidOperationException("Entity ID type must be int.");

            int maxId = list.Cast<IEntity<int>>().Count() > 0 ? list.Cast<IEntity<int>>().Max(x => x.ID) : 0;
            entity.ID = maxId + 1;

            list.Add(model);
            _context.Data = list;

            return (TKey)(object)entity.ID; // safe conversion back to TKey
        }

        public bool Update(TEntity model)
        {
            try
            {
                var imodel = model as IEntity<TKey>;
                var items = _context.Data.Cast<IEntity<TKey>>().ToList();
                items.Remove(items.FirstOrDefault(f => f.ID.Equals(imodel.ID)));
                items.Add(imodel);
                _context.Data = items.Cast<TEntity>().ToList();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(TKey id)
        {
            try
            {
                var items = _context.Data.Cast<IEntity<TKey>>().ToList();
                items.Remove(items.First(f => f.ID.Equals(id)));
                _context.Data = items.Cast<TEntity>().ToList();
                return true;
            }
            catch { return false; }
        }

        public bool Remove(TKey id) => Delete(id);
    }
}
