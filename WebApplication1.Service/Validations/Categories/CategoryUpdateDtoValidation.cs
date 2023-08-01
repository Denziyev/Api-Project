using FluentValidation;
using WebApplication1.Service.Dtos.Categories;

namespace WebApplication1.Service.Validations.Categories
{
    public class CategoryUpdateDtoValidation:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name can not be empty")
               .NotNull().WithMessage("Name can not be null")
               .MinimumLength(5)
               .MaximumLength(30);
            RuleFor(x => x.Description)
                 .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MinimumLength(5)
                .MaximumLength(100);
        }

    }
}
