using System.Collections.Generic;
using  System.Linq;
using RealEstateWeb.Data;
using RealEstateWeb.Models.ViewModels.Contact;
using RealEstateWeb.Models.ViewModels.Property;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<MyPropertiesViewModel> AllProperties()
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

        public List<ContactRequestViewModel> AllContactRequest()
        {
            return this._context
                .ContactRequests
                .Select(x => new ContactRequestViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    City = x.City,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Message = x.Message,
                    Subject = x.Subject
                }).ToList();
        }

        public void DeleteContactRequest(int id)
        {
            var contact = this._context.ContactRequests.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                this._context.ContactRequests.Remove(contact);
                this._context.SaveChanges();
            }
        }
    }
}