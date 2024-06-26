using System.Collections;

namespace MiniORM
{
    public class DbSet <TEntity> : ICollection<TEntity> where TEntity : class, new()
    {
        internal DbSet(IEnumerable<TEntity> entities)
        {
            Entities = entities.ToList();
            ChangeTracker = new ChangeTracker<TEntity>(entities);
        }
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }

        
       
        public IEnumerator<TEntity> GetEnumerator() => Entities.GetEnumerator();
        

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Item cannot be null");
            }
            Entities.Add(entity);
            ChangeTracker.Add(entity);
        }

        public void Clear()
        {
            while (Entities.Any())
            {
                var entity = Entities.First();
                Remove(entity);
            }
        }

        public bool Contains(TEntity item) => Entities.Contains(item);
        

        public void CopyTo(TEntity[] array, int arrayIndex) => Entities.CopyTo(array, arrayIndex);
        

        public bool Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Item cannot be null");
            }
            var removed = Entities.Remove(entity);
            if (removed)
            {
                ChangeTracker.Remove(entity);
            }
            return removed;

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToArray())
            {
                Remove(entity);
            }
        }

        public int Count => Entities.Count;
        public bool IsReadOnly => Entities.IsReadOnly;
    }
}
