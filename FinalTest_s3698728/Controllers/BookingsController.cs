using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalTest_s3698728.Data;
using FinalTest_s3698728.Models;

namespace FinalTest_s3698728.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BookingContext _context;

        public BookingsController(BookingContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookingContext = _context.Bookings.Include(b => b.Room).Include(b => b.Staff);
            return View(await bookingContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.Staff)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID");
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "StaffID");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomID,BookingDate,StaffID")] Bookings bookings)
        {
            //Date checker
            if (bookings.BookingDate < DateTime.UtcNow)
            {
                ModelState.AddModelError("BookingDate", "Booking Date cannot be ealier than today");
            }
            List<Bookings> booking = await _context.Bookings.Where(x => x.BookingDate == bookings.BookingDate).ToListAsync();
            if(booking.Count != 0)
            {
                ModelState.AddModelError("BookingDate", "It is already been booked");
            }
            if (ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", bookings.RoomID);
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "StaffID", bookings.StaffID);
            return View(bookings);
        }

    }
}
