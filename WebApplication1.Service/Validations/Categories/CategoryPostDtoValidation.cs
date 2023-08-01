using FluentValidation;
using WebApplication1.Service.Dtos.Categories;

namespace WebApplication1.Service.Validations.Categories
{
    public class CategoryPostDtoValidation:AbstractValidator<CategoryPostDto>
    {
       public CategoryPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MinimumLength(5)
                .MaximumLength(30);
            RuleFor(x =>x.Description)
                 .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }
}
