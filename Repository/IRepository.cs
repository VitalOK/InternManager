using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int Id);
        void Insert(T t);
        void Update(T t);
    }
}
