using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.Models.Identity;
using RealEstate.Services.Identity;
using Refit;
using static RealEstateCommon.Infrastructure.InfrastructureConstants;

namespace RealEstate.Controllers
{
    public class UsersController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;

        public UsersController(
            IIdentityService identityService,
            IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
            => await this.Handle(
                async () =>
                {
                    var modelToSend = new UserInputModel() { Email = model.Email, Password = model.Password };
                    var result = await this.identityService
                        .Login(modelToSend);

                    this.Response.Cookies.Append(
                        AuthenticationCookieName,
                        result.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            MaxAge = TimeSpan.FromDays(1)
                        });
                },
                success: RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: View("../Home/Index", model));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterFormModel model)
            => await this.Handle(
                async () =>
                {
                    var mdl = new UserInputModel() { Email = model.Email, Password = model.Password };
                    var result = await this.identityService
                        .Register(mdl);
                },
                success: RedirectToAction(nameof(UsersController.Login), "Users"),
                failure: View("../Users/Register", model));

        public IActionResult Logout()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.Response.Cookies.Delete(AuthenticationCookieName);
            }                

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        protected async Task<ActionResult> Handle(Func<Task> action, ActionResult success, ActionResult failure)
        {
            try
            {
                await action();
                return success;
            }
            catch (ApiException exception)
            {
                this.ProcessErrors(exception);
                return failure;
            }
        }

        private void ProcessErrors(ApiException exception)
        {
            if (exception.HasContent)
            {
                JsonConvert
                    .DeserializeObject<List<string>>(exception.Content)
                    .ForEach(error => this.ModelState.AddModelError(string.Empty, error));
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Internal server error.");
            }
        }
    }
}