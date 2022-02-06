using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(c => c.ReceiverMail).NotEmpty().WithMessage("Alıcı Mail Adresi boş geçilemez");
            RuleFor(c => c.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(c => c.Content).NotEmpty().WithMessage("İçerik boş geçilemez");
            //RuleFor(c => c.ReceiverMail).NotEmpty().WithMessage("Mail alanı boş geçilemez");//Geçerli bir mail adresi olsun
            RuleFor(c => c.Subject).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız");
            RuleFor(c => c.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapılabilir");
        }
    }
}
