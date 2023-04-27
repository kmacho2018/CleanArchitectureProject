using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Infraestructure.Persistence.Configurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(t => t.Title)
                           .HasMaxLength(200)
                           .IsRequired();
        }
    }
}