using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class FinsRepository
    {
        private static List<Fins> fins = new List<Fins>
        {
            new Fins { Id = 1, Brand = "Scubapro", Model = "Jet Fin", Size = "XS", PricePerDay = 50 },
            new Fins { Id = 2, Brand = "Scubapro", Model = "Jet Fin", Size = "S", PricePerDay = 50 },
            new Fins { Id = 3, Brand = "Scubapro", Model = "Jet Fin", Size = "M", PricePerDay = 50 },
            new Fins { Id = 4, Brand = "Scubapro", Model = "Jet Fin", Size = "L", PricePerDay = 50 },
            new Fins { Id = 5, Brand = "Scubapro", Model = "Jet Fin", Size = "XL", PricePerDay = 50 },

            new Fins { Id = 6, Brand = "Scubapro", Model = "GO Travel", Size = "XS", PricePerDay = 50 },
            new Fins { Id = 7, Brand = "Scubapro", Model = "GO Travel", Size = "S", PricePerDay = 50 },
            new Fins { Id = 8, Brand = "Scubapro", Model = "GO Travel", Size = "M", PricePerDay = 50 },
            new Fins { Id = 9, Brand = "Scubapro", Model = "GO Travel", Size = "L", PricePerDay = 50 },
            new Fins { Id = 10, Brand = "Scubapro", Model = "GO Travel", Size = "XL", PricePerDay = 50 },

            new Fins { Id = 11, Brand = "Scubapro", Model = "Seawing Supernova", Size = "XS", PricePerDay = 60 },
            new Fins { Id = 12, Brand = "Scubapro", Model = "Seawing Supernova", Size = "S", PricePerDay = 60 },
            new Fins { Id = 13, Brand = "Scubapro", Model = "Seawing Supernova", Size = "M", PricePerDay = 60 },
            new Fins { Id = 14, Brand = "Scubapro", Model = "Seawing Supernova", Size = "L", PricePerDay = 60 },
            new Fins { Id = 15, Brand = "Scubapro", Model = "Seawing Supernova", Size = "XL", PricePerDay = 60 },

            new Fins { Id = 16, Brand = "Seac", Model = "Propulsion", Size = "XS", PricePerDay = 50 },
            new Fins { Id = 17, Brand = "Seac", Model = "Propulsion", Size = "S", PricePerDay = 50 },
            new Fins { Id = 18, Brand = "Seac", Model = "Propulsion", Size = "M", PricePerDay = 50 },
            new Fins { Id = 19, Brand = "Seac", Model = "Propulsion", Size = "L", PricePerDay = 50 },
            new Fins { Id = 20, Brand = "Seac", Model = "Propulsion", Size = "XL", PricePerDay = 50 },

            new Fins { Id = 21, Brand = "Seac", Model = "ALA", Size = "XS", PricePerDay = 50 },
            new Fins { Id = 22, Brand = "Seac", Model = "ALA", Size = "S", PricePerDay = 50 },
            new Fins { Id = 23, Brand = "Seac", Model = "ALA", Size = "M", PricePerDay = 50 },
            new Fins { Id = 24, Brand = "Seac", Model = "ALA", Size = "L", PricePerDay = 50 },
            new Fins { Id = 25, Brand = "Seac", Model = "ALA", Size = "XL", PricePerDay = 50 },

            new Fins { Id = 26, Brand = "Fourth Element", Model = "Tech", Size = "XS", PricePerDay = 75 },
            new Fins { Id = 27, Brand = "Fourth Element", Model = "Tech", Size = "S", PricePerDay = 75 },
            new Fins { Id = 28, Brand = "Fourth Element", Model = "Tech", Size = "M", PricePerDay = 75 },
            new Fins { Id = 29, Brand = "Fourth Element", Model = "Tech", Size = "L", PricePerDay = 75 },
            new Fins { Id = 30, Brand = "Fourth Element", Model = "Tech", Size = "XL", PricePerDay = 75 },

            new Fins { Id = 31, Brand = "Fourth Element", Model = "Rec Fin", Size = "XS", PricePerDay = 80 },
            new Fins { Id = 32, Brand = "Fourth Element", Model = "Rec Fin", Size = "S", PricePerDay = 80 },
            new Fins { Id = 33, Brand = "Fourth Element", Model = "Rec Fin", Size = "M", PricePerDay = 80 },
            new Fins { Id = 34, Brand = "Fourth Element", Model = "Rec Fin", Size = "L", PricePerDay = 80 },
            new Fins { Id = 35, Brand = "Fourth Element", Model = "Rec Fin", Size = "XL", PricePerDay = 80 },
        };
        public static List<Fins> GetAll() => fins;

    }
}
