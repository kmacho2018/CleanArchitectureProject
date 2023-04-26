using CleanArchitectureProject.Application.Common.Exceptions;
using CleanArchitectureProject.Application.Common.Interfaces;
using CleanArchitectureProject.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Movies.Commands.DeleteMovie
{
    public record DeleteMovieCommand(int Id) : IRequest;

    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {

        private readonly IApplicationDbContext _context;
        public DeleteMovieCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movies), request.Id);
            }

            _context.Movies.Remove(entity);

            entity.AddDomainEvent(new MovieDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
