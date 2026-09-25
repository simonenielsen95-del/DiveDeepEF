using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class SuitRepository
    {
        private static List<Suit> suits = new List<Suit>
        {
            new Suit { Id = 1, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 3, PricePerDay = 100 },
            new Suit { Id = 2, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 5, PricePerDay = 100 },
            new Suit { Id = 3, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 7, PricePerDay = 100 },
            new Suit { Id = 4, Brand = "Waterproof", Model = "W5", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 3.5 , PricePerDay = 100 },
            new Suit { Id = 5, Brand = "Fourth Element", Model = "Proteus", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 5, PricePerDay = 120 },
            new Suit { Id = 6, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 300 },
            new Suit { Id = 7, Brand = "Waterproof", Model = "D7 Evo", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 320 },
            new Suit { Id = 8, Brand = "Santi", Model = "E.Lite Plus", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 350 }
        };

        public static List<Suit> GetAll() => suits;

        public static Suit? GetById(int id) => suits.FirstOrDefault(x => x.Id == id);

        public static void Add(Suit suit)
        {
            if (suit == null) return;
            suit.Id = suits.Any() ? suits.Max(x => x.Id) + 1 : 1;
            suits.Add(suit);
        }

        public static void Delete(int id)
        {
            suits.RemoveAll(x => x.Id == id);
        }

        public static void Update(int id, Suit suit)
        {
            var target = GetById(id);
            if (target != null && suit != null)
            {
                target.Brand = suit.Brand;
                target.Model = suit.Model;
                target.Size = suit.Size;
                target.Type = suit.Type;
                target.Gender = suit.Gender;
                target.Thickness = suit.Thickness;
                target.PricePerDay = suit.PricePerDay;
            }
        }
    }
}
