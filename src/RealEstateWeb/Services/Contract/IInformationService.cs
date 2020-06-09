using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWeb.Services.Contract
{
    public interface IInformationService
    {
        bool CreateNewsLetterClient(string email);
        bool CreateContactRequest(
            string name,
            string email,
            string phoneNumber,
            string city,
            string subject,
            string message);

    }
}
