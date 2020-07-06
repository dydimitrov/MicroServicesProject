namespace RealEstateIndetity.Services
{
    using System.Collections.Generic;
    using RealEstateIndetity.Models;
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
