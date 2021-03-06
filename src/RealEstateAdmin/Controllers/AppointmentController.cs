﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Services.Appointment;

namespace RealEstate.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int propertyId)
        {
            if (propertyId == 0)
            {
                return this.BadRequest();
            }

            var username = this.User.Identity.Name;
            await this._service.Create(propertyId, username);
            return this.RedirectToAction("Details", "Property", new { id = propertyId });

        }
    }
}