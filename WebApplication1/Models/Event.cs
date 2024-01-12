namespace WebApplication1.Models
{
    public class Event
    {

        public  Guid  Id { get; set; }

        public string ? EventName { get; set; }

        public string ? EventDescription { get; set; }

        public DateTime? EventCreatedDate { get; set;}

        public DateTime? EventEndDate { get; set; }

        public string  EventOrganizer { get; set; }

        public List<Ticket> ? Tickets { get; set; }


    }
}
