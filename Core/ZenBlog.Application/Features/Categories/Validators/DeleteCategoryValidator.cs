using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Categories.Validators
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.id)
                .NotEqual(Guid.Empty).WithMessage("Invalid category ID.")
                .NotEmpty().WithMessage("Id cannot be null or empty");
        }
    }
}
