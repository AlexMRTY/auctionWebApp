namespace auctionWebApp.persistence.Interfaces;

public interface IGenericPersistence<T> where T : BaseDB
{
    public void Add(T entity);
    public void Delete(T entity);
    public void Update(T entity);
    public List<T> GetAll();
    public T GetById(int id);
}