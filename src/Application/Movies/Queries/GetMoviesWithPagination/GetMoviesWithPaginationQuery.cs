using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureProject.Application.Common.Interfaces;
using CleanArchitectureProject.Application.Common.Mappings;
using CleanArchitectureProject.Application.Common.Models;
using MediatR;

namespace CleanArchitectureProject.Application.Movies.Queries.GetMoviesWithPagination
{
    public record GetMoviesWithPaginationQuery: IRequest<PaginatedList<MovieDto>>
    {
        public int MovieId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
    public class GetMoviewsWithPaginationQueryHandler : IRequestHandler<GetMoviesWithPaginationQuery, PaginatedList<MovieDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviewsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<MovieDto>> Handle(GetMoviesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Movies
                       .Where(x => x.MovieId == request.MovieId)
                       .OrderBy(x => x.Title)
                       .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                       .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}   
