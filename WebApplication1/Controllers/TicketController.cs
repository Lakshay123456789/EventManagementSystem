using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.DBContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TicketController : Controller
    {
          private readonly ApplicationDbContext1 _context;
        public TicketController(ApplicationDbContext1 context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create (TicketViewModel ticketViewModel)
        {
            try
            {
                var model = new DemoTicket
                {
                    EventId = 22,
                    Price = ticketViewModel.TicketPrice,
                    TicketNo = ticketViewModel.TicketNo,
                };
                _context.DemoTickets.AddAsync(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Event");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
         
        }
        [HttpGet]

        public List<DemoTicket> GetAll() {

            return _context.DemoTickets.AsEnumerable().ToList();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ticket = _context.DemoTickets.Find(id);

            if (ticket == null)
            {
                return NotFound(); 
            }

            _context.DemoTickets.Remove(ticket);
            _context.SaveChanges();

            return RedirectToAction("Index", "Event");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticket = _context.DemoTickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }
             ViewBag.TicketId = id;

            return View("Edit");
        }

        [HttpPost]
        public IActionResult Update(DemoTicket editViewModel)
        {
            if (ModelState.IsValid)
            {
                var ticket = _context.DemoTickets.Find(editViewModel.Id);

                if (ticket == null)
                {
                    return NotFound();
                }

                ticket.TicketNo = editViewModel.TicketNo;
                ticket.Price = editViewModel.Price;

                _context.SaveChanges();

                return RedirectToAction("Index", "Event");
            }

            return View("Edit", editViewModel);
        }

    }
}
