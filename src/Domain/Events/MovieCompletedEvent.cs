namespace CleanArchitectureProject.Domain.Events
{
    public class MovieCompletedEvent : BaseEvent
    {
        public MovieCompletedEvent(Movie movie)
        {
            Movie = movie;
        }
        public Movie Movie { get; }
    }
}
