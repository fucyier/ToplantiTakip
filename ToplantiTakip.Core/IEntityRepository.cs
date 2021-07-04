using System.Collections.Generic;

namespace ToplantiTakip.Core
{
    public interface IEntityRepository<T>
        where T : class, new()
    {
        List<T> GetAll();
        T Get(int id);
        T Add(T entity);
        void Delete(T entity);
        T Update(T entity);
    }
}
