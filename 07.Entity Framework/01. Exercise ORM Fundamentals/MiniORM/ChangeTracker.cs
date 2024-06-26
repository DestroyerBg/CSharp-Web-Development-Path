using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static MiniORM.DbContext;
namespace MiniORM
{
    public class ChangeTracker<T> where T : class , new()
    {
        private readonly List<T> _allEntities;
        private readonly List<T> _added;
        private readonly List<T> _removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            _added = new List<T>();
            _removed = new List<T>();
            _allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities => _allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => _added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => _removed.AsReadOnly();

        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();
            var propertiesToClone = typeof(T).GetProperties()
                .Where(p => DbContext.AllowedSqlTypes.Contains(p.PropertyType))
                .ToArray();
            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();
                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }

        public void Add(T element)
        {
            _added.Add(element);
        }

        public void Remove(T element)
        {
            _removed.Add(element);
        }

        public IEnumerable<T> GetModifiedEntries(DbSet<T> dbSet)
        {
            var modifiedEntries = new List<T>();
            var primaryKeys = typeof(T).GetProperties()
                .Where(p => p.HasAttribute<KeyAttribute>())
                .ToArray();
            foreach (var entry in AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, entry).ToArray();
                var entity = dbSet
                    .Entities.Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));
                var isModified = IsModified(entry, entity);
                if (isModified)
                {
                    modifiedEntries.Add(entry);
                }
            }

            return modifiedEntries;
        }

        private static bool IsModified(T entity, T proxyEntity)
        {
            var monitoredProperties = typeof(T)
                .GetProperties()
                .Where(p => DbContext.AllowedSqlTypes.Contains(p.PropertyType));

            var modifiedProperties =
                monitoredProperties.Where(p => !Equals(p.GetValue(entity), p.GetValue(proxyEntity))).ToArray();
            var isModified = modifiedProperties.Any();
            return isModified;

        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(p => p.GetValue(entity));
        }
    }
}