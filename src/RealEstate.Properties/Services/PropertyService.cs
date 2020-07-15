using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Properties.Data;
using RealEstate.Properties.Models;
using RealEstateCommon.Services;

namespace RealEstate.Properties.Services
{
    public class PropertyService : DataService<Property>, IPropertyService
    {
        private readonly IMapper _mapper;

        public PropertyService(PropertiesDbContext db, IMapper mapper)
            : base(db)
        {
            _mapper = mapper;
        }

        public async Task<Property> FindById(int id)
            => await this.Data.FindAsync<Property>(id);

        public async Task<IEnumerable<Property>> GetAll()
            => await this.All().ToListAsync();

        public async Task<Property> GetDetails(int id)
            => await this._mapper
                .ProjectTo<Property>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<Property>> GetDetailsByUsername(string username)
        {
            var data = await this.All()
                    .Where(x => x.OwnerId == username)
                    .ToListAsync();
            return this._mapper
                .ProjectTo<Property>(data.AsQueryable());
        }

        public async Task<bool> Delete(int id)
        {
            var property = await this.Data.FindAsync<Property>(id);

            if (property == null)
            {
                return false;
            }

            this.Data.Remove(property);

            await this.Data.SaveChangesAsync();

            return true;
        }
    }
}
