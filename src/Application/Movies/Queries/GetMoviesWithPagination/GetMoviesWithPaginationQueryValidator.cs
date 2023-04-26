using FluentValidation;
using System;
using System.Collections.Generic;
namespace CleanArchitectureProject.Application.Movies.Queries.GetMoviesWithPagination
{
    public class GetMoviesWithPaginationQueryValidator : AbstractValidator<GetMoviesWithPaginationQuery>
    {
        public GetMoviesWithPaginationQueryValidator()
        {
            RuleFor(x => x.MovieId)
          .NotEmpty().WithMessage("MovieId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
