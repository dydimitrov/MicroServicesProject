using System.Threading.Tasks;

namespace RealEstateCommon.Services
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
