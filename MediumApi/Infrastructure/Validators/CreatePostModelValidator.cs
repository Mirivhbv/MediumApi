using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediumApi.Models;

namespace MediumApi.Infrastructure.Validators
{
    public class CreatePostModelValidator : AbstractValidator<CreatePostModel>
    {
        public CreatePostModelValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("The title must be at least 5 character long");
            RuleFor(x => x.Title)
                .MinimumLength(5)
                .WithMessage("The title must be at least 5 character long");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("The description must be at least 20 character long");
            RuleFor(x => x.Description)
                .MinimumLength(20)
                .WithMessage("The description must be at least 20 character long");
        }
    }
}