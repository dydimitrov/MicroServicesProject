using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateAppointment.Data;
using RealEstateCommon.Controllers;
using RealEstateCommon.Messages;
using RealEstateNewsLetter.Models;

namespace RealEstateAppointment.Controllers
{

    public class AppointmentController : ApiController
    {
        private readonly AppointmentDbContext _context;
        private readonly IBus _publisher;
        public AppointmentController(AppointmentDbContext context, IBus publisher)
        {
            _context = context;
            _publisher = publisher;
        }
        [HttpPost]
        [Authorize]
        [Route("/Appointment/Create")]
        public async Task Create(int propertyId, string username)
        {
            var model = new Appointment()
            {
                UserId = username,
                PropertyId = propertyId
            };
            await _context.Appointments.AddAsync(model);
            await _context.SaveChangesAsync();
            await _publisher.Publish(new AppointmentCreatedMessage()
            {
                PropertyId = model.PropertyId
            });
        }
    }
}