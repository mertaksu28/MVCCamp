using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adı boş geçilemez");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage("En fazla 20 karakter girişi yapılabilir");
        }
    }
}
