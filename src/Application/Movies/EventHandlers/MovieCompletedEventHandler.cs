using CleanArchitectureProject.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
namespace CleanArchitectureProject.Application.Movies.EventHandlers
{

    public class MovieCompletedEventHandler : INotificationHandler<MovieCompletedEvent>
    {
        private readonly ILogger<MovieCompletedEventHandler> _logger;

        public MovieCompletedEventHandler(ILogger<MovieCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MovieCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
