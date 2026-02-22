using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ZenBlog.Application.Features.Users.Commands;

namespace ZenBlog.Application.Features.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname is required").MinimumLength(2);
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required").MinimumLength(2);
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required").MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6);
        }
    }
}
