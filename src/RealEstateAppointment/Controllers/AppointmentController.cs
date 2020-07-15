using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;

namespace RealEstateAppointment.Controllers
{

    public class AppointmentController : ApiController
    {
        [HttpPost]
        [Authorize]
        [Route("/Appointment/Create")]
        public IActionResult Create()
        {
            return null;
        }

        [HttpPost]
        [Authorize]
        [Route("/Appointment/Delete")]
        public IActionResult Delete(int appointmentId)
        {
            return null;
        }
    }
}