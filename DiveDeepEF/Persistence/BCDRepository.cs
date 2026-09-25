using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class BCDRepository
    {
        private static List<BCD> bcds = new List<BCD>
        {
            new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite", Size = "S, M, L", PricePerDay = 125 },
            new BCD { Id = 2, Brand = "Scubapro", Model = "Glide", Size = "S, M, L", PricePerDay = 140 },
            new BCD { Id = 3, Brand = "Scubapro", Model = "Hydros Pro", Size = "S, M, L", PricePerDay = 200 },
            new BCD { Id = 4, Brand = "Seac", Model = "Modular", Size = "S, M, L", PricePerDay = 145 }
        };

        public static List<BCD> GetAll() => bcds;

        public static BCD? GetById(int id) => bcds.FirstOrDefault(x => x.Id == id);

        public static void Add(BCD bcd)
        {
            if (bcd == null) return;
            bcd.Id = bcds.Any() ? bcds.Max(x => x.Id) + 1 : 1;
            bcds.Add(bcd);
        }

        public static void Delete(int id)
        {
            bcds.RemoveAll(x => x.Id == id);
        }

        public static void Update(int id, BCD bcd)
        {
            var target = GetById(id);
            if (target != null && bcd != null)
            {
                target.Brand = bcd.Brand;
                target.Model = bcd.Model;
                target.Size = bcd.Size;
                target.PricePerDay = bcd.PricePerDay;
            }
        }

    }
}
