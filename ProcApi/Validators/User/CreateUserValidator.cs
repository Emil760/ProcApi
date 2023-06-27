using FluentValidation;
using ProcApi.DTOs.User;

namespace ProcApi.Validators.User
{
    public class CreateUserValidator : AbstractValidator<AddUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("first name cant be empty");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("last name cant be empty");
            RuleFor(u => u.Age).GreaterThan(17).WithMessage("should be greater than 18");
        }
    }
}
