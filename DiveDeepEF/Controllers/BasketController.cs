
using DiveDeepEF.Data;
using DiveDeepEF.Models.Bookings;
using DiveDeepEF.Models.Equipments;
using Dive_Deep.Models.Equipment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepEF.Controllers;

[Authorize]
public class BasketController : Controller
{
    private readonly DiveDeepEFContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public BasketController(
        DiveDeepEFContext context,
        UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Display the user's bookings and both types of basket items.
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        var bookings = await _context.Bookings
            .Include(b => b.BasketItems)
                .ThenInclude(item => item.Equipment)
            .Include(b => b.BasketItems)
                .ThenInclude(item => item.DivingPackage)
            .Where(b => b.UserId == userId &&
                        b.EndDate >= DateTime.Today)
            .OrderBy(b => b.StartDate)
            .ToListAsync();

        return View(bookings);
    }

    // Add a diving package to the basket.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPackage(
        int packageId,
        int amount,
        DateTime startDate,
        DateTime endDate)
    {
        if (amount < 1 || amount > 20 ||
            startDate.Date < DateTime.Today ||
            endDate.Date < startDate.Date)
        {
            return BadRequest("Ugyldig mængde eller dato.");
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Challenge();
        }

        var package = await _context.DivingPackages
            .FirstOrDefaultAsync(p => p.Id == packageId);

        if (package == null)
        {
            return NotFound("Dykkerpakken blev ikke fundet.");
        }

        var booking = await _context.Bookings
            .Include(b => b.BasketItems)
            .FirstOrDefaultAsync(b =>
                b.UserId == user.Id &&
                b.StartDate.Date == startDate.Date &&
                b.EndDate.Date == endDate.Date);

        if (booking == null)
        {
            booking = new Booking
            {
                UserId = user.Id,
                CostumerName = user.UserName ?? "",
                CostumerEmail = user.Email ?? "",
                StartDate = startDate.Date,
                EndDate = endDate.Date
            };

            _context.Bookings.Add(booking);
        }

        var existingItem = booking.BasketItems
            .FirstOrDefault(item =>
                item.DivingPackageId == packageId);

        if (existingItem != null)
        {
            if (existingItem.Quantity + amount > 20)
            {
                return BadRequest("Maksimalt 20 af samme vare.");
            }

            existingItem.Quantity += amount;
            existingItem.Days =
                (endDate.Date - startDate.Date).Days + 1;
        }
        else
        {
            booking.BasketItems.Add(new BasketItem
            {
                DivingPackageId = package.Id,
                DivingPackage = package,
                Quantity = amount,
                Days = (endDate.Date - startDate.Date).Days + 1
            });
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // Add individual equipment, such as fins, to the basket.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(
        int equipmentId,
        string equipmentType,
        int amount,
        DateTime startDate,
        DateTime endDate)
    {
        if (amount < 1 || amount > 20 ||
            startDate.Date < DateTime.Today ||
            endDate.Date < startDate.Date)
        {
            return BadRequest("Ugyldig mængde eller dato.");
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Challenge();
        }

        var equipment = await _context.Equipments
            .FirstOrDefaultAsync(e => e.Id == equipmentId);

        if (equipment == null)
        {
            return NotFound("Udstyret blev ikke fundet.");
        }

        var booking = await _context.Bookings
            .Include(b => b.BasketItems)
            .FirstOrDefaultAsync(b =>
                b.UserId == user.Id &&
                b.StartDate.Date == startDate.Date &&
                b.EndDate.Date == endDate.Date);

        if (booking == null)
        {
            booking = new Booking
            {
                UserId = user.Id,
                CostumerName = user.UserName ?? "",
                CostumerEmail = user.Email ?? "",
                StartDate = startDate.Date,
                EndDate = endDate.Date
            };

            _context.Bookings.Add(booking);
        }

        var existingItem = booking.BasketItems
            .FirstOrDefault(item =>
                item.EquipmentId == equipmentId);

        if (existingItem != null)
        {
            if (existingItem.Quantity + amount > 20)
            {
                return BadRequest("Maksimalt 20 af samme vare.");
            }

            existingItem.Quantity += amount;
            existingItem.Days =
                (endDate.Date - startDate.Date).Days + 1;
        }
        else
        {
            booking.BasketItems.Add(new BasketItem
            {
                EquipmentId = equipment.Id,
                Equipment = equipment,
                Quantity = amount,
                Days = (endDate.Date - startDate.Date).Days + 1
            });
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // Remove one basket item.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(int basketItemId)
    {
        var userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        var item = await _context.BasketItems
            .Include(bi => bi.Booking)
            .FirstOrDefaultAsync(bi =>
                bi.Id == basketItemId &&
                bi.Booking.UserId == userId);

        if (item == null)
        {
            return NotFound();
        }

        _context.BasketItems.Remove(item);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
