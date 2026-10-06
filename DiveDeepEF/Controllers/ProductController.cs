using DiveDeepEF.Data;
using DiveDeepEF.Models.Equipments;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepEF.Controllers;

public class ProductController : Controller
{
    private readonly DiveDeepEFContext repo;

    public ProductController(DiveDeepEFContext diveDeepEFContext)
    {

        repo = diveDeepEFContext;

    }

    public IActionResult Equipment() => View(repo.Equipment);
    public IActionResult Fins() => View(repo.Equipment.Where(e => e is Fins));
    public IActionResult BCD() => View(repo.Equipment.Where(e => e is BCD));
    public IActionResult Mask() => View(repo.Equipment.Where(e => e is Mask));
    public IActionResult Regulator() => View(repo.Equipment.Where(e => e is RegulatorSet));
    public IActionResult Suit() => View(repo.Equipment.Where(e => e is Suit));
    public IActionResult Tank() => View(repo.Equipment.Where(e => e is Tank));

}
