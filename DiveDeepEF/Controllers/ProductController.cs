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


