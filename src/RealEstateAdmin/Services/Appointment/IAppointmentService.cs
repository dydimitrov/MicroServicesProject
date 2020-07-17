using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace RealEstate.Services.Appointment
{
    public interface IAppointmentService
    {
        [Post("/Appointment/Create")]
        Task Create(int propertyId, string username);
    }
}
