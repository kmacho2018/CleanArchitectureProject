using CleanArchitectureProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureProject.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
