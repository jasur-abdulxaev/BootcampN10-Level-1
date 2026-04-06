using UserRegistrationApp.Interfaces;

namespace UserRegistrationApp.Repositories
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly List<T> _data = new();

        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public T? Find(Func<T, bool> predicate)
        {
            return _data.FirstOrDefault(predicate);
        }
    }
}