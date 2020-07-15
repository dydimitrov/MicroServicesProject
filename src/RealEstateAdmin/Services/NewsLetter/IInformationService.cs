using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Models.NewsLetter;
using Refit;

namespace RealEstate.Services.NewsLetter
{
    public interface IInformationService
    {
        [Post("/News/Create")]
        Task Create(string email);
    }
}
