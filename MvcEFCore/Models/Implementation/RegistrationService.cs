using HotelWebApplication.EF_Data;
using HotelWebApplication.Models.Poco_Class;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MvcEFCore.Models.Abstraction;
using MvcEFCore.Models.PocoClass;

using StayCation.Models.StaycationRepos;

namespace StayCation.Models.Implementation
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IAuthentication _authentication;
        private readonly HotelDbContext _userDbContext;

        public RegistrationService(IAuthentication authentication, HotelDbContext userDbContext)
        {
            _authentication = authentication;
            _userDbContext = userDbContext;
        }

        public bool ValidateRegistration(SignUPVM signUPVM, ModelStateDictionary modelState)
        {
            if (signUPVM.Password != signUPVM.ConfirmPassword)
            {
                modelState.AddModelError(nameof(SignUPVM.ConfirmPassword), "Password does not match");
                return false;
            }

            var userFound = _authentication.GetUser(signUPVM.Email);
            if (userFound != null)
            {
                modelState.AddModelError(nameof(SignUPVM.Email), "User already exists");
                return false;
            }

            return true;
        }

        public async Task SignUpUser(SignUPVM registrationDetails)
        {
            var user = new Customer()
            {
                Email = registrationDetails.Email,
                Password = registrationDetails.Password,
                ConfirmPassword = registrationDetails.ConfirmPassword,
                PhoneNumber = registrationDetails.PhoneNumber,
                FirstName = registrationDetails.FirstName,
                LastName = registrationDetails.LastName,
                Address = registrationDetails.Address,
            };

            // Additional logic for signing up the user

            _authentication.Signup(user);
            await _userDbContext.SaveChangesAsync();
        }
    }
}
