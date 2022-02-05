using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez");
            RuleFor(c => c.UserMail).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(c => c.Subject).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(c => c.UserName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(c => c.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(c => c.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapılabilir");
        }
    }
}
