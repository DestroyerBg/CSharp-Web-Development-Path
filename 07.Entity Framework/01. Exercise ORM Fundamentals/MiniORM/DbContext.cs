using System.Reflection;

namespace MiniORM
{
    public abstract class DbContext
    {
        private readonly DatabaseConnection _connection;
        private readonly Dictionary<Type, PropertyInfo> _dbPropertyInfos;

        public static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(bool),
            typeof(decimal),
            typeof(DateTime),
        };

        protected DbContext(string connectionString)
        {
            _connection = new DatabaseConnection(connectionString);
            _dbPropertyInfos = DiscoverDbSets();
            using (new ConnectionManager(_connection))
            {
                InitializaDbSets();
            }

            MapAllRelations();
        }

        public void SaveChanges()
        {
            var dbSets = _dbPropertyInfos
                .Select(p => p.Value
                    .GetValue(this))
                .ToArray();

            foreach (IEnumerable<Object> dbSet in dbSets)
            {
                var invalid = dbSet.Where(e => !IsObjectInvalid(e)).ToArray();
            }

        }

    }
}
