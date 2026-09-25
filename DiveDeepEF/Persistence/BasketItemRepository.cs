using DiveDeepEF.Models.Bookings;
using DiveDeepEF.Models.Equipments;

namespace DiveDeepEF.Persistence
{
    public class BasketItemRepository
    {
        private static readonly List<BasketItem> items = new();

        public static List<BasketItem> GetAll()
        {
            return items;
        }

        public static BasketItem? GetById(int id) => items.FirstOrDefault(x => x.Id == id);

        public static void Add(BasketItem item)
        {
            items.Add(item);
        }
        public static void Delete(int id)
        {
            items.RemoveAll(x => x.Id == id);
            //if (index >= 0 && index < items.Count)
            //{
            //    items.RemoveAt(index);
            //}
        }


    }
}
