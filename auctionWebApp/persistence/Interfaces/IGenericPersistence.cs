using System.Linq.Expressions;

namespace auctionWebApp.persistence.Interfaces;

public interface IGenericPersistence<T> where T : BaseDB
{
    public void Add(T entity);
    public void Delete(T entity);
    public void Update(T entity);

    public List<T> GetAll(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    public T GetById(int id, Expression<Func<T, object>>? include = null);
}