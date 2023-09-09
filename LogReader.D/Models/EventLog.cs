namespace LogReader.Domain
{
    public class EventLog
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
    }
}
