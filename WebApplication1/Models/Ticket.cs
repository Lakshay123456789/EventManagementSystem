namespace WebApplication1.Models
{
    public class Ticket
    {

        public int Id { get; set; }
        public int TicketNo { get; set; }
        public decimal Price { get; set; }
      
        public Guid EventId { get; set; }
        public Event ? Event { get; set; }
    }
}
