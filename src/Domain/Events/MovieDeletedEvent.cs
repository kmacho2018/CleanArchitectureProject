namespace CleanArchitectureProject.Domain.Events
{
    public class MovieDeletedEvent : BaseEvent
    {
        public MovieDeletedEvent(Movie movie)
        {
            Movie = movie;
        }
        public Movie Movie { get; }
    }
}
