using System;
using System.Linq;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using RealEstateWeb.Data;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(int propertyId, string username)
        {
            var property = this._context.Properties.Include(p => p.Agent).FirstOrDefault(p => p.Id == propertyId);
            var user = this._context.Users.FirstOrDefault(u => u.UserName == username);
            
            var buyer = new Client()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };
            this._context.Clients.Add(buyer);

            var appointment = new ViewAppointment()
            {
                Property = property,
                Agent = property.Agent,
                Buyer = buyer
            };

            this._context.Appointments.Add(appointment);
            this._context.SaveChanges();
        }
    }
}