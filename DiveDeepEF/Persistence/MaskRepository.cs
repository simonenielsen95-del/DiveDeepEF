using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class MaskRepository
    {
        private static List<Mask> masks = new List<Mask>
        {
            new Mask { Id = 1, Brand = "Scubapro", Model = "Ghost", PricePerDay = 50 },
            new Mask { Id = 2, Brand = "Scubapro", Model = "D-Mask", PricePerDay = 60 },
            new Mask { Id = 3, Brand = "Scubapro", Model = "Spectra Mini", PricePerDay = 50 },
            new Mask { Id = 4, Brand = "Scubapro", Model = "Crystal VU", PricePerDay = 75 },
            new Mask { Id = 6, Brand = "Fourth Element", Model = "Scout Enhance", PricePerDay = 75 },
            new Mask { Id = 7, Brand = "Tusa", Model = "Element", PricePerDay = 75 }
        };

        public static List<Mask> GetAll() => masks;

        public static Mask? GetById(int id) => masks.FirstOrDefault(x => x.Id == id);

        public static void Add(Mask mask)
        {
            if (mask == null) return;
            mask.Id = masks.Any() ? masks.Max(x => x.Id) + 1 : 1;
            masks.Add(mask);
        }

        public static void Delete(int id)
        {
            masks.RemoveAll(x => x.Id == id);
        }

        public static void Update(int id, Mask mask)
        {
            var target = GetById(id);
            if (target != null && mask != null)
            {
                target.Brand = mask.Brand;
                target.Model = mask.Model;
                target.PricePerDay = mask.PricePerDay;
            }
        }
    }
}
