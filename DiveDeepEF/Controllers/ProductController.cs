using DiveDeepEF.Data;
using DiveDeepEF.Models.Equipments;
using DiveDeepEF.Persistence;
using Microsoft.AspNetCore.Mvc;
using DiveDeepEF.Persistence;
using DiveDeepEF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepEF.Controllers;

public class ProductController : Controller
{
    //private readonly DiveDeepEFContext repo;
    private readonly IEquipmentRepository equipmentRepository;   
   

    public ProductController(IEquipmentRepository repository)
    {

        equipmentRepository = repository;



    }

    public IActionResult Equipment() => View(equipmentRepository.GetAll());
    public IActionResult Fins() => View(equipmentRepository.GetAllByType<Fins>());
    //public IActionResult Fins() => View(repo.Equipment.Where(e => e is Fins));
    public IActionResult BCD() => View(equipmentRepository.GetAllByType<BCD>());

    public IActionResult Mask() => View(equipmentRepository.GetAllByType<Mask>());
    public IActionResult Regulator() => View(equipmentRepository.GetAllByType<RegulatorSet>());
    public IActionResult Suit() => View(equipmentRepository.GetAllByType<Suit>());
    public IActionResult Tank() => View(equipmentRepository.GetAllByType<Tank>());

    public IActionResult DivingPackage()
    {
        var packets = repo.DivingPackages
            .Include(p => p.Bcd)
            .Include(p => p.Suit)
            .Include(p => p.Regulator)
            .Include(p => p.Tank)
            .Include(p => p.Fins)
            .Include(p => p.Mask)
            .ToList();

        return View(packets);
    }
}

}
