using RealEstateWeb.Services.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealEstateWeb.Data;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.Enums;
using RealEstateWeb.Models.ViewModels.Property;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;

namespace RealEstateWeb.Services
{
    public class PropertyService : IPropertyService
    {
        private const int MaxPropertiesPerPage = 3;
        private readonly ApplicationDbContext _context;

        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateProperty(PropertyCreateViewModel model, string agentUsername)
        {
            try
            {
                var property = new Property
                {
                    Title = model.Title,
                    Currency = model.Currency,
                    Price = model.Price,
                    Description = model.Description
                };

                this._context.Properties.Add(property);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public List<PropertyIndexViewModel> IndexProperties()
        {
            var result = this._context.Properties
                .Include(y => y.Address)
                .OrderByDescending(p => p.CreatedOn)
                .Take(3)
                .Select(x => new PropertyIndexViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Currency = x.Currency
                }).ToList();

            foreach (var item in result)
            {
                item.PictureUrl = item.PictureUrl.Replace(@"upload/", "upload/h_450,w_1300/");
                item.PictureUrlMenuBottom = item.PictureUrl.Replace(@"upload/", "upload/h_130,w_150/");
            }

            return result;
        }

        public List<PropertyIndexViewModel> RandomProperties()
        {
            var result = this._context.Properties
                .Include(y => y.Address)
                .OrderByDescending(p => p.Price)
                .Take(MaxPropertiesPerPage)
                .Select(x => new PropertyIndexViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Currency = x.Currency
                }).ToList();            

            return result;
        }

        public IEnumerable<PropertyListingViewModel> AllProperty()
        {
            return this._context
                .Properties
                .Select(p => new PropertyListingViewModel()
                {
                    Id = p.Id,
                    CreatedOn = p.CreatedOn,
                    Price = p.Price,
                    Title = p.Title,
                    Description = p.Description,
                    CurrencyType = p.Currency
                });
        }

        public SinglePropertyDetailsViewModel Details(int id)
        {
            var model = this._context.Properties
                .Where(p => p.Id == id)
                .Select(x => new SinglePropertyDetailsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    Currency = x.Currency.ToString(),
                    Status = x.PropertyStatus.ToString(),
                }).FirstOrDefault();

            if (model == null)
            {
                return null;
            }

            return model;
        }

        public List<MyPropertiesViewModel> MyProperties(string username)
        {
            return this._context.Properties
                .Select(p => new MyPropertiesViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Currency = p.Currency.ToString()
                })
                .ToList();
        }

        public bool Remove(int id)
        {
            var property = this._context.Properties.FirstOrDefault(p => p.Id == id);
            
            if (property != null)
            {
                var appointmentsForApartment = this._context.Appointments.Where(x => x.PropertyId == property.Id).ToList();
                this._context.Appointments.RemoveRange(appointmentsForApartment);
                this._context.Properties.Remove(property);
                this._context.SaveChanges();
                return true;
            }

            return false;
        }

        public PropertyUpdateViewModel Edit(int id)
        {
            var model = this._context.Properties
                .First(x => x.Id == id);

            return new PropertyUpdateViewModel()
            {
                Id = model.Id,
                Currency = model.Currency,
                Description = model.Description,
                Price = model.Price,
                Title = model.Title,

            };
        }

        public void Update(PropertyUpdateViewModel model)
        {
            var modelDb = this._context.Properties
                .FirstOrDefault(x => x.Id == model.Id);

            modelDb.Title = model.Title;
            modelDb.CreatedOn = DateTime.UtcNow;
            modelDb.Description = model.Description;
            modelDb.Currency = model.Currency;
            modelDb.Price = model.Price;

            this._context.SaveChanges();
        }
    }
}
