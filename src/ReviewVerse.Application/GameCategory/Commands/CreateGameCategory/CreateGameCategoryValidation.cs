using FluentValidation;

namespace ReviewVerse.Application.Game.Commands.CreateGameCategory;

public class CreateGameCategoryValidation : AbstractValidator<CreateGameCategoryCommand>
{
    public CreateGameCategoryValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(200)
            .WithMessage("Name must not exceed 200 characters.");
    }
}
