using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Properties.Models;
using RealEstateCommon.Services;

namespace RealEstate.Properties.Services
{
    public interface IPropertyService : IDataService<Property>
    {
        Task<IEnumerable<Property>> GetAll();

        Task<Property> GetDetails(int id);

        Task<Property> FindById(int id);

        Task<bool> Delete(int id);
    }
}
