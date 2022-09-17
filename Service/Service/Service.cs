using Core.IRepository;
using Core.IService;
using Core.IUnitOfWork;
using System.Linq.Expressions;

namespace Service.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void AddRange(List<T> entities)
        {
            _repository.AddRange(entities);
            _unitOfWork.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _repository.Count(expression);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return _repository.GetBy(expression).ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void UpdateRange(List<T> entities)
        {
            _repository.UpdateRange(entities);
            _unitOfWork.SaveChanges();
        }
    }
}
