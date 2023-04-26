using CleanArchitectureProject.Application.Common.Interfaces;
using CleanArchitectureProject.Domain.Entities;
using CleanArchitectureProject.Domain.Events;
using MediatR;

namespace CleanArchitectureProject.Application.Movies.Commands.CreateMovie
{
    public record CreateMovieCommand : IRequest<int>
    {
        public string? Title { get; init; }
        public string? Description { get; init; }
        public string? Image { get; init; }
        public int? Stock { get; init; }
        public decimal? RentalPrice { get; init; }
        public decimal? SalePrice { get; init; }
        public bool Availability { get; init; }
    }

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMovieCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = new Movie
            {
                Title = request.Title,
                Description = request.Description,
                Image = request.Image,
                Stock = request.Stock,
                Availability = request.Availability,
                SalePrice = request.SalePrice,
                RentalPrice = request.RentalPrice
            };

            entity.AddDomainEvent(new MovieCreatedEvent(entity));

            _context.Movies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

