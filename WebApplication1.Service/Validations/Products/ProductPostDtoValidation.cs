using FluentValidation;
using WebApplication1.Service.Dtos.Products;
using WebApplication1.Service.Extentions;

namespace WebApplication1.Service.Validations.Products
{
    public class ProductPostDtoValidation:AbstractValidator<ProductPostDto>
    {
       public ProductPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MinimumLength(5)
                .MaximumLength(30);
            RuleFor(x => x.Price)
                 .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (!x.File.isImage())
                {
                    context.AddFailure("File", "The file is not Image format");
                }

                if (!x.File.isSizeOk(2))
                {
                    context.AddFailure("File", "The file size must be less than 2mb");
                }
            });
       
        }
    }
}
