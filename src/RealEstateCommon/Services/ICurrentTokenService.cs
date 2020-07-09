using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateCommon.Services
{
    public interface ICurrentTokenService
    {
        string Get();

        void Set(string token);
    }
}
