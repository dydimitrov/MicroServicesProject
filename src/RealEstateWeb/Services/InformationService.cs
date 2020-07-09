using System;
using System.Collections.Generic;
using System.Text;
using RealEstateWeb.Data;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.ViewModels.Contact;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Services
{
    public class InformationService : IInformationService
    {
        private readonly ApplicationDbContext _context;

        public InformationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateNewsLetterClient(string email)
        {
            var isValidEmail = RegexUtilities.IsValidEmail(email);
            if (!isValidEmail)
            {
                return false;
            }
            else
            {
                var client = new NewsLetterClient
                {
                    Email = email
                };
                _context.ClientsForNewsLetter.Add(client);
                _context.SaveChanges();
                return true;
            }
        }

        public bool CreateContactRequest(string name, string email, string phoneNumber, string city, string subject, string message)
        {
            var isValidEmail = RegexUtilities.IsValidEmail(email);
            if (isValidEmail && !string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(city) &&
                !string.IsNullOrWhiteSpace(subject) &&
                !string.IsNullOrWhiteSpace(message))
            {
                var client = new ContactRequestViewModel
                {
                    Name = name,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    City = city,
                    Subject = subject,
                    Message = message
                };
                _context.ContactRequests.Add(client);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
