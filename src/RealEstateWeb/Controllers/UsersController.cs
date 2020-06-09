using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateWeb.Models;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.ViewModels.Users;

namespace RealEstateWeb.Controllers
{
    public class UsersController : BaseController
    {
        private SignInManager<ApplicationUser> _signInManager;

        public UsersController(SignInManager<ApplicationUser> signIn)
        {
            this._signInManager = signIn;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this._signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user != null)
            {
                this._signInManager.SignInAsync(user, true).Wait();
            }
            else
            {
                return this.Login();
            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber
            };
            var result = this._signInManager.UserManager.CreateAsync(user, model.Password).Result;

            if (this._signInManager.UserManager.Users.Count() == 1)
            {
                var roleResult = this._signInManager.UserManager.AddToRoleAsync(user, "Admin").Result;
                if (roleResult.Errors.Any())
                {
                    return this.View();
                }
            }

            if (result.Succeeded)
            {

                this._signInManager.SignInAsync(user, false).Wait();
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }


    }
}