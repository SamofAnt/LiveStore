namespace LiveStore.ORM.Repositories;

public interface IRepository<TEntity>
    where TEntity: class 
{
    TEntity GetById(Guid id);
    IEnumerable<TEntity> GetAll();
    TEntity AddProduct(TEntity product);
}