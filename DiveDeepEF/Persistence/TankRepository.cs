using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class TankRepository
    {
        private static List<Tank> tanks = new List<Tank>
        {
            new Tank { Id = 1, Brand = "Scubapro", Volume = 5, PricePerDay = 150 },
            new Tank { Id = 2, Brand = "Scubapro", Volume = 10, PricePerDay = 160 },
            new Tank { Id = 3, Brand = "Scubapro", Volume = 12, PricePerDay = 170 },
            new Tank { Id = 4, Brand = "Scubapro", Volume = 15, PricePerDay = 180 }
        };

        public static List<Tank> GetAll() => tanks;

        public static Tank? GetById(int id) => tanks.FirstOrDefault(x => x.Id == id);

        public static void Add(Tank tank)
        {
            if (tank == null) return;
            tank.Id = tanks.Any() ? tanks.Max(x => x.Id) + 1 : 1;
            tanks.Add(tank);
        }

        public static void Delete(int id)
        {
            tanks.RemoveAll(x => x.Id == id);
        }

        public static void Update(int id, Tank tank)
        {
            var target = GetById(id);
            if (target != null && tank != null)
            {
                target.Brand = tank.Brand;
                target.Volume = tank.Volume;
                target.PricePerDay = tank.PricePerDay;
            }
        }
    }
}
