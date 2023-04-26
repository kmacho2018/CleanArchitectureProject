using CleanArchitectureProject.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Movies.EventHandlers
{

    public class MovieCreatedEventHandler : INotificationHandler<MovieCreatedEvent>
    {
        private readonly ILogger<MovieCreatedEventHandler> _logger;

        public MovieCreatedEventHandler(ILogger<MovieCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MovieCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
