namespace SoftServe_Practice.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
        public decimal TicketPrice { get; set; }

        public Movie Movie { get; set; }
    }
}
