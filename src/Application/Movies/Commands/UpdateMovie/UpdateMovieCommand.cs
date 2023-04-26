using CleanArchitectureProject.Application.Common.Exceptions;
using CleanArchitectureProject.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Movies.Commands.UpdateMovie
{
    public record UpdateMovieCommand : IRequest
    {
        public int MovieId { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public string? Image { get; init; }
        public int? Stock { get; init; }
        public decimal? RentalPrice { get; init; }
        public decimal? SalePrice { get; init; }
        public bool Availability { get; init; }
    }
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMovieCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies
                        .FindAsync(new object[] { request.MovieId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movies), request.MovieId);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Image = request.Image;   
            entity.Stock = request.Stock;
            entity.SalePrice = request.SalePrice;
            entity.RentalPrice = request.RentalPrice;
            entity.Availability = request.Availability;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
