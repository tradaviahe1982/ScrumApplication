using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScrumApplicationData.Models;
using ScrumApplication.Models.AccountViewModels;
using ScrumApplication.Models.ManageViewModels;
using ScrumApplication.Models.UserViewModels;
using ScrumApplication.Utilities;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
namespace ScrumApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IFileService _fileService;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IFileService fileService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _fileService = fileService;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index(string filter, int page = 1,
                                               string sortExpression = "Username")
        {

            var users = _userManager.Users.Select(user => new UserDetailViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl
            });

            //var model = new UserIndexViewModel
            //{
            //    Users = users
            //};

            //return View(model);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                users = users.Where(p => p.Username.Contains(filter));
            }
            var model = PagingList.Create(users, 5, page, sortExpression, "Username");
            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email
                };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    AddErrors(result);
                    
                }

                if (model.IsAdmin)
                {
                    var newRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
                    if (!newRoleResult.Succeeded)
                    {
                        AddErrors(newRoleResult);
                    }
                }
                
                user.ImageUrl = await _fileService.Save(model.Image, "images/users");
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.Id == id);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user.");
            }

            var isAdminExists = await _userManager.IsInRoleAsync(user, "Admin");

            var model = new UserEditViewModel
            {
                Id=user.Id,
                IsAdmin = isAdminExists,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user.");
            }

            //Remove exist role
            var isAdminExists = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdminExists)
            {
                var roleResult = await _userManager.RemoveFromRoleAsync(user, "Admin");
                if (!roleResult.Succeeded)
                {
                    throw new ApplicationException($"Unable to remove user role.");
                }
            }

            if (model.IsAdmin)
            {
                var newRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
                if (!newRoleResult.Succeeded)
                {
                    throw new ApplicationException($"Unable to add new user role.");
                }
            }

            var firstName = user.FirstName;
            var lastName = user.LastName;
            if (model.FirstName != firstName || model.LastName != lastName)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                var setFirstNameResult = await _userManager.UpdateAsync(user);
                if (!setFirstNameResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting firstname and lastname for user with ID '{user.Id}'.");
                }
            }

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            if (model.ChangeImage)
            {
                _fileService.Delete(user.ImageUrl);
                user.ImageUrl = await _fileService.Save(model.Image, "images/users");
                await _userManager.UpdateAsync(user);
            }
            
            StatusMessage = "Your profile has been updated";

            return RedirectToAction(nameof(Index));
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        
        #endregion
    }
}