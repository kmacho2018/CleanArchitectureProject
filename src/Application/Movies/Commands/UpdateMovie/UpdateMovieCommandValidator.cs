using FluentValidation;

namespace CleanArchitectureProject.Application.Movies.Commands.UpdateMovie
{ 
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(v => v.Title)
           .MaximumLength(200)
           .NotEmpty();
        }
    }
}
