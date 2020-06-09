using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class PictureViewModel
    {
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
