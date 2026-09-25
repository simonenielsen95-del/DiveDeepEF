using System.ComponentModel.DataAnnotations;

namespace DiveDeepEF.Models.Equipments
{
    public class RegulatorSet : Equipment
    {      
        public string FirstStage { get; set; }
        public string SecondStage { get; set; }
        public string Octopus { get; set; }
    }
}
