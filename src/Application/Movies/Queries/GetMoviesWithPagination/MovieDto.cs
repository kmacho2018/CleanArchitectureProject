using CleanArchitectureProject.Application.Common.Mappings;
using CleanArchitectureProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Movies.Queries.GetMoviesWithPagination
{
    public class MovieDto : IMapFrom<Movie>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Stock { get; set; }
        public decimal? RentalPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public bool Availability { get; set; }
    }
}
