using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Categories.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.")
                .MinimumLength(3).WithMessage("Category name must be at least 3 characters");
            RuleFor(x => x.id)
                .NotEqual(Guid.Empty).WithMessage("Invalid category ID.")
                .Empty().WithMessage("Id is required");
        }
    }
}
