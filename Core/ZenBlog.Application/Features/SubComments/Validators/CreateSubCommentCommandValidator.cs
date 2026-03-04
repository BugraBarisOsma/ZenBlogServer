using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ZenBlog.Application.Features.SubComments.Commands;

namespace ZenBlog.Application.Features.SubComments.Validators
{
    public class CreateSubCommentCommandValidator : AbstractValidator<CreateSubCommentCommand>
    {
        public CreateSubCommentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot exceed 500 characters.");
        }
    }
}
