using CustomerRegistration.Core.IRepository;

namespace CustomerRegistration.Adapter.Repository;

public class CrudRepository<T> : ICrudRepository<T> where T : class
{
    public CrudRepository()
    {
        
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
