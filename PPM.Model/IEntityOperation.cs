public interface IEntityOperation<T>
{
    public void Add(T entity);
    public List<T> Get();

    public T ViewById(int id);

    public void Delete(int id);

}