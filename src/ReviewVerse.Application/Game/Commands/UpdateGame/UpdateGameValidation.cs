using FluentValidation;

namespace ReviewVerse.Application.Game.Commands.UpdateGame;

public class UpdateGameValidation : AbstractValidator<UpdateGameCommand>
{
    public UpdateGameValidation()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);
    }
}
