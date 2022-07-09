using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty()
                                     .WithMessage("Blog Title Can't be null!!");

            RuleFor(x => x.BlogContent).NotEmpty()
                                       .WithMessage("Blog Content Can't be null!!");

            RuleFor(x => x.BlogImage).NotEmpty()
                                     .WithMessage("Blog Picture Can't be null!!");

            RuleFor(x => x.BlogTitle).MaximumLength(150)
                                     .WithMessage("Please enter less than 150 character");

            RuleFor(x => x.BlogTitle).MinimumLength(5)
                                     .WithMessage("Please enter less than 5 character");
        }
    }
}
