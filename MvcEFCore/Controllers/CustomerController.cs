using HotelWebApplication.EF_Data;
using HotelWebApplication.Models.Poco_Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcEFCore.Models.Abstraction;
using MvcEFCore.Models.PocoClass;
using StayCation.Models.StaycationRepos;

namespace MvcEFCore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HotelDbContext _demoDbContext;
       private readonly IAuthentication _authentication;
        private readonly IRegistrationService _registrationService;

        public CustomerController(HotelDbContext _demoDbContext, IAuthentication _authentication, IRegistrationService _registrationService)
        {
            this._demoDbContext = _demoDbContext;
            this._authentication = _authentication;
            this._registrationService = _registrationService;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUPVM signUPVM)
        {

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid && _registrationService.ValidateRegistration(signUPVM, ModelState))
                {
                    _registrationService.SignUpUser(signUPVM);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(signUPVM);

            /*            var userFound = _authentication.GetUser(signUPVM.Email);
                        if (userFound != null)
                        {
                            ModelState.AddModelError(nameof(SignUPVM.Email), "User already exist");

                            return View(signUPVM);
                        }*/

            /*            var customer = new Customer()
                            {
                                Id = Guid.NewGuid(),
                                Email = signUPVM.Email,
                                Password = signUPVM.Password,
                                ConfirmPassword = signUPVM.ConfirmPassword,
                                PhoneNumber = signUPVM.PhoneNumber,
                                FirstName = signUPVM.FirstName,
                                LastName = signUPVM.LastName,
                                Address = signUPVM.Address,

                            };
                            await _demoDbContext.Customers.AddAsync(customer);
                            await _demoDbContext.SaveChangesAsync();

                             return RedirectToAction(nameof(Login));*/

        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _authentication.Login(email, password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return NotFound("Invalid details");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


    }
}
