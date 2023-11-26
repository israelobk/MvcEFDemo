using System.ComponentModel.DataAnnotations;

namespace MvcEFCore.Models.PocoClass
{
    public class SignUPVM
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name Should be min 2 and max 20 length")]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name Should be min 2 and max 20 length")]
        public string? LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide PhoneNumber")]
        public int? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$",
            ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet," +
            " 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string? Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Address")]
        public string? Address { get; set; }

        /*        public string FirstName { get; set; } = string.Empty;
                public string? LastName { get; set; }

                public string? Email { get; set; }

                public int? PhoneNumber { get; set; }

                public string? Password { get; set; }

                public string? ConfirmPassword { get; set; }

                public string? Address { get; set; }*/
    }
}
