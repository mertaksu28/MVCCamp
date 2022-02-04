using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(c => c.WriterName).NotEmpty().WithMessage("Yazar Adı boş geçilemez");
            RuleFor(c => c.WriterSurName).NotEmpty().WithMessage("Yazar SoyAdı boş geçilemez");
            RuleFor(c => c.WriterMail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(c => c.WriterName).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(c => c.WriterSurName).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapılabilir");
        }
    }
}
