    using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication1.DBContext;
using WebApplication1.Models;

    namespace WebApplication1.Controllers
    {
    public class EventController : Controller
    {
        private readonly ApplicationDbContext1 _context;
        public EventController(ApplicationDbContext1 context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {

            var model = new Event();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Event model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Guid uniqueGuid = Guid.NewGuid();
                    model.Id = uniqueGuid;

                    if (model.EventOrganizer == null)
                    {
                        ModelState.AddModelError(nameof(Event.EventOrganizer), "Event Organizer cannot be null.");
                        return BadRequest(ModelState);
                    }

                    _context.Events.AddAsync(model);

                    var demoTickets = _context.DemoTickets.Where(x => x.EventId == 22).ToList();


                    foreach (var t in demoTickets)
                    {
                        var ticket = new Ticket();
                        ticket.TicketNo = t.TicketNo;
                        ticket.Price = t.Price;
                        ticket.EventId = model.Id;
                        _context.Ticket.AddAsync(ticket);
                    }

                    _context.DemoTickets.RemoveRange(demoTickets);
                    _context.SaveChanges();
                    return View(model);
                }
                catch( Exception e)
                {
                    Console.WriteLine($"its not {e.Message}");
                    return BadRequest();
                }
             
            }

            return View();

        }
    }
}
