using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class FinsRepository
    {
        private static List<Fins> fins = new List<Fins>
        {
            new Fins
            {
                Id = 1,
                Brand = "Scubapro",
                Model = "Jet Fin",
                Size = "XS, S, M, L, XL",
                PricePerDay = 50
            },

            new Fins
            {
                Id = 2,
                Brand = "Scubapro",
                Model = "GO Travel",
                Size = "XS, S, M, L, XL",
                PricePerDay = 50
            },

            new Fins
            {
                Id = 3,
                Brand = "Scubapro",
                Model = "Seawing Supernova",
                Size = "XS, S, M, L, XL",
                PricePerDay = 60
            },

            new Fins
            {
                Id = 4,
                Brand = "Seac",
                Model = "Propulsion",
                Size = "XS, S, M, L, XL",
                PricePerDay = 50
            },

            new Fins
            {
                Id = 5,
                Brand = "Seac",
                Model = "ALA",
                Size = "XS, S, M, L, XL",
                PricePerDay = 50
            },

            new Fins
            {
                Id = 6,
                Brand = "Fourth Element",
                Model = "Tech",
                Size = "XS, S, M, L, XL",
                PricePerDay = 75
            },

            new Fins
            {
                Id = 7,
                Brand = "Fourth Element",
                Model = "Rec Fin",
                Size = "XS, S, M, L, XL",
                PricePerDay = 80
            },

        };
        public static List<Fins> GetAll() => fins;

        public static Fins? GetById(int id) => fins.FirstOrDefault(x => x.Id == id);

        public static void Add(Fins fin)
        {
            if (fin == null) return;
            fin.Id = fins.Any() ? fins.Max(x => x.Id) + 1 : 1;
            fins.Add(fin);
        }

        public static void Delete(int id)
        {
            fins.RemoveAll(x => x.Id == id);
        }

        public static void Update(int id, Fins fin)
        {
            var target = GetById(id);
            if (target != null && fin != null)
            {
                target.Brand = fin.Brand;
                target.Model = fin.Model;
                target.Size = fin.Size;
                target.PricePerDay = fin.PricePerDay;
            }
        }

    }
}
