using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ZenBlog.Application.Features.Blogs.Commands;

namespace ZenBlog.Application.Features.Blogs.Validators
{
    public class CreateBlogValidators : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogValidators()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is  required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            
        }
    }
}
