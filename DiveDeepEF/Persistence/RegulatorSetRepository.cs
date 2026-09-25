using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class RegulatorSetRepository
    {
        private static List<RegulatorSet> regulatorSets = new List<RegulatorSet>
        {
            new RegulatorSet { Id = 1, Brand = "Scubapro", FirstStage = "MK25 EVO", SecondStage = "S600", Octopus = "R105", PricePerDay = 125 },
            new RegulatorSet { Id = 2, Brand = "Scubapro", FirstStage = "MK17 EVO", SecondStage = "C370", Octopus = "R095", PricePerDay = 100 },
            new RegulatorSet { Id = 3, Brand = "Scubapro", FirstStage = "MK25 EVO BT", SecondStage = "A700 Carbon BT", Octopus = "S270", PricePerDay = 150 }
        };

        public static List<RegulatorSet> GetAll() => regulatorSets;

        public static RegulatorSet? GetById(int id) => regulatorSets.FirstOrDefault(x => x.Id == id);

        public static void Add(RegulatorSet regSet)
        {
            if (regSet == null) return;
            regSet.Id = regulatorSets.Any() ? regulatorSets.Max(x => x.Id) + 1 : 1;
            regulatorSets.Add(regSet);
        }

        public static void Delete(int id)
        {
            regulatorSets.RemoveAll(x => x.Id == id);
        }

        public static void Update(int id, RegulatorSet regSet)
        {
            var target = GetById(id);
            if (target != null && regSet != null)
            {
                target.Brand = regSet.Brand;
                target.FirstStage = regSet.FirstStage;
                target.SecondStage = regSet.SecondStage;
                target.Octopus = regSet.Octopus;
                target.PricePerDay = regSet.PricePerDay;
            }
        }
    }
}
