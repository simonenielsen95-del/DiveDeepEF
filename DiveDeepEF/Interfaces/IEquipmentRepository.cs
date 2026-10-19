using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Interfaces
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAll();
        List<T> GetAllByType<T>() where T : Equipment;
        Equipment? GetById(int id);
        void Add(Equipment equipment);
        void Update(Equipment equipment);
        void Delete(int id);

    }
}
