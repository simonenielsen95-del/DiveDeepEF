using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiveDeepEF.Data;
using DiveDeepEF.Models.Bookings;

namespace DiveDeepEF.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly DiveDeepEFContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingsController(DiveDeepEFContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Booking> bookings;
            var now = DateTime.Now;

            if (User.IsInRole("Admin"))
            {
                // Admins ser alle fremtidige bookinger
                bookings = await _context.Bookings
                    .Include(b => b.User)
                    .Include(b => b.BasketItems)
                        .ThenInclude(bi => bi.Equipment)
                    .Include(b => b.BasketItems)
                        .ThenInclude(bi => bi.DivingPackage)
                    .Where(b => b.EndDate >= now)
                    .ToListAsync();
            }
            else
            {
                // Normale brugere ser kun deres egne fremtidige bookinger
                var userId = _userManager.GetUserId(User);
                bookings = await _context.Bookings
                    .Include(b => b.BasketItems)
                        .ThenInclude(bi => bi.Equipment)
                    .Include(b => b.BasketItems)
                        .ThenInclude(bi => bi.DivingPackage)
                    .Where(b => b.UserId == userId && b.EndDate >= now)
                    .ToListAsync();
            }

            return View(bookings);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            var booking = await _context.Bookings
                 .Include(b => b.BasketItems)
                     .ThenInclude(bi => bi.Equipment)
                 .Include(b => b.BasketItems)
                     .ThenInclude(bi => bi.DivingPackage)
                 .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (booking == null) return NotFound();

            ViewBag.Equipment = await _context.Equipments
                .OrderBy(e => e.Brand)
                .ToListAsync();

            return View(booking);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var booking = new Booking
            {
                CostumerName = user?.UserName ?? "",
                CostumerEmail = user?.Email ?? "",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,EndDate")] Booking booking)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            // Udfylder automatisk fra Identity
            booking.UserId = user.Id;
            booking.CostumerName = user.UserName ?? "";
            booking.CostumerEmail = user.Email ?? "";

            // fjerner valideringsfejl for de felter, derr selv har udfyldt
            ModelState.Remove(nameof(Booking.CostumerName));
            ModelState.Remove(nameof(Booking.CostumerEmail));
            ModelState.Remove(nameof(Booking.UserId));

            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = booking.Id });
            }
            return View(booking);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (booking == null) return NotFound();
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,CostumerName,CostumerEmail,UserId,RowVersion")] Booking booking)
        {
            if (id != booking.Id) return NotFound();

            var userId = _userManager.GetUserId(User);
            if (booking.UserId != userId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // Nogen har ændret bookingen i mellemtiden
                        ModelState.AddModelError(string.Empty,
                            "Denne booking er blevet ændret af en anden bruger, siden du åbnede den. " +
                            "Dine ændringer blev ikke gemt. Genindlæs venligst siden og prøv igen.");

                        return View(booking);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            var booking = await _context.Bookings
                .Include(b => b.BasketItems)
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (booking == null) return NotFound();
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(int bookingId, int equipmentId, int quantity = 1)
        {
            var userId = _userManager.GetUserId(User);
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId && b.UserId == userId);
            if (booking == null) return NotFound();

            var equipment = await _context.Equipments.FindAsync(equipmentId);
            if (equipment == null) return NotFound();

            if (booking.EndDate.Date < DateTime.Today)
            {
                TempData["Error"] = "Bookingen er udløbet.";
                return RedirectToAction(nameof(Details), new { id = bookingId });
            }

            quantity = Math.Clamp(quantity, 1, 20);

            // BasketItem has no quantity column, so one row per unit
            for (var i = 0; i < quantity; i++)
            {
                _context.BasketItems.Add(new BasketItem
                {
                    BookingId = bookingId,
                    EquipmentId = equipmentId
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = bookingId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int basketItemId)
        {
            var userId = _userManager.GetUserId(User);
            var item = await _context.BasketItems
                .Include(bi => bi.Booking)
                .FirstOrDefaultAsync(bi => bi.Id == basketItemId && bi.Booking.UserId == userId);
            if (item == null) return NotFound();

            var bookingId = item.BookingId;
            _context.BasketItems.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = bookingId });
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}