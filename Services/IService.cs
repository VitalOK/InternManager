using System.Collections.Generic;

namespace Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T t);
        void Update(T t);
    }
}
