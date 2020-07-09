﻿namespace RealEstateAdmin.Services.Identity
{
    using System.Threading.Tasks;
    using RealEstateAdmin.Models.Identity;
    using Refit;

    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);

        [Post("/Identity/Register")]
        Task<UserOutputModel> Register([Body] UserInputModel loginInput);
    }
}
