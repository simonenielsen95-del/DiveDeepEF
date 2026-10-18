using Microsoft.EntityFrameworkCore;
using DiveDeepEF.Data;
using DiveDeepEF.Interfaces;
using DiveDeepEF.Models.Equipments;


namespace DiveDeepEF.Persistence
{
    public class EquipmentRepository : IEquipmentRepository 
    {
        private readonly DiveDeepEFContext _context;

        public EquipmentRepository(DiveDeepEFContext context)
        {
            _context = context;
        }

        public List<Equipment> GetAll()
        {
            return _context.Equipments.ToList();
        }

        public List<T> GetAllByType<T>() where T : Equipment
        {
            return _context.Equipments
                .OfType<T>()
                .ToList();
        }

        public Equipment? GetById(int id)
        {
            return _context.Equipments
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            _context.SaveChanges();
        }

        public void Update(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Equipment? equipment = GetById(id);

            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
                _context.SaveChanges();
            }
        }
    }
}
