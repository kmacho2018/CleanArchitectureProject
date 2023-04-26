using FluentValidation;

namespace CleanArchitectureProject.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(v => v.Title)
           .MaximumLength(200)
           .NotEmpty();
        }
    }
}
