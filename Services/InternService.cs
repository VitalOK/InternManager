using Models;
using Repository;
using System.Collections.Generic;

namespace Services
{
    public class InternService : IService<Intern>
    {
        private IRepository<Intern> _repository;

        public InternService(IRepository<Intern> repository)
        {
            _repository = repository;
        }

        public List<Intern> GetAll()
        {
            return _repository.GetAll();
        }

        public Intern GetById(int id)
        {
            var output = _repository.GetById(id);
            return output;
        }

        public void Insert(Intern t)
        {
            if (t != null) _repository.Insert(t);
        }

        public void Update(Intern t)
        {
            if (t != null) _repository.Update(t);
        }
    }
}
