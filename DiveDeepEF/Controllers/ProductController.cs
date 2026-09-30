using Microsoft.AspNetCore.Mvc;

namespace DiveDeepEF.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Equipment() => View();
        /* linker ikke lige nu da der ikke er repo, flyt som repo er added
            public IActionResult Fins() => View(FinsRepository.GetAll());
            public IActionResult BCD() => View(BcdRepository.GetAll());
            public IActionResult Mask() => View(MaskRepository.GetAll());
            public IActionResult Regulator() => View(RegulatorSetRepository.GetAll());
            public IActionResult Suit() => View(SuitRepository.GetAll());
            public IActionResult Tank() => View(TankRepository.GetAll());
        */
    }
}
