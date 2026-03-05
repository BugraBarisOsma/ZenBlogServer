using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ZenBlog.Application.Features.ContactInfos.Commands;

namespace ZenBlog.Application.Features.ContactInfos.Validators
{
    public class CreateContactInfoCommandValidator : AbstractValidator<CreateContactInfoCommand>
    {
        public CreateContactInfoCommandValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Address is required").EmailAddress().WithMessage("Email type is not supported");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
        }
    }
}
