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
    private readonly DivingPackageRepository divingPackageRepository;

    public ProductController(IEquipmentRepository repository, DivingPackageRepository divingPackageRepository)
    {
        equipmentRepository = repository;
        this.divingPackageRepository = divingPackageRepository;
    }
    public async Task<IActionResult> DivingPackageDetails(int id)
    {
        var package = await divingPackageRepository.GetByIdAsync(id);

        if (package == null)
        {
            return NotFound();
        }

        return View(package);
    }
    public IActionResult Details(int id, string type)
    {
        List<Equipment> equipmentList = type switch
        {
            "Fins" => equipmentRepository.GetAllByType<Fins>()
                .Cast<Equipment>().ToList(),

            "BCD" => equipmentRepository.GetAllByType<BCD>()
                .Cast<Equipment>().ToList(),

            "Mask" => equipmentRepository.GetAllByType<Mask>()
                .Cast<Equipment>().ToList(),

            "Regulator" => equipmentRepository.GetAllByType<RegulatorSet>()
                .Cast<Equipment>().ToList(),

            "Suit" => equipmentRepository.GetAllByType<Suit>()
                .Cast<Equipment>().ToList(),

            "Tank" => equipmentRepository.GetAllByType<Tank>()
                .Cast<Equipment>().ToList(),

            _ => new List<Equipment>()
        };

        var selectedProduct = equipmentList.FirstOrDefault(x => x.Id == id);

        if (selectedProduct == null)
        {
            return NotFound();
        }

        // Get all variants of the selected product.
        // This example uses Brand; we can refine it if your models have
        // different properties for identifying a product.
        var variants = equipmentList
      .Where(x => x.Brand == selectedProduct.Brand)
      .OrderBy(x => x.Id == selectedProduct.Id ? 0 : 1)
      .ToList();

        ViewBag.Type = type;

        return View(variants);
    }

    public IActionResult Equipment() => View(equipmentRepository.GetAll());
    public IActionResult Fins() => View(equipmentRepository.GetAllByType<Fins>());
    public IActionResult BCD() => View(equipmentRepository.GetAllByType<BCD>());

    public IActionResult Mask() => View(equipmentRepository.GetAllByType<Mask>());
    public IActionResult Regulator() => View(equipmentRepository.GetAllByType<RegulatorSet>());
    public IActionResult Suit() => View(equipmentRepository.GetAllByType<Suit>());
    public IActionResult Tank() => View(equipmentRepository.GetAllByType<Tank>());

    public async Task<IActionResult> DivingPackage()
    {
        var packets = await divingPackageRepository.GetAllAsync();


        return View(packets);
    }
}


