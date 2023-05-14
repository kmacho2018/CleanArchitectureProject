using CleanArchitectureProject.Application.Common.Models;
using CleanArchitectureProject.Application.Movies.Commands.CreateMovie;
using CleanArchitectureProject.Application.Movies.Commands.DeleteMovie;
using CleanArchitectureProject.Application.Movies.Commands.UpdateMovie;
using CleanArchitectureProject.Application.Movies.Queries.GetMoviesWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Authorize]

    public class MovieController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<PaginatedList<MovieDto>>> GetMoviesWithPagination([FromQuery] GetMoviesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateMovieCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(UpdateMovieCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMovieCommand(id));

            return NoContent();
        }
    }
}
