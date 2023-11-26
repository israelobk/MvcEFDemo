using Microsoft.AspNetCore.Mvc.ModelBinding;
using MvcEFCore.Models.PocoClass;

namespace StayCation.Models.StaycationRepos;

public interface IRegistrationService
{
    bool ValidateRegistration(SignUPVM signUPVM, ModelStateDictionary modelState);
    Task SignUpUser(SignUPVM signUPVM);
}