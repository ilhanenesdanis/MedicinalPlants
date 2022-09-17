using Core.Entity;

namespace Core.IRepository
{
    public interface IPlantsRepository:IRepository<Plants>
    {
        IQueryable<Plants> GetAllPlants();
    }
}
