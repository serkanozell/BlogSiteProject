using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("Writer name and surname can't be null");

            RuleFor(w => w.WriterMail).NotEmpty().WithMessage("mail can't be null!");

            RuleFor(w => w.WriterPassword).NotEmpty()
                                          .WithMessage("password can't be null!")
                                          .Matches(@"[A-Z]+")
                                          .WithMessage("password must contain uppercase letter")
                                          .Matches(@"[a-z]+")
                                          .WithMessage("password must contain lowercase letter")
                                          .Matches(@"[0-9]+")
                                          .WithMessage("Your password must contain at least one number");

            RuleFor(w => w.WriterName).MinimumLength(2)
                                      .WithMessage("Name part must contain two letter");
            RuleFor(w => w.WriterName).MaximumLength(50)
                                      .WithMessage("Name part can have maximum 50 character");
        }
    }
}
