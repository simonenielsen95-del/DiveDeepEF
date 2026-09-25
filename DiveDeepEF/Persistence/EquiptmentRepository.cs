using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class EquiptmentRepository
    {
        public Equipment? GetById(int id, string category)
        {
            return category.ToLower() switch
            {
                "fin" => FinsRepository.GetById(id),
                "bcd" => BcdRepository.GetById(id),
                "mask" => MaskRepository.GetById(id),
                "regulator" => RegulatorSetRepository.GetById(id),
                "suit" => SuitRepository.GetById(id),
                "tank" => TankRepository.GetById(id),
                _ => null
            };
        }
    }
}
