using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ZenBlog.Application.Features.Blogs.Commands;

namespace ZenBlog.Application.Features.Blogs.Validators
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Blog Id is required");
         
        }
    }
}
