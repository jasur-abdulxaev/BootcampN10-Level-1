namespace UserRegistrationApp.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T? Find(Func<T, bool> predicate);
    }
}