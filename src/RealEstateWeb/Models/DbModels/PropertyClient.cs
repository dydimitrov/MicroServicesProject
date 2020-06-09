using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWeb.Models.DbModels
{
    public class PropertyClient
    {
        public Property Property { get; set; }
        public int PropertyId { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }

    }
}
