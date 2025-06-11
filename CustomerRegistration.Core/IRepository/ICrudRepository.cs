namespace CustomerRegistration.Core.IRepository;

public interface ICrudRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Add(T entity);
}
